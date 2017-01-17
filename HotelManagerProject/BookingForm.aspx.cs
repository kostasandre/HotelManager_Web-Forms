using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerProject
{
    using HotelManagerLib.Controllers;

    public partial class BookingForm : System.Web.UI.Page
    {
        private BookingController bookingController;
        protected void Page_Load(object sender , EventArgs e)
        {
            this.bookingController = new BookingController();
            //this.ASPxDropDownEdit1.DataSource = this.bookingController.Repository.ReadOne().Room.RoomType;
        }
    }
}