// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServicesWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The billing web form.
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
    /// The billing web form.
    /// </summary>
    public partial class BillingWebForm : Page
    {
        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        private IEntityController<Booking> bookingEntityController;

        /// <summary>
        /// The billing service entity controller.
        /// </summary>
        private IEntityController<BillingService> billingServiceEntityController;

        /// <summary>
        /// The service controller.
        /// </summary>
        private IEntityController<Service> serviceController;
       

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
            this.bookingEntityController = new BookingController();
            this.serviceController = new ServiceController();
            this.BillingGridView.DataSource = this.serviceController.RefreshEntities();
            this.BillingGridView.DataBind();
            this.BillingGridView.Visible = false;
            this.BookingListGridview.DataSource = this.bookingEntityController.RefreshEntities();
            this.BookingListGridview.DataBind();
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