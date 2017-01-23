// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingForm.aspx.cs" company="Data Communication">
//   Dc Hotel Manager
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
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The booking form.
    /// </summary>
    public partial class BookingForm : Page
    {
        /// <summary>
        /// The booking.
        /// </summary>
        private Booking booking;

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
        /// The room type controller.
        /// </summary>
        private RoomTypeController roomTypeController;

        /// <summary>
        /// Gets or sets the available rooms.
        /// </summary>
        public List<Room> AvailableRooms { get; set; }

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
            double roomPrice;
            var pricingListController = new PricingListController();
            this.bookingController = new BookingController();
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
            }

            var dateFrom = this.dateFromCalendar.Value;
            var dateTo = this.dateToCalendar.Value;
            var roomType = this.roomTypeComboBox.Text;
            var roomTypeId = this.roomTypeComboBox.Value;
            try
            {
                roomPrice = pricingListController.RoomPricing(dateFrom, dateTo, Convert.ToInt32(roomTypeId));
            }
            catch (Exception ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = ex.Message;
                }
                    
                this.AvailableRooms = null;
                this.availableRoomsGridView.DataSource = this.AvailableRooms;
                this.availableRoomsGridView.DataBind();
                this.roomTypePriceTextBox.Text = string.Empty;
                return;
            }

            this.roomTypePriceTextBox.Text = roomPrice.ToString(CultureInfo.InvariantCulture);
            if ((dateFrom != null) && (dateTo != null) && (roomType != string.Empty))
            {
                this.AvailableRooms = this.bookingController.GetAvailableRooms(roomTypeId, dateFrom, dateTo);
                if (this.AvailableRooms.Count == 0)
                {
                    errorlabel.Text = "No available rooms for the selected days";
                }
                else
                {
                    errorlabel.Text = string.Empty;
                }
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
        protected void CustomersPopUpSaveButton(object sender, EventArgs e)
        {
            
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
            }
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
                this.booking.CustomerId = this.customer.Id;
                this.Session["Booking"] = this.booking;
                this.customerComboBoxDataBind();
                this.customerComboBox.Value = this.customer;
                this.customerComboBox.Text = this.customer.Name + " " + this.customer.Surname;
            }
            catch (Exception ex)
            {
                errorlabel.Text = ex.Message;
            }
        }

        /// <summary>
        /// The page initialize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.AvailableRooms = this.Session["AvailableRooms"] as List<Room>;
            this.customerComboBoxDataBind();
            if ((this.AvailableRooms != null) && (this.AvailableRooms.ToList().Count > 0))
            {
                this.availableRoomsGridView.DataSource = this.AvailableRooms;
                this.availableRoomsGridView.DataBind();
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
                this.AvailableRooms = new List<Room>();
                this.availableRoomsGridView.DataSource = this.AvailableRooms;
                this.availableRoomsGridView.DataBind();

                this.Session["Booking"] = new Booking();
                this.customerController = new CustomerController();
                this.roomTypeController = new RoomTypeController();

                var roomTypes = this.roomTypeController.RefreshEntities();
                this.roomTypeComboBox.DataSource = roomTypes;
                this.customerComboBoxDataBind();
                this.roomTypeComboBox.DataBind();
            }
            else
            {
                this.booking = this.Session["Booking"] as Booking;
            }
        }

        /// <summary>
        /// The save booking button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void saveBookingButton_OnClick(object sender, EventArgs e)
        {
            this.booking = this.Session["Booking"] as Booking;
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
            }
            
            this.roomTypeController = new RoomTypeController();
            this.customerController = new CustomerController();
            this.bookingController = new BookingController();
            this.customerComboBoxDataBind();

            var dateFrom = this.dateFromCalendar.Text;
            var dateTo = this.dateToCalendar.Text;
            var price = this.roomTypePriceTextBox.Text;
            if (price == string.Empty)
            {
                errorlabel.Text = "Please calculate price first";
                return;
            }

            var row = this.availableRoomsGridView.FocusedRowIndex;
            var selectedRoom = (Room)this.availableRoomsGridView.GetRow(row);
            if (selectedRoom == null)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Please select a room first";
                }

                return;
            }

            if (this.booking.CustomerId == 0)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Please select a customer first";
                }

                return;
            }

            var agreedPrice = this.agreedPriceTextBox.Text;
            if (agreedPrice == string.Empty)
            {
                agreedPrice = price;
            }

            //this.booking.Room = selectedRoom;
            this.booking.RoomId = selectedRoom.Id;
            this.booking.AgreedPrice = Convert.ToDouble(agreedPrice);
            this.booking.SystemPrice = Convert.ToDouble(price);
            this.booking.Created = DateTime.Now;
            this.booking.CreatedBy = Environment.UserName;
            //this.booking.Customer = customer;
           
            this.booking.From = Convert.ToDateTime(dateFrom);
            this.booking.To = Convert.ToDateTime(dateTo);
            this.booking.Status = Status.New;
            this.booking.Comments = this.commentMemoBox.Text;

            try
            {
                this.bookingController.CreateOrUpdateEntity(this.booking);
                this.Response.Redirect("BookingsListForm.aspx");
            }
            catch (Exception ex)
            {
                errorlabel.Text = ex.Message;
            }
        }

        /// <summary>
        /// The customer combo box data bind.
        /// </summary>
        private void customerComboBoxDataBind()
        {
            this.customerController = new CustomerController();
            var customers = this.customerController.RefreshEntities();
            this.customerComboBox.DataSource = customers;
            this.customerComboBox.DataBind();
        }

        protected void customerComboBox_OnValueChanged(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            var customerId = this.customerComboBox.Value;
            try
            {
                var localCustomer = this.customerController.GetEntity(Convert.ToInt32(customerId));
                this.booking.CustomerId = localCustomer.Id;
                this.Session["Booking"] = this.booking;
            }
            catch (Exception ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = ex.Message;
                }
            }
        }
    }
}