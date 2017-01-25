// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The booking repository.
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
    /// The booking repository.
    /// </summary>
    class BookingRepository : IEntityRepository<Booking>
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="booking">
        /// The booking.
        /// </param>
        /// <returns>
        /// The <see cref="Booking"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Booking Create(Booking booking)
        {
            using (var context = new DataBaseContext())
            {
                context.Bookings.Add(booking);
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

            return booking;
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            using (var context = new DataBaseContext())
            {
                var booking = context.Bookings.SingleOrDefault(x => x.Id == id);
                context.Bookings.Remove(booking);
                if (booking == null)
                {
                    throw new ArgumentNullException();
                }

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
        }

        /// <summary>
        /// The read all list.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Booking> ReadAllList()
        {
            using (var context = new DataBaseContext())
            {
                return context.Bookings.Include("Room").Include("Customer").ToList();
                
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
        public IQueryable<Booking> ReadAllQuery(DataBaseContext context)
        {
            return context.Bookings;
        }

        /// <summary>
        /// The read one.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Booking"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Booking ReadOne(int id)
        {
            using (var context = new DataBaseContext())
            {
                return context.Bookings.Include("Room").Include("Customer").SingleOrDefault(x => x.Id == id);
                
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void Update(Booking entity)
        {
            using (var context = new DataBaseContext())
            {
                var booking = context.Bookings.SingleOrDefault(x => x.Id == entity.Id);
                
                booking.AgreedPrice = entity.AgreedPrice;
                booking.Comments = entity.Comments;
                booking.CustomerId = entity.CustomerId;
                booking.From = entity.From;
                booking.To = entity.To;
                booking.RoomId = entity.RoomId;
                booking.Status = entity.Status;
                booking.SystemPrice = entity.SystemPrice;
                booking.Updated = DateTime.Now;
                booking.UpdatedBy = Environment.UserName;

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
        }
    }
}