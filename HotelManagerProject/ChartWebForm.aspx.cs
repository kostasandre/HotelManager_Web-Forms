// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChartWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The chart web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Web.UI;

    using DevExpress.DashboardWeb;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The chart web form.
    /// </summary>
    public partial class ChartWebForm : Page
    {
        /// <summary>
        /// The billing controller.
        /// </summary>
        private IEntityController<Billing> billingController;

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
            var dashboard = new Dashboard1();
            this.ASPxDashboardViewer1.DashboardSource = dashboard;
            this.ASPxDashboardViewer1.DataLoading += this.AsPxDashboardViewer1OnDataLoading;
        }

        /// <summary>
        /// The dashboard viewer on data loading.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AsPxDashboardViewer1OnDataLoading(object sender, DataLoadingWebEventArgs e)
        {
            this.billingController = new BillingEntityController();
            var billingList = this.billingController.RefreshEntities();
            e.Data = billingList;
        }
    }
}