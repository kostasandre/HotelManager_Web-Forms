// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BookingsListForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The bookings list form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Utils;
    using DevExpress.Web;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The bookings list form.
    /// </summary>
    public partial class BookingsListForm : Page
    {
        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The customer controller.
        /// </summary>
        private CustomerController customerController;

        /// <summary>
        /// The create booking button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void createBookingButton_OnClick(object sender, EventArgs e)
        {
            this.Response.Redirect("BookingForm.aspx");
        }

        /// <summary>
        /// The delete booking button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void deleteBookingButton_OnClick(object sender, EventArgs e)
        {
            this.bookingController = new BookingController();
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.bookingsGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no bookings to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.bookingsGridView.GetSelectedFieldValues(
                    this.bookingsGridView.KeyFieldName,
                    "Id");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a bookings first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var myBooking = new Booking { Id = id };
                    try
                    {
                        this.bookingController.DeleteEntity(myBooking);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{myBooking.Id}', ";
                        this.bookingsGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException ex)
                    {
                        return;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.bookingsGridView.DataSource = this.bookingController.RefreshEntities();
                this.bookingsGridView.DataBind();
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
            this.bookingController = new BookingController();
            var bookingsList = this.bookingController.RefreshEntities();
            this.bookingsGridView.DataSource = bookingsList;
            this.bookingsGridView.DataBind();
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

        protected void bookingsGridView_OnCustomButtonCallback(object sender,ASPxGridViewCustomButtonCallbackEventArgs e)
        {

        }
    }

}