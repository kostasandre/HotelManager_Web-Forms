// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The room repository.
    /// </summary>
    public class RoomRepository : IEntityRepository<Room>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="room">
        /// The room.
        /// </param>
        /// <returns>
        /// The <see cref="Room"/>.
        /// </returns>
        public Room Create(Room room)
        {
            using (var context = new DataBaseContext())
            {
                context.Rooms.Add(room);
                //if (room.Hotel != null)
                //{
                //    context.Entry(room.Hotel).State = EntityState.Unchanged;
                //    room.Hotel.Rooms.Where(x => x.Id > 0)
                //        .ToList()
                //        .ForEach(x => context.Entry(x).State = EntityState.Unchanged);
                //}

                //if (room.RoomType != null)
                //{
                //    context.Entry(room.RoomType).State = EntityState.Unchanged;
                //    room.RoomType.Rooms.Where(x => x.Id > 0)
                //        .ToList()
                //        .ForEach(x => context.Entry(x).State = EntityState.Unchanged);
                //}

                context.SaveChanges();
            }

            return room;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The room id.
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
        /// The room.
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

                //if (room.Hotel != null)
                //{
                //    //var databaseHotel = context.Hotels.SingleOrDefault(x => x.Id == room.Hotel.Id);
                //    //databaseRoom.Hotel = databaseHotel;
                //}

                // else
                // {
                // databaseRoom.HotelId = null;
                // }
                var databaseHotel = context.Hotels.SingleOrDefault(x => x.Id == room.HotelId);
                databaseRoom.Hotel = databaseHotel;
                databaseRoom.Code = room.Code;
                databaseRoom.RoomType = room.RoomType; // ???????????
                databaseRoom.RoomTypeId = room.RoomTypeId; // ???????????
                databaseRoom.Updated = DateTime.Now;
                databaseRoom.UpdatedBy = Environment.UserName;

                context.SaveChanges();
            }
        }
    }
}