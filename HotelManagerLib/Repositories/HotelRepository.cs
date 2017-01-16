// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelRepository.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The hotel repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;
    using HotelManagerLib.Repositories.Interfaces;

    #endregion

    /// <summary>
    /// The hotel repository.
    /// </summary>
    public class HotelRepository : IEntityRepository<Hotel>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel Create(Hotel hotel)
        {
            using (var context = new DataBaseContext())
            {
                context.Hotel.Add(hotel);
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

            return hotel;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Hotel is null
        /// </exception>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var hotel = context.Hotel.SingleOrDefault(x => x.Id == id);
                if (hotel == null)
                {
                    throw new ArgumentNullException();
                }

                context.Hotel.Remove(hotel);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Hotel}"/>.
        /// </returns>
        public IList<Hotel> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Hotel.Include("Rooms").ToList();
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
        public IQueryable<Hotel> ReadAllQuery(DataBaseContext context)
        {
            return context.Hotel.Include("Rooms");
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Hotel"/>.
        /// </returns>
        public Hotel ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                var hotel = context.Hotel.Include("Rooms").SingleOrDefault(x => x.Id == id);
                return hotel;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="hotel">
        /// The hotel.
        /// </param>
        public void Update(Hotel hotel)
        {
            using (var context = new DataBaseContext())
            {
                var databaseHotel = context.Hotel.SingleOrDefault(x => x.Id == hotel.Id);

                if (databaseHotel == null)
                {
                    return;
                }

                databaseHotel.Name = hotel.Name;
                databaseHotel.Address = hotel.Address;
                databaseHotel.Email = hotel.Email;
                databaseHotel.Manager = hotel.Manager;
                databaseHotel.Phone = hotel.Phone;
                databaseHotel.TaxId = hotel.TaxId;

                // databaseHotel.PictureId = hotel.PictureId;
                databaseHotel.Updated = DateTime.Now;
                databaseHotel.UpdatedBy = Environment.UserName;
                context.SaveChanges();
            }
        }
    }
}