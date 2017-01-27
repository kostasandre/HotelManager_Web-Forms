// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingController.cs" company="Data Communication">
//   Hotel Manager 
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
        /// <exception cref="ArgumentNullException">
        /// The Booking is null
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
        /// <exception cref="ArgumentNullException">
        /// The Booking is null
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
        /// The <see cref="IList{Booking}"/>.
        /// </returns>
        public IList<Booking> RefreshEntities()
        {
            var bookingList = this.Repository.ReadAllList();
            return bookingList;
        }

        /// <summary>
        /// The get available rooms.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        /// <param name="roomTypeId">
        /// The room type id.
        /// </param>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <returns>
        /// The <see cref="List{Room}"/>.
        /// </returns>
        public List<Room> GetAvailableRooms(Hotel hotel, object roomTypeId, object dateFrom, object dateTo)
        {
            var roomController = new RoomController();
            var availableRooms = new List<Room>();
            var rooms = hotel != null
                            ? roomController.RefreshEntities()
                                .Where(x => x.RoomTypeId == Convert.ToInt32(roomTypeId) && x.HotelId == hotel.Id)
                            : roomController.RefreshEntities().Where(x => x.RoomTypeId == Convert.ToInt32(roomTypeId));

            // var rooms = roomController.RefreshEntities().Where(x => x.RoomTypeId == Convert.ToInt32(roomTypeId));
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