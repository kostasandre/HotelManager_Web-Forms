// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The hotel controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Models.Persistant;
    using Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The hotel controller.
    /// </summary>
    public class HotelController : IEntityController<Hotel>
    {
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Hotel> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel CreateOrUpdateEntity(Hotel entity)
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
        /// The Hotel is null
        /// </exception>
        public void DeleteEntity(Hotel entity)
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
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Hotel}"/>.
        /// </returns>
        public IList<Hotel> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}