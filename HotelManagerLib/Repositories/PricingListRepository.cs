// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using DBContext;

    using Interfaces;

    using Models.Persistant;

    #endregion

    /// <summary>
    /// The pricing list repository.
    /// </summary>
    public class PricingListRepository : IEntityRepository<PricingList>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="pricingList">
        /// The pricing list.
        /// </param>
        /// <returns>
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList Create(PricingList pricingList)
        {
            using (var context = new DataBaseContext())
            {
                context.PricingList.Add(pricingList);
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

            return pricingList;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The PricingList is Null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var pricingList = context.PricingList.SingleOrDefault(x => x.Id == id);
                if (pricingList == null)
                {
                    throw new ArgumentNullException($"ArgumentNullException");
                }

                context.PricingList.Remove(pricingList);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{PricingList}"/>.
        /// </returns>
        public IList<PricingList> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.PricingList.ToList();
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
        public IQueryable<PricingList> ReadAllQuery(DataBaseContext context)
        {
            return context.PricingList;
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var pricingList = context.PricingList.SingleOrDefault(x => x.Id == id);
                return pricingList;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="pricingList">
        /// The pricing list.
        /// </param>
        public void Update(PricingList pricingList)
        {
            using (var context = new DataBaseContext())
            {
                var databasePricingList = context.PricingList.SingleOrDefault(x => x.Id == pricingList.Id);

                if (databasePricingList == null)
                {
                    return;
                }

                databasePricingList.Price = pricingList.Price;
                databasePricingList.ValidFrom = pricingList.ValidFrom;
                databasePricingList.ValidTo = pricingList.ValidTo;
                databasePricingList.VatPrc = pricingList.VatPrc;
                databasePricingList.Updated = DateTime.Now;
                databasePricingList.UpdatedBy = Environment.UserName;
                context.SaveChanges();
            }
        }
    }
}