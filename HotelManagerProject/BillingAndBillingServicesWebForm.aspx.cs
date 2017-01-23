// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingAndBillingServicesWebForm.aspx.cs" company="">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;
    using DevExpress.Web.Data;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The billing web form.
    /// </summary>
    public partial class BillingWebForm : Page
    {
        /// <summary>
        /// The billing service.
        /// </summary>
        private BillingService billingService;

        /// <summary>
        /// The my billing services.
        /// </summary>
        private List<BillingServiceWithServiceDescription> myBillingServices;

        /// <summary>
        /// The billing service with service description.
        /// </summary>
        private BillingServiceWithServiceDescription billingServiceWithServiceDescription;

        /// <summary>
        /// The price.
        /// </summary>
        private double price;

        /// <summary>
        /// The billing.
        /// </summary>
        private Billing billing;

        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

        /// <summary>
        /// The billing service entity controller.
        /// </summary>
        private IEntityController<BillingService> billingServiceEntityController;

        /// <summary>
        /// The booking entity controller.
        /// </summary>
        private IEntityController<Booking> bookingEntityController;

        /// <summary>
        /// The customer entity controller.
        /// </summary>
        private IEntityController<Customer> customerEntityController;

        /// <summary>
        /// The pricing list entity controller.
        /// </summary>
        private PricingListController pricingListEntityController;

        /// <summary>
        /// The service controller.
        /// </summary>
        private IEntityController<Service> serviceController;

        /// <summary>
        /// The bt ok click.
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
            var selectedRowKeys = this.BookingListGridview.GetSelectedFieldValues(
                this.BookingListGridview.KeyFieldName,
                "Id");
            if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
            {
                return;
            }
            else
            {
                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);

                    this.pricingListEntityController = new PricingListController();
                    this.customerEntityController = new CustomerController();
                    var booking = this.bookingEntityController.GetEntity(id);
                    this.bookingIdTextBox.Text = id.ToString();
                    this.priceValueTextBox.Text = booking.AgreedPrice.ToString(CultureInfo.InvariantCulture);
                    this.customerIdTextBox.Text = this.customerEntityController.GetEntity(booking.CustomerId).Name;
                    this.fromTextBox.Text = booking.From.ToShortDateString().ToString(CultureInfo.InvariantCulture);
                    this.toTextBox.Text = booking.To.ToShortDateString().ToString(CultureInfo.InvariantCulture);

                    this.billing = new Billing { PriceForRoom = booking.AgreedPrice };
                    var servicesList = this.serviceController.RefreshEntities();
                    var billingServices = new List<BillingService>();

                    foreach (var item in servicesList)
                    {
                        try
                        {
                            this.price = this.pricingListEntityController.ServicePricing(booking.From, item.Id);
                        }
                        catch (ArgumentNullException ex)
                        {
                            this.price = 0;
                        }
                        catch (NullReferenceException ex)
                        {
                            this.price = 0;
                        }

                        {
                            var myBillingService = new BillingService
                                                       {
                                                           Service = item,
                                                           Price = this.price,
                                                           Quantity = 0
                                                       };
                            billingServices.Add(myBillingService);
                        }
                    }


                    this.myBillingServices =
                        billingServices.Select(
                            item =>
                                new BillingServiceWithServiceDescription
                                    {
                                        Id = item.Service.Id,
                                        Description = item.Service.Description,
                                        Quantity = item.Quantity,
                                        PricePerUnit = item.Price,
                                        TotalPrice = 0
                                    }).ToList();

                    this.Session["billingServiceWithServiceDescription"] = this.myBillingServices;
                    this.BillingListGridView.DataSource = this.myBillingServices;
                    this.BillingListGridView.DataBind();
                    this.BillingListGridView.Visible = true;
                    this.saveButton.Enabled = true;
                    this.totalSumTextBox.Visible = true;
                    this.totalSumTextBox.Text = this.priceValueTextBox.Text;
                    this.paidCheckBox.Visible = true;
                    this.sumOfServicesTextBox.Visible = true;
                }
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
            if (!this.IsPostBack)
            {
                this.myBillingServices = new List<BillingServiceWithServiceDescription>();
                this.Session["billingServiceWithServiceDescription"] = this.myBillingServices;
                this.BillingListGridView.Visible = false;
            }
            else
            {
                this.myBillingServices =
                    this.Session["billingServiceWithServiceDescription"] as List<BillingServiceWithServiceDescription>;
            }

            this.BillingListGridView.JSProperties["cp_text"] = 0;
            this.BillingListGridView.JSProperties["cp_text2"] = 0;
            this.serviceController = new ServiceController();
            this.bookingEntityController = new BookingController();
            try
            {
                this.BookingListGridview.DataSource = this.bookingEntityController.RefreshEntities();
                this.BookingListGridview.DataBind();
                this.BillingListGridView.DataSource = this.myBillingServices;
                this.BillingListGridView.DataBind();
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
            this.saveButton.Enabled = false;
            this.totalSumTextBox.Visible = false;
            this.paidCheckBox.Visible = false;
            this.sumOfServicesTextBox.Visible = false;
            this.paidLabel.Visible = false;
            this.totalSumLabel.Visible = false;
            this.sumOfServicesLabel.Visible = false;
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
        /// The billing list grid view_ on row updating.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BillingListGridViewOnRowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            this.myBillingServices =
                this.Session["billingServiceWithServiceDescription"] as List<BillingServiceWithServiceDescription>;
            var gridView = (ASPxGridView)sender;
            if (gridView.GetMasterRowKeyValue() == null && this.myBillingServices != null
                && this.myBillingServices.Count != 0)
            {
                var item = this.myBillingServices.SingleOrDefault(x => x.Id == Convert.ToInt32(e.Keys[0]));
                var enumerator = e.NewValues.GetEnumerator();
                enumerator.Reset();
                enumerator.MoveNext();
                if (item != null)
                {
                    item.Description = enumerator.Value.ToString();
                    enumerator.MoveNext();
                    item.Quantity = Convert.ToInt32(enumerator.Value);
                    enumerator.MoveNext();
                    item.PricePerUnit = Convert.ToDouble(enumerator.Value);
                    enumerator.MoveNext();
                    item.TotalPrice = item.PricePerUnit * item.Quantity;
                }

                this.Session["billingServiceWithServiceDescription"] = this.myBillingServices;
                var sumOfServicesPrice = this.myBillingServices.Sum(loaclItem => loaclItem.TotalPrice);
                var totalSum = sumOfServicesPrice + Convert.ToDouble(this.priceValueTextBox.Text);
                gridView.JSProperties["cp_text"] = sumOfServicesPrice.ToString(CultureInfo.InvariantCulture);
                gridView.JSProperties["cp_text2"] = totalSum.ToString(CultureInfo.InvariantCulture);


                this.BillingListGridView.DataSource = this.myBillingServices;
                this.BillingListGridView.DataBind();

                this.paidCheckBox.Checked = true;
            }

            gridView.CancelEdit();
            e.Cancel = true;
        }

        /// <summary>
        /// The save button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void SaveButtonClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.billingEntityController = new BillingEntityController();
            this.billingServiceEntityController = new BillingServiceEntityController();
            if (this.sumOfServicesTextBox.Text == string.Empty)
            {
                this.sumOfServicesTextBox.Text = 0.ToString();
                this.totalSumTextBox.Text = priceValueTextBox.Text;
            }

            this.billing = new Billing
                               {
                                   BookingId = Convert.ToInt32(this.bookingIdTextBox.Text),
                                   PriceForRoom = Convert.ToDouble(this.priceValueTextBox.Text),
                                   PriceForServices = Convert.ToDouble(this.sumOfServicesTextBox.Text),
                                   TotalPrice = Convert.ToDouble(this.totalSumTextBox.Text),
                                   Paid = this.paidCheckBox.Checked
                               };
           
            try
            {
                this.billing = this.billingEntityController.CreateOrUpdateEntity(this.billing);
            }
            catch (SqlException ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Couldn't create the current building";
                }
            }

            this.myBillingServices =
                this.Session["billingServiceWithServiceDescription"] as List<BillingServiceWithServiceDescription>;
            if (this.myBillingServices != null && this.myBillingServices.Count > 0)
            {
                foreach (var item in this.myBillingServices)
                {
                    if (item.Quantity > 0)
                    {
                        this.billingService = new BillingService
                        {
                            BillingId = this.billing.Id,
                            ServiceId = item.Id,
                            Quantity = item.Quantity,
                            Price = item.PricePerUnit
                        };
                        try
                        {
                            this.billingServiceEntityController.CreateOrUpdateEntity(this.billingService);
                        }
                        catch (SqlException ex)
                        {
                            if (errorlabel != null)
                            {
                                errorlabel.Text = "Couldn't create the current billing";
                            }
                        }
                    }
                }
            }

            Server.Transfer("Main.aspx", true);
        }

        /// <summary>
        /// The cancel button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void CancelButtonOnClick(object sender, EventArgs e)
        {
            Server.Transfer("Main.aspx", true);
        }
    }
}