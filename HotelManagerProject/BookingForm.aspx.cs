using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerProject
{
    using System.Collections;

    using DevExpress.XtraPrinting.Native;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.DBContext;
    using HotelManagerLib.Models.Persistant;

    public partial class BookingForm : System.Web.UI.Page
    {
        private BookingController bookingController;

        private RoomController roomController;

        private RoomTypeController roomTypeController;
        protected void Page_Load(object sender , EventArgs e)
        {
            this.bookingController = new BookingController();
            this.roomController = new RoomController();
        }

        protected void roomTypeComboBox_OnInit(object sender, EventArgs e)
        {
            this.roomTypeController = new RoomTypeController();
            var roomTypes = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypes;
            this.roomTypeComboBox.DataBind();
        }

        protected void calculateRoomTypePriceButton_OnClick(object sender, EventArgs e)
        {
            var bookedRoomsInDaysGiven = new List<Booking>();
            var availableRooms = new List<Room>();
            var dateFrom = this.dateFromCalendar.Value;
            var dateTo = this.dateToCalendar.Value;
            var roomType = this.roomTypeComboBox.Text;
            if (dateFrom != null && dateTo != null && roomType != String.Empty)
            {
                //showAvailableRooms
                var rooms = this.roomController.RefreshEntities();
                var bookings = this.bookingController.RefreshEntities();
                bookedRoomsInDaysGiven.AddRange(bookings.Where(booking => booking.From == Convert.ToDateTime(dateFrom) && booking.To == Convert.ToDateTime(dateTo)));
                foreach (var room in rooms)
                {
                   var isAvailable = this.bookingController.IsRoomAvailable(room, bookedRoomsInDaysGiven);
                    if (isAvailable)
                    {
                        availableRooms.Add(room);
                    }
                }
            }
            else
            {
                return;
            }
            //var availableRooms = this.roomController.Repository.ReadAllQuery();
            //    this.availableRoomsGridView.DataSource
        }
    }
}