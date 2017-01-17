// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingEntityController.cs" company="Data Communication">
//   Hotel Manager 
// </copyright>
// <summary>
//   The billing entity controller.
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
    /// The billing entity controller.
    /// </summary>
    public class BillingEntityController : IEntityController<Billing>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingEntityController"/> class.
        /// </summary>
        public BillingEntityController()
        {
            this.Repository = new BillingEntityRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Billing> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Billing"/>.
        /// </returns>
        public Billing CreateOrUpdateEntity(Billing entity)
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
        public void DeleteEntity(Billing entity)
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
        /// The <see cref="Billing"/>.
        /// </returns>
        public Billing GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Billing> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}