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
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Enums;
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

        private HotelController hotelController;

        /// <summary>
        /// The bookings grid view_ on custom button callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void bookingsGridView_OnCustomButtonCallback(
            object sender,
            ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.bookingController = new BookingController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.bookingsGridView.GetRow(gridviewIndex) as Booking;
            var booking = this.bookingController.GetEntity(row.Id);
            this.bookingsGridView.JSProperties["cp_text"] = booking.Status.ToString();
            this.bookingsGridView.JSProperties["cp_text1"] = booking.Comments;
            this.bookingsGridView.JSProperties["cp_text2"] = Convert.ToString(booking.From);
            this.bookingsGridView.JSProperties["cp_text3"] = Convert.ToString(booking.To);
            this.bookingsGridView.JSProperties["cp_text4"] = Convert.ToString(booking.SystemPrice);
            this.bookingsGridView.JSProperties["cp_text5"] = Convert.ToString(booking.AgreedPrice);
            this.bookingsGridView.JSProperties["cp_text6"] = booking.Created.ToString();
            this.bookingsGridView.JSProperties["cp_text7"] = booking.CreatedBy;
            this.bookingsGridView.JSProperties["cp_text8"] = booking.Id.ToString();
            this.bookingsGridView.JSProperties["cp_text9"] = booking.Room.Code;
            this.bookingsGridView.JSProperties["cp_text10"] = booking.Customer.Name;
            this.bookingsGridView.JSProperties["cp_text11"] = booking.Customer.Surname;

        }

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
            var hotel = this.Session["Hotel"] as Hotel;
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
                    catch (Exception ex)
                    {
                        errorlabel.Text = ex.Message;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.bookingsGridView.DataSource = hotel != null
                                                       ? this.bookingController.RefreshEntities()
                                                           .Where(x => x.Room.HotelId == hotel.Id)
                                                           .OrderByDescending(x => x.Created)
                                                       : this.bookingController.RefreshEntities()
                                                           .OrderByDescending(x => x.Created);
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
            this.hotelController = new HotelController();
            var hotel = this.Session["Hotel"] as Hotel;
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            try
            {
                //var hotel = this.hotelController.GetEntity(Convert.ToInt32(hotelId));
                var bookingsList = this.bookingController.RefreshEntities();
                this.bookingsGridView.DataSource = hotel != null ? bookingsList.Where(x => x.Room.HotelId == hotel.Id).OrderByDescending(x => x.Created) : bookingsList.OrderByDescending(x => x.Created);
                
                this.bookingsGridView.DataBind();
            }
            catch (Exception ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = ex.Message;
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
            var names = Enum.GetNames(typeof(Status));
            this.statusComboBox.DataSource = names;
            this.statusComboBox.DataBind();
        }

        /// <summary>
        /// The save_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Save_OnClick(object sender, EventArgs e)
        {
            this.bookingController = new BookingController();

            var bookingId = this.iDtextBox.Text;
            var booking = this.bookingController.GetEntity(Convert.ToInt32(bookingId));
            booking.AgreedPrice = Convert.ToDouble(this.agreedPriceTextBox.Text);
            booking.SystemPrice = Convert.ToDouble(this.systemPriceTextBox.Text);
            booking.Comments = this.commentsTextBox.Text;
            booking.Status = (Status)this.statusComboBox.SelectedIndex;
            booking.Updated = DateTime.Now;
            booking.UpdatedBy = Environment.UserName;

            try
            {
                this.bookingController.CreateOrUpdateEntity(booking);
                this.Response.Redirect("BookingsListForm.aspx");
            }
            catch (Exception ex)
            {
            }
        }
    }
}