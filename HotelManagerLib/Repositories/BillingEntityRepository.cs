// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingEntityRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   Defines the BillingEntityRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    /// <summary>
    /// The billing entity repository.
    /// </summary>
    public class BillingEntityRepository : IEntityRepository<Billing>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billling">
        /// The billling.
        /// </param>
        /// <returns>
        /// The <see cref="Billing"/>.
        /// </returns>
        public Billing Create(Billing billling)
        {
            {
                using (var context = new DataBaseContext())
                {
                    context.Billings.Add(billling);
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
                                    "Property: {0} Error: {1}",
                                    validationError.PropertyName,
                                    validationError.ErrorMessage);
                            }
                        }
                    }
                }

                return billling;
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throws an ArgumentNullException.
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var billing = context.Billings.SingleOrDefault(x => x.Id == id);
                if (billing == null)
                {
                    throw new ArgumentNullException();
                }

                context.Billings.Remove(billing);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Billing> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Billings.Include("Bookings").ToList();
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
        public IQueryable<Billing> ReadAllQuery(DataBaseContext context)
        {
            return context.Billings.Include("Bookings");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Billing"/>.
        /// </returns>
        public Billing ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var billing = context.Billings.Include("Bookings").SingleOrDefault(x => x.Id == id);
                return billing;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        public void Update(Billing billing)
        {
            using (var context = new DataBaseContext())
            {
                var databaseBilling = context.Billings.SingleOrDefault(x => x.Id == billing.Id);

                if (databaseBilling == null)
                {
                    return;
                }

                databaseBilling.Paid = billing.Paid;
                databaseBilling.PriceForRoom = billing.PriceForRoom;
                databaseBilling.PriceForServices = billing.PriceForServices;
                databaseBilling.TotalPrice = billing.TotalPrice;
                databaseBilling.Updated = DateTime.Now;
                databaseBilling.UpdatedBy = Environment.UserName;
                context.SaveChanges();
            }
        }
    }
}
