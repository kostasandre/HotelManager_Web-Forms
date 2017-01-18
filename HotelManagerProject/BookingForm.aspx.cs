// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The booking form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The booking form.
    /// </summary>
    public partial class BookingForm : Page
    {
        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The room controller.
        /// </summary>
        private RoomController roomController;

        /// <summary>
        /// The room type controller.
        /// </summary>
        private RoomTypeController roomTypeController;

        /// <summary>
        /// The calculate room type price button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void calculateRoomTypePriceButton_OnClick(object sender, EventArgs e)
        {
            var bookedRoomsInDaysGiven = new List<Booking>();
            var availableRooms = new List<Room>();
            var dateFrom = this.dateFromCalendar.Value;
            var dateTo = this.dateToCalendar.Value;
            var roomType = this.roomTypeComboBox.Text;
            var roomTypeId = this.roomTypeComboBox.Value;
            if ((dateFrom != null) && (dateTo != null) && (roomType != string.Empty))
            {
                var rooms = this.roomController.RefreshEntities();
                var bookings = this.bookingController.RefreshEntities();
                bookedRoomsInDaysGiven.AddRange(
                    bookings.Where(
                        booking =>
                            (booking.From == Convert.ToDateTime(dateFrom))
                            && (booking.To == Convert.ToDateTime(dateTo))));
                availableRooms.AddRange(
                    from room in rooms
                    let isAvailable = this.bookingController.IsRoomAvailable(room, bookedRoomsInDaysGiven)
                    where isAvailable
                    select room);
            }
            else
            {
                return;
            }

            this.availableRoomsGridView.DataSource = availableRooms;
            this.availableRoomsGridView.DataBind();
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.bookingController = new BookingController();
            this.roomController = new RoomController();
        }

        /// <summary>
        /// The room type combo box_ on init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void roomTypeComboBox_OnInit(object sender, EventArgs e)
        {
            this.roomTypeController = new RoomTypeController();
            var roomTypes = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypes;

            this.roomTypeComboBox.DataBind();
        }
    }
}