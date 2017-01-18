// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingsListForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The bookings list form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Web.UI;

    using HotelManagerLib.Controllers;

    #endregion

    /// <summary>
    /// The bookings list form.
    /// </summary>
    public partial class BookingsListForm : Page
    {
        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The customer controller.
        /// </summary>
        private CustomerController customerController;

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
                var bookingsList = this.bookingController.RefreshEntities();
                this.bookingsGridView.DataSource = bookingsList;
                this.bookingsGridView.DataBind();
            }
        }
    }
}