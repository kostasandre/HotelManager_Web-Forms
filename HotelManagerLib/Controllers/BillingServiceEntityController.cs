// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServiceEntityController.cs" company="">
//   
// </copyright>
// <summary>
//   The billing service entity controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The billing service entity controller.
    /// </summary>
    public class BillingServiceEntityController : IEntityController<BillingService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingServiceEntityController"/> class.
        /// </summary>
        public BillingServiceEntityController()
        {
            this.Repository = new BillingServiceEntityRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<BillingService> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="BillingService"/>.
        /// </returns>
        public BillingService CreateOrUpdateEntity(BillingService entity)
        {
            if (entity.Id == 0)
            {
                entity = this.Repository.Create(entity);
            }
            else
            {
                this.Repository.Update(entity);
            }

            return entity;
        }

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Returns an ArgumentNullException.
        /// </exception>
        public void DeleteEntity(BillingService entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The get entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="BillingService"/>.
        /// </returns>
        public BillingService GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<BillingService> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}