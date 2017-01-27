// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The billing repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The billing repository.
    /// </summary>
    public class RoomRepository : IEntityRepository<Room>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room Create(Room billing)
        {
            using (var context = new DataBaseContext())
            {
                context.Rooms.Add(billing);
                context.SaveChanges();
            }

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The billing id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Room is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var room = context.Rooms.SingleOrDefault(x => x.Id == id);
                if (room == null)
                {
                    throw new ArgumentNullException($"ArgumentNullException");
                }

                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Room}"/>.
        /// </returns>
        public IList<Room> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Rooms.Include("Hotel").Include("RoomType").ToList();
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
        public IQueryable<Room> ReadAllQuery(DataBaseContext context)
        {
            return context.Rooms.Include("Hotel").Include("RoomType");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var room = context.Rooms.Include("Hotel").Include("RoomType").SingleOrDefault(x => x.Id == id);
                return room;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="room">
        /// The billing.
        /// </param>
        public void Update(Room room)
        {
            using (var context = new DataBaseContext())
            {
                var databaseRoom = context.Rooms.Include("Hotel").Include("RoomType").SingleOrDefault(x => x.Id == room.Id);
                if (databaseRoom == null)
                {
                    return;
                }

                // var databaseHotel = context.Hotels.SingleOrDefault(x => x.Id == billing.HotelId);          //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
                // databaseRoom.HotelId = databaseHotel.Id;                                               //to evala se sxolio giati sto update den mporoume na allaksoume Hotel
                databaseRoom.Code = room.Code;

                // databaseRoom.RoomTypeId = billing.RoomTypeId;                                            // to evala se sxolio giati sto update den mporoume na allaksoume billing Type
                databaseRoom.Updated = DateTime.Now;
                databaseRoom.UpdatedBy = Environment.UserName;

                context.SaveChanges();
            }
        }
    }
}