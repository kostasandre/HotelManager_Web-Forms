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
        protected void btOK_Click(object sender, EventArgs e)
        {
            this.billingEntityController = new BillingEntityController();
            this.bookingEntityController = new BookingController();
            this.booking = new Booking();
            var myBooking = Convert.ToInt32(this.bookingComboBox.SelectedItem.Value);
            this.booking = this.bookingEntityController.GetEntity(myBooking);
          
            this.billing = new Billing
                               {
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

        /// <summary>
        /// The unnamed 1_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteBillingButtonClick(object sender , EventArgs e)
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

        protected void createBillingPopUp_OnInit(object sender, EventArgs e)
        {
            
        }
    }
}