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
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

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
        /// The billing.
        /// </summary>
        private Billing billing;

        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        /// <summary>
        /// The billing service.
        /// </summary>
        private BillingService billingService;

        /// <summary>
        /// The billing service entity controller.
        /// </summary>
        private IEntityController<BillingService> billingServiceEntityController;

        /// <summary>
        /// The service.
        /// </summary>
        private Service service;

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
        protected void BtOkClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.service = new Service();
            this.billing = new Billing();
            var myService = Convert.ToInt32(this.serviceComboBox.SelectedItem.Value);
            this.service = this.serviceEntityController.GetEntity(myService);
            var myBilling = Convert.ToInt32(this.billingComboBox.SelectedItem.Value);
            this.billing = this.billingEntityController.GetEntity(myBilling);
            if (this.idTextBox.Text == string.Empty)
            {
                this.idTextBox.Text = "0";
            }


            this.billingService = new BillingService
                                      {
                                          Id = Convert.ToInt32(this.idTextBox.Text),
                                          ServiceId = this.service.Id,
                                          Billing = this.billing,
                                          Price = Convert.ToDouble(this.priceTextBox.Text),
                                          Quantity = Convert.ToInt32(this.quantityTextBox.Text),
                                      };
            try
            {
                this.billing = this.billingEntityController.GetEntity(myBilling);
                this.billingService = new BillingService
                {
                    Id = Convert.ToInt32(this.idTextBox.Text),
                    ServiceId = this.service.Id,
                    BillingId = this.billing.Id,
                    Price = Convert.ToDouble(this.priceTextBox.Text),
                    Quantity = Convert.ToInt32(this.quantityTextBox.Text),
                };

                this.billingServiceEntityController.CreateOrUpdateEntity(this.billingService);
                this.BillingServiceListGridView.DataSource = this.billingServiceEntityController.RefreshEntities();
                this.BillingServiceListGridView.DataBind();
                this.quantityTextBox.Text = string.Empty;
                this.idTextBox.Text = string.Empty;
                this.priceTextBox.Text = string.Empty;
            }
            catch (SqlException ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Something went wrong with the database.Please check the connection string.";
                }
            }
            catch (ArgumentNullException ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Couldn't create the current Billing";
                }
            }

        }

        /// <summary>
        /// The unnamed 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteBillingButtonClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.BillingServiceListGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no companies to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys =
                    this.BillingServiceListGridView.GetSelectedFieldValues(
                        this.BillingServiceListGridView.KeyFieldName,
                        "Id");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a billing service first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var myBillingService = new BillingService { Id = id };
                    try
                    {
                        this.billingServiceEntityController.DeleteEntity(myBillingService);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{myBillingService.Id}', ";
                        this.BillingServiceListGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException ex)
                    {
                        return;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.BillingServiceListGridView.DataSource = this.billingServiceEntityController.RefreshEntities();
                this.BillingServiceListGridView.DataBind();
            }
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
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.serviceEntityController = new ServiceController();
            this.billingEntityController = new BillingEntityController();
            this.billingServiceEntityController = new BillingServiceEntityController();
            try
            {
                this.BillingServiceListGridView.DataSource = this.billingServiceEntityController.RefreshEntities();
                this.BillingServiceListGridView.DataBind();
                this.billingComboBox.DataSource = this.billingEntityController.RefreshEntities();
                this.billingComboBox.SelectedIndex = 0;
                this.billingComboBox.DataBind();
                this.serviceComboBox.DataSource = this.serviceEntityController.RefreshEntities();
                this.serviceComboBox.SelectedIndex = 0;
                this.serviceComboBox.DataBind();
            }
            catch (SqlException ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Something went wrong with the database.Please check the connection string.";
                }
            }
            catch (ArgumentNullException ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Couldn't create the current Billing";
                }
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
        }

        /// <summary>
        /// The billing service list grid view on custom button callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BillingServiceListGridViewOnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.billingServiceEntityController = new BillingServiceEntityController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.BillingServiceListGridView.GetRow(gridviewIndex) as BillingService;
            if (row != null)
            {
                try
                {
                    var myBillingService = this.billingServiceEntityController.GetEntity(row.Id);
                    this.BillingServiceListGridView.JSProperties["cp_text"] = myBillingService.Quantity;
                    this.BillingServiceListGridView.JSProperties["cp_text1"] = myBillingService.Price;
                    this.BillingServiceListGridView.JSProperties["cp_text2"] = myBillingService.BillingId;
                    this.BillingServiceListGridView.JSProperties["cp_text3"] = myBillingService.ServiceId;
                    this.BillingServiceListGridView.JSProperties["cp_text4"] = myBillingService.Id;
                }
                catch (SqlException ex)
                {
                    if (errorlabel != null)
                    {
                        errorlabel.Text = "Something went wrong with the database.Please check the connection string.";
                    }
                }
                catch (ArgumentNullException ex)
                {
                    if (errorlabel != null)
                    {
                        errorlabel.Text = "Couldn't create the current Billing";
                    }
                }
            }
        }
    }
}