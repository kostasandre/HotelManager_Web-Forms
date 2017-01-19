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

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Exceptions;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The booking form.
    /// </summary>
    public partial class BookingForm : Page
    {
        public List<Room> AvailableRooms { get; set; }

        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The customer.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// The customer controller.
        /// </summary>
        private CustomerController customerController;

        /// <summary>
        /// The room controller.
        /// </summary>
        private RoomController roomController;

        /// <summary>
        /// The room type controller.
        /// </summary>
        private RoomTypeController roomTypeController;

        private Booking booking;

        protected void Page_Init(object sender , EventArgs e)
        {
            this.AvailableRooms = this.Session["AvailableRooms"] as List<Room>;

            if (this.AvailableRooms != null)
            {
                this.availableRoomsGridView.DataSource = this.AvailableRooms;
                this.availableRoomsGridView.DataBind();
            }
        }

        /// <summary>
        /// The calculate room type price button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void CalculateAvailableRoomsButton(object sender, EventArgs e)
        {
            var pricingListController = new PricingListController();
            this.bookingController = new BookingController();

            var dateFrom = this.dateFromCalendar.Value;
            var dateTo = this.dateToCalendar.Value;
            var roomType = this.roomTypeComboBox.Text;
            var roomTypeId = this.roomTypeComboBox.Value;
            var roomPrice = pricingListController.RoomPricing(
                Convert.ToDateTime(dateFrom),
                Convert.ToDateTime(dateTo),
                Convert.ToInt32(roomTypeId));
            this.roomTypePriceTextBox.Text = roomPrice.ToString(CultureInfo.InvariantCulture);
            if ((dateFrom != null) && (dateTo != null) && (roomType != string.Empty))
            {
                this.AvailableRooms = this.bookingController.GetAvailableRooms(roomTypeId, dateFrom, dateTo);
                this.Session["AvailableRooms"] = this.AvailableRooms;
            }

            this.availableRoomsGridView.DataSource = this.AvailableRooms;
            this.availableRoomsGridView.DataBind();
        }

        /// <summary>
        /// The customers pop up save button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void customersPopUpSaveButton_OnClick(object sender, EventArgs e)
        {
            this.customer = new Customer();
            this.customerController = new CustomerController();
            this.customer.Name = this.nameTextBox.Text;
            this.customer.Surname = this.surNameTextBox.Text;
            this.customer.IdNumber = this.idNumberTextBox.Text;
            this.customer.TaxId = this.taxIdTextBox.Text;
            this.customer.Email = this.emailTextBox.Text;
            this.customer.Address = this.addressTextBox.Text;
            this.customer.Phone = this.phoneTextBox.Text;

            try
            {
                this.customerController.CreateOrUpdateEntity(this.customer);
                this.customerComboBoxDataBind();
                this.customerComboBox.Value = this.customer;
                this.customerComboBox.Text = this.customer.Name;
            }
            catch (ArgumentException)
            {
                
            }
            
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
                this.customerController = new CustomerController();
                this.roomTypeController = new RoomTypeController();
                this.customerComboBoxDataBind();

                var roomTypes = this.roomTypeController.RefreshEntities();
                this.roomTypeComboBox.DataSource = roomTypes;

                this.roomTypeComboBox.DataBind();
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
        //protected void roomTypeComboBox_OnInit(object sender, EventArgs e)
        //{
           
        //}

        private void customerComboBoxDataBind()
        {
            this.customerController = new CustomerController();
            var customers = this.customerController.RefreshEntities();
            this.customerComboBox.DataSource = customers;
            this.customerComboBox.DataBind();
        }

        protected void saveBookingButton_OnClick(object sender, EventArgs e)
        {
            this.booking = new Booking();
            this.roomTypeController = new RoomTypeController();
            this.customerController = new CustomerController();
            this.bookingController = new BookingController();
            var comboBoxValue = this.customerComboBox.Value;
            this.roomTypeController.GetEntity(Convert.ToInt32(comboBoxValue));
            var dateFrom = this.dateFromCalendar.Text;
            var dateTo = this.dateToCalendar.Text;
            var price = this.roomTypePriceTextBox.Text;
            
            var row = this.availableRoomsGridView.FocusedRowIndex;
            var selectedRoom = (Room)this.availableRoomsGridView.GetRow(row);
            
            var customerId = this.customerComboBox.Value;
            var customer = this.customerController.GetEntity(Convert.ToInt32(customerId));

            var agreedPrice = this.agreedPriceTextBox.Text;
            this.booking.Room = selectedRoom;
            this.booking.RoomId = selectedRoom.Id;
            this.booking.AgreedPrice = Convert.ToDouble(agreedPrice);
            this.booking.SystemPrice = Convert.ToDouble(price);
            this.booking.Created = DateTime.Now;
            this.booking.CreatedBy = Environment.UserName;
            this.booking.Customer = customer;
            this.booking.CustomerId = customer.Id;
            this.booking.From = Convert.ToDateTime(dateFrom);
            this.booking.To = Convert.ToDateTime(dateTo);
            this.booking.Status = Status.New;

            try
            {
                this.bookingController.CreateOrUpdateEntity(this.booking);
                Response.Redirect("Main.aspx");
            }
            catch (Exception)
            {
                
            }
        }
    }
}