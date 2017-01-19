// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingForm.aspx.cs" company="">
//   
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
    using System.Globalization;
    using System.Web.UI;

    using DevExpress.Web;

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

        private CustomerController customerController;

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
            var availableRooms = new List<Room>();
            var pricingListController = new PricingListController();
            

            var dateFrom = this.dateFromCalendar.Value;
            var dateTo = this.dateToCalendar.Value;
            var roomType = this.roomTypeComboBox.Text;
            var roomTypeId = this.roomTypeComboBox.Value;
            var roomPrice = pricingListController.RoomPricing(Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo), Convert.ToInt32(roomTypeId));
            this.roomTypePriceTextBox.Text = roomPrice.ToString(CultureInfo.InvariantCulture);
            if ((dateFrom != null) && (dateTo != null) && (roomType != string.Empty))
            {
                availableRooms = this.bookingController.AvailableRooms(roomTypeId, dateFrom, dateTo);
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
            if (!this.Page.IsPostBack)
            {
                this.bookingController = new BookingController();
                this.roomController = new RoomController();
                this.customerController = new CustomerController();
            }
           
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

        protected void customerSearchComboBoxOnCallBack(object sender, CallbackEventArgsBase e)
        {
            var customerList = this.customerController.RefreshEntities();
            this.customerSearchComboBox.DataSource = customerList;
            this.customerSearchComboBox.DataBind();
        }
    }
}