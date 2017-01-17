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

        private RoomTypeController roomTypeController;
        protected void Page_Load(object sender , EventArgs e)
        {
            this.bookingController = new BookingController();
            this.roomTypeController = new RoomTypeController();
            var roomTypes = this.roomTypeController.Repository.ReadAllList();
            
            this.ASPxComboBox1.DataSource = roomTypes;
            this.ASPxComboBox1.Text = "Code";
            this.ASPxComboBox1.ValueField = "Id";
            this.ASPxComboBox1.ValueType = typeof(int);
            this.ASPxComboBox1.DataBind();
        }
    }
}