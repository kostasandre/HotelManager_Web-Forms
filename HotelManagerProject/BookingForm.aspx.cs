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
    using HotelManagerLib.Enums;
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
            var roomTypeId = this.roomTypeComboBox.Value;
            if (dateFrom != null && dateTo != null && roomType != string.Empty)
            {
                var rooms = this.roomController.RefreshEntities().Where(x => x.RoomTypeId == Convert.ToInt32(roomTypeId));
                var bookings = this.bookingController.RefreshEntities().Where(x => x.From == Convert.ToDateTime(dateFrom) && x.To == Convert.ToDateTime(dateTo));
                foreach (var room in rooms)
                {
                    var isAvailable = this.bookingController.IsRoomAvailable(room, bookings.ToList());
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
            
            this.availableRoomsGridView.DataSource = availableRooms;
            this.availableRoomsGridView.DataBind();
        }
    }
}