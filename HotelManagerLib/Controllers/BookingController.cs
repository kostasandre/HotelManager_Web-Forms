// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingController.cs" company="">
//   
// </copyright>
// <summary>
//   The booking controller.
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
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The booking controller.
    /// </summary>
    public class BookingController : IEntityController<Booking>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class.
        /// </summary>
        public BookingController()
        {
            this.Repository = new BookingRepository();
        }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        public IEntityRepository<Booking> Repository { get; set; }

        /// <summary>
        /// The create or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Booking"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Booking CreateOrUpdateEntity(Booking entity)
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DeleteEntity(Booking entity)
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
        /// The <see cref="Booking"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Booking GetEntity(int id)
        {
            if (id > 0)
            {
                return this.Repository.ReadOne(id);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// The refresh entities.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IList<Booking> RefreshEntities()
        {
            var bookingList = this.Repository.ReadAllList();
            return bookingList;
        }

        /// <summary>
        /// The is room available.
        /// </summary>
        /// <param name="roomType">
        /// The room Type.
        /// </param>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public List<Room> AvailableRooms(object roomTypeId, object dateFrom, object dateTo )
        {
            var roomController = new RoomController();
            var availableRooms = new List<Room>();
            var rooms = roomController.RefreshEntities().Where(x => x.RoomTypeId == Convert.ToInt32(roomTypeId));
            foreach (var room in rooms)
            {
                var isAvailable = !this.RefreshEntities().Any(x => x.RoomId == room.Id && x.Status != Status.Cancelled && ((x.To >= Convert.ToDateTime(dateFrom)) && (Convert.ToDateTime(dateTo) >= x.From)));
                if (isAvailable)
                {
                    availableRooms.Add(room);
                }
            }
            return availableRooms;
        }
    }
}