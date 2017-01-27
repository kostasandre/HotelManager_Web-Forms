// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   Defines the RoomTypeRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    /// <summary>
    /// The billing type repository.
    /// </summary>
    public class RoomTypeRepository : IEntityRepository<RoomType>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="billing">
        /// The billing type.
        /// </param>
        /// <returns>
        /// The <see cref="RoomType"/>.
        /// </returns>
        public RoomType Create(RoomType billing)
        {
            using (var context = new DataBaseContext())
            {
                context.RoomTypes.Add(billing);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException exception)
                {
                    foreach (var validationErrors in exception.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                "Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }

            return billing;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// The billing type is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var roomType = context.RoomTypes.SingleOrDefault(x => x.Id == id);
                if (roomType == null)
                {
                    throw new ArgumentNullException();
                }

                context.RoomTypes.Remove(roomType);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{billing}"/>.
        /// </returns>
        public IList<RoomType> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.RoomTypes.Include("Rooms").ToList();
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
        public IQueryable<RoomType> ReadAllQuery(DataBaseContext context)
        {
            return context.RoomTypes.Include("Rooms");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="RoomType"/>.
        /// </returns>
        public RoomType ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var roomType = context.RoomTypes.Include("Rooms").SingleOrDefault(x => x.Id == id);
                return roomType;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="roomType">
        /// The billing type.
        /// </param>
        public void Update(RoomType roomType)
        {
            using (var context = new DataBaseContext())
            {
                var databaseRoomType = context.RoomTypes.SingleOrDefault(x => x.Id == roomType.Id);

                if (databaseRoomType == null)
                {
                    return;
                }

                databaseRoomType.Code = roomType.Code;
                databaseRoomType.BedType = roomType.BedType;
                databaseRoomType.Sauna = roomType.Sauna;
                databaseRoomType.Tv = roomType.Tv;
                databaseRoomType.WiFi = roomType.WiFi;
                databaseRoomType.Updated = DateTime.Now;
                databaseRoomType.UpdatedBy = Environment.UserName;
                databaseRoomType.View = roomType.View;
                context.SaveChanges();
            }
        }
    }
}
