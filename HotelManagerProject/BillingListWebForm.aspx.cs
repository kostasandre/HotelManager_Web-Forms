// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingListWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The billing list form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Web.UI;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The billing list form.
    /// </summary>
    public partial class BillingListForm : Page
    {
        /// <summary>
        /// The billing.
        /// </summary>
        private Billing billing;

        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        /// <summary>
        /// The booking entity controller.
        /// </summary>
        private IEntityController<Booking> bookingEntityController;

        private Booking booking;

        /// <summary>
        /// The bt o k_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btOK_Click(object sender, EventArgs e)
        {
            this.billingEntityController = new BillingEntityController();
            this.bookingEntityController = new BookingController();
            this.booking = new Booking();
            var myBooking = Convert.ToInt32(this.bookingComboBox.SelectedItem.Value);
            this.booking = this.bookingEntityController.GetEntity(myBooking);
          
            this.billing = new Billing
                               {
                //Id = 5,
                                   Booking = this.booking,
                                   Paid = this.paidCheckBox.Checked,
                                   PriceForRoom = Convert.ToDouble(this.priceForRoomTextBox.Text),
                                   PriceForServices = Convert.ToDouble(this.priceForServicesTextBox.Text),
                                   TotalPrice = Convert.ToDouble(this.totalPricerTextBox.Text)
                               };
            this.billingEntityController.CreateOrUpdateEntity(this.billing);
            this.BillingListGridView.DataSource = this.billingEntityController.RefreshEntities();
            this.BillingListGridView.DataBind();
        }

        /// <summary>
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.billingEntityController = new BillingEntityController();
            this.bookingEntityController = new BookingController();
            this.bookingComboBox.DataSource = this.bookingEntityController.RefreshEntities();
            this.bookingComboBox.SelectedIndex = 0;
            this.bookingComboBox.DataBind();
            this.BillingListGridView.DataSource = this.billingEntityController.RefreshEntities();
            this.BillingListGridView.DataBind();
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
        }
    }
}