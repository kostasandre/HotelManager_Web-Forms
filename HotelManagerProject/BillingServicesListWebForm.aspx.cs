// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingServicesListWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The billing services list form.
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
    /// The billing services list form.
    /// </summary>
    public partial class BillingServicesListForm : Page
    {
        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        /// <summary>
        /// The billing service entity controller.
        /// </summary>
        private IEntityController<BillingService> billingServiceEntityController;

        /// <summary>
        /// The service.
        /// </summary>
        private Service service;

        private Billing billing;

        private BillingService billingService;

        /// <summary>
        /// The service entity controller.
        /// </summary>
        private IEntityController<Service> serviceEntityController;

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
            this.service = new Service();
            this.billing = new Billing();
            var myService = Convert.ToInt32(this.serviceComboBox.SelectedItem.Value);
            this.service = this.serviceEntityController.GetEntity(myService);
            var myBilling = Convert.ToInt32(this.billingComboBox.SelectedItem.Value);
            this.billing = this.billingEntityController.GetEntity(myBilling);

            this.billingService = new BillingService
            {
               
                Service = this.service,
                ServiceId = this.service.Id,
                Billing = this.billing,
                Price = Convert.ToDouble(this.priceTextBox.Text),
                Quantity = Convert.ToInt32(this.quantityTextBox.Text),
              };
            this.billingServiceEntityController.CreateOrUpdateEntity(this.billingService);
            this.BillingServiceListGridView.DataSource = this.billingServiceEntityController.RefreshEntities();
            this.BillingServiceListGridView.DataBind();
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
            this.serviceEntityController = new ServiceController();
            this.billingEntityController = new BillingEntityController();
            this.billingServiceEntityController = new BillingServiceEntityController();
            this.BillingServiceListGridView.DataSource = this.billingServiceEntityController.RefreshEntities();
            this.BillingServiceListGridView.DataBind();
            this.billingComboBox.DataSource = this.billingEntityController.RefreshEntities();
            this.billingComboBox.DataBind();
            this.serviceComboBox.DataSource = this.serviceEntityController.RefreshEntities();
            this.serviceComboBox.DataBind();
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