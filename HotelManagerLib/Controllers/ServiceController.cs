// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The service controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using HotelManagerLib.Enums;

    using Interfaces;
    using Models.Persistant;
    using Repositories;
    using Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The service controller.
    /// </summary>
    public class ServiceController : IEntityController<Service>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceController"/> class.
        /// </summary>
        public ServiceController()
        {
            this.Repository = new ServiceRepository();
            this.PricingListRepository = new PricingListRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Service> Repository { get; set; }

        /// <summary>
        /// Gets or sets the pricing list repository.
        /// </summary>
        public IEntityRepository<PricingList> PricingListRepository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Service"/>.
        /// </returns>
        public Service CreateOrUpdateEntity(Service entity)
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
        /// The Service is null
        /// </exception>
        public void DeleteEntity(Service entity)
        {
            if (entity.Id > 0)
            {
                this.Repository.Delete(entity.Id);
                var pricingLists = this.PricingListRepository.ReadAllList();
                foreach (var pricingList in pricingLists)
                {
                    if ((pricingList.TypeOfBillableEntity == TypeOfBillableEntity.Service)
                        && (pricingList.BillableEntityId == entity.Id))
                    {
                        this.PricingListRepository.Delete(pricingList.Id);
                    }
                }
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
        /// The <see cref="Service"/>.
        /// </returns>
        public Service GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Service}"/>.
        /// </returns>
        public IList<Service> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}