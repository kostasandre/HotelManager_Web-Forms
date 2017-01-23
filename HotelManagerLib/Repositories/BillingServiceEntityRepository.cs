// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServiceEntityRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The billinge services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using DBContext;

    using HotelManagerLib.Models.Persistant;

    #region

    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The billinge services.
    /// </summary>
    public class BillingServiceEntityRepository : IEntityRepository<BillingService>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billingService">
        /// The billing service.
        /// </param>
        /// <returns>
        /// The <see cref="BillingService"/>.
        /// </returns>
        public BillingService Create(BillingService billingService)
        {
            {
                using (var context = new DataBaseContext())
                {
                    context.BillingServices.Add(billingService);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException exception)
                    {
                        foreach (var validationErrors in exception.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation(
                                    "Property: {0} Error: {1}" ,
                                    validationError.PropertyName ,
                                    validationError.ErrorMessage);
                            }
                        }
                    }
                }

                return billingService;
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Returns an ArgumentNullException.
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var billingService = context.BillingServices.SingleOrDefault(x => x.Id == id);
                if (billingService == null)
                {
                    throw new ArgumentNullException();
                }

                context.BillingServices.Remove(billingService);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<BillingService> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.BillingServices.ToList();
            }
        }

        /// <summary>
        /// The read all query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<BillingService> ReadAllQuery(DataBaseContext context)
        {
            return context.BillingServices.Include("Billings");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="BillingService"/>.
        /// </returns>
        public BillingService ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var billingService = context.BillingServices.SingleOrDefault(x => x.Id == id);
                return billingService;
            }
        }

        public void Update(BillingService billingService)
        {
            using (var context = new DataBaseContext())
            {
                var databaseBillingService = context.BillingServices.SingleOrDefault(x => x.Id == billingService.Id);

                if (databaseBillingService == null)
                {
                    return;
                }

                databaseBillingService.BillingId = billingService.BillingId;
                databaseBillingService.ServiceId = billingService.ServiceId;
                databaseBillingService.Price = billingService.Price;
                databaseBillingService.Quantity = billingService.Quantity;
                databaseBillingService.Updated = DateTime.Now;
                databaseBillingService.UpdatedBy = Environment.UserName;
                context.SaveChanges();
            }
        }
    }
}