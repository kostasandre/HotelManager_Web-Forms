// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The picture controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;

    using HotelManagerLib.Repositories;

    using Interfaces;
    using Models.Persistant;
    using Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The picture controller.
    /// </summary>
    public class PictureController : IEntityController<Picture>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PictureController"/> class.
        /// </summary>
        public PictureController()
        {
                this.Repository = new PictureRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Picture> Repository { get; set; }

        /// <summary>
        /// Only create a Picture, NOT update
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Picture"/>.
        /// </returns>
        public Picture CreateOrUpdateEntity(Picture entity)
        {
            entity = this.Repository.Create(entity);
            return entity;
        }

        /// <summary>
        /// The delete entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The picture is null
        /// </exception>
        public void DeleteEntity(Picture entity)
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
        /// The <see cref="Picture"/>.
        /// </returns>
        public Picture GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Picture}"/>.
        /// </returns>
        public IList<Picture> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}