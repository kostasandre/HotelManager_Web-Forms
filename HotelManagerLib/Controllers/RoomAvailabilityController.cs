// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomAvailabilityController.cs" company="">
//   
// </copyright>
// <summary>
//   The room availability controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerLib.Controllers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HotelManagerLib.Enums;
    using HotelManagerLib.Models;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The room availability controller.
    /// </summary>
    public class RoomAvailabilityController
    {
        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The calendar list.
        /// </summary>
        private List<BookingCalendar> calendarList;

        /// <summary>
        /// The room controller.
        /// </summary>
        private RoomController roomController;

        /// <summary>
        /// The booking calendar.
        /// </summary>
        /// <param name="month">
        /// The month.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Throws exception when refresh occurs.
        /// </exception>
        public List<BookingCalendar> BookingCalendar(DateTime date)
        {
            this.bookingController = new BookingController();
            this.roomController = new RoomController();
            this.calendarList = new List<BookingCalendar>();
            IList<Booking> bookings;
            IList<Room> rooms;

            try
            {
                bookings = this.bookingController.RefreshEntities();
                rooms = this.roomController.RefreshEntities();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            foreach (var availableRoom in rooms)
            {
                var calendarEntry = new BookingCalendar();

                var properties = typeof(BookingCalendar).GetProperties().Where(x => x.Name.StartsWith("Day"));
                foreach (var property in properties)
                {
                    var dateString = $"{property.Name.Substring(3)}/{date.Month}/{date.Year}";
                    DateTime parsedDate;
                    if (!DateTime.TryParse(dateString, out parsedDate))
                    {
                        property.SetValue(calendarEntry, AvailableStatus.NotExistingDay);
                    }
                }


                foreach (var booking in bookings.Where(x => x.Room.Id == availableRoom.Id))
                {
                    var bookingDays = (booking.To - booking.From).Days;
                    for (var i = 0; i < bookingDays; i++)
                    {
                        var checkDay = booking.From.AddDays(i);
                        var correctProperty = $"Day{checkDay.Day}";
                        var propertyInfo = typeof(BookingCalendar).GetProperty(correctProperty);
                        if ((checkDay.Year == date.Year) && (checkDay.Month == date.Month) && (booking.Status != Status.Cancelled) && (propertyInfo != null))
                        {
                            switch (booking.Status)
                            {
                                case Status.New:
                                    propertyInfo.SetValue(calendarEntry, AvailableStatus.NotAvailable);
                                    break;
                                case Status.Active:
                                    propertyInfo.SetValue(calendarEntry, AvailableStatus.NotAvailableOccupied);
                                    break;
                                case Status.Billed:
                                    propertyInfo.SetValue(calendarEntry, AvailableStatus.NotAvailableBilled);
                                    break;
                            }
                        }
                    }
                }

                calendarEntry.Hotel = availableRoom.HotelName;
                calendarEntry.Room = availableRoom.Code;
                this.calendarList.Add(calendarEntry);
            }

            return this.calendarList;
        }
    }
}