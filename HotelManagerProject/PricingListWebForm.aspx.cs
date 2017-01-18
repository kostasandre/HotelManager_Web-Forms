// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list web form.
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
    /// The pricing list web form.
    /// </summary>
    public partial class PricingListWebForm : Page
    {
        /// <summary>
        /// The pricing list controller.
        /// </summary>
        private IEntityController<PricingList> pricingListController;

        /// <summary>
        /// The page_ initialize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.pricingListController = new PricingListController();
            this.PricingListGridView.DataSource = this.pricingListController.RefreshEntities();
            this.PricingListGridView.DataBind();
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