// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models.Persistant;
    using Repositories;
    using Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The pricing list controller.
    /// </summary>
    public class PricingListController : IEntityController<PricingList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PricingListController"/> class.
        /// </summary>
        public PricingListController()
        {
            this.Repository = new PricingListRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<PricingList> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList CreateOrUpdateEntity(PricingList entity)
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
        /// The PricingList is null
        /// </exception>
        public void DeleteEntity(PricingList entity)
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
        /// The <see cref="PricingList"/>.
        /// </returns>
        public PricingList GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{PricingList}"/>.
        /// </returns>
        public IList<PricingList> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}