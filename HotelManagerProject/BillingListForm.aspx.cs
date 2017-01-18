// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingListForm.aspx.cs" company="">
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
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

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