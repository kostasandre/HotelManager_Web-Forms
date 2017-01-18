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

    #endregion

    /// <summary>
    /// The billing web form.
    /// </summary>
    public partial class BillingWebForm : Page
    {
        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private BillingEntityController billingEntityController;

        /// <summary>
        /// The billing service entity controller.
        /// </summary>
        private BillingServiceEntityController billingServiceEntityController;

        private ServiceController serviceController;

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
            this.serviceController = new ServiceController();
            this.BillingGridView.DataSource = this.serviceController.RefreshEntities();
            this.BillingGridView.DataBind();
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