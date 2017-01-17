// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomController.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The room controller.
    /// </summary>
    public class RoomController : IEntityController<Room>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomController"/> class.
        /// </summary>
        public RoomController()
        {
            this.Repository = new RoomRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Room> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room CreateOrUpdateEntity(Room entity)
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
        /// The Room is null
        /// </exception>
        public void DeleteEntity(Room entity)
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
        /// The <see cref="Room"/>.
        /// </returns>
        public Room GetEntity(int id)
        {
            return this.Repository.ReadOne(id);
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Room}"/>.
        /// </returns>
        public IList<Room> RefreshEntities()
        {
            return this.Repository.ReadAllList();
        }
    }
}