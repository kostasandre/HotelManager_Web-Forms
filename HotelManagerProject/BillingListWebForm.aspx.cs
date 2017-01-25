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
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

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

        /// <summary>
        /// The booking.
        /// </summary>
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
        protected void BtOkClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.billingEntityController = new BillingEntityController();
            this.bookingEntityController = new BookingController();
            this.booking = new Booking();
            var myBooking = Convert.ToInt32(this.bookingComboBox.SelectedItem.Value);
           
            try
            {
                this.booking = this.bookingEntityController.GetEntity(myBooking);
                this.billing = new Billing
                {
                    Id = Convert.ToInt32(this.idTextBox.Text),
                    BookingId = this.booking.Id,
                    Paid = this.paidCheckBox.Checked,
                    PriceForRoom = Convert.ToDouble(this.priceForRoomTextBox.Text),
                    PriceForServices = Convert.ToDouble(this.priceForServicesTextBox.Text),
                    TotalPrice = Convert.ToDouble(this.totalPricerTextBox.Text)
                };
                
                this.billingEntityController.CreateOrUpdateEntity(this.billing);
                this.BillingListGridView.DataSource = this.billingEntityController.RefreshEntities();
                this.BillingListGridView.DataBind();
                this.paidCheckBox.Text = string.Empty;
                this.priceForRoomTextBox.Text = string.Empty;
                this.totalPricerTextBox.Text = string.Empty;
                this.priceForServicesTextBox.Text = string.Empty;
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
            this.bookingComboBox.Value = "Customer.Name";
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
                if (this.BillingListGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no companies to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.BillingListGridView.GetSelectedFieldValues(
                    this.BillingListGridView.KeyFieldName,
                    "Id");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a billing first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var myBilling = new Billing { Id = id };
                    try
                    {
                        this.billingEntityController.DeleteEntity(myBilling);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{myBilling.Id}', ";
                        this.BillingListGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException ex)
                    {
                        return;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.BillingListGridView.DataSource = this.billingEntityController.RefreshEntities();
                this.BillingListGridView.DataBind();
            }
        }

        /// <summary>
        /// The billing list grid view_ on custom button callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BillingListGridView_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.billingEntityController = new BillingEntityController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.BillingListGridView.GetRow(gridviewIndex) as Billing;
            if (row != null)
            {
                
                var myBilling = this.billingEntityController.GetEntity(row.Id);
                this.BillingListGridView.JSProperties["cp_text"] = myBilling.Paid;
                this.BillingListGridView.JSProperties["cp_text1"] = myBilling.PriceForServices;
                this.BillingListGridView.JSProperties["cp_text2"] = myBilling.PriceForRoom;
                this.BillingListGridView.JSProperties["cp_text3"] = myBilling.TotalPrice;
                this.BillingListGridView.JSProperties["cp_text4"] = row.Id;
            }
        }
    }
}