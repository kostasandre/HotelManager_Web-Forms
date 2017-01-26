// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomAvailabilityForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The room availability form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The room availability form.
    /// </summary>
    public partial class RoomAvailabilityForm : Page
    {
        /// <summary>
        /// The booking controller.
        /// </summary>
        private BookingController bookingController;

        /// <summary>
        /// The calendar list.
        /// </summary>
        private List<BookingCalendar> calendarList;

        /// <summary>
        /// The room controller.
        /// </summary>
        private RoomController roomController;

        private RoomAvailabilityController roomAvailabilityController;

        /// <summary>
        /// The current month text box_ on init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void CurrentMonthTextBox_OnInit(object sender, EventArgs e)
        {
            //this.CurrentMonthTextBox.Text = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The next month button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void NextMonthButton_OnClick(object sender, EventArgs e)
        {
            //var currentMonth =
            //    DateTime.ParseExact(this.CurrentMonthTextBox.Text, "MMMM", CultureInfo.InvariantCulture).Month;
            //var nextMonth = currentMonth + 1;
            //if (nextMonth > 12)
            //{
            //    nextMonth = 1;
            //}

            //this.CurrentMonthTextBox.Text = new DateTime(2010, nextMonth, 1).ToString(
            //    "MMMM",
            //    CultureInfo.InvariantCulture);
            //this.DrawAvailableRooms(nextMonth);
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
            if (!this.Page.IsPostBack)
            {
                var test = this.de.Value;
                var test1 = this.de.Text;
                var test2 = this.de.Date;
                //ASPxDateEdit date = this.FindControl("de") as ASPxDateEdit;
                //var dateValue = date.Value;
                this.DrawAvailableRooms(DateTime.Now);
                this.availableRooms.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
        }

        /// <summary>
        /// The previous month button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void PreviousMonthButton_OnClick(object sender, EventArgs e)
        {
            //var currentMonth =
            //    DateTime.ParseExact(this.CurrentMonthTextBox.Text, "MMMM", CultureInfo.InvariantCulture).Month;
            //var previousMonth = currentMonth - 1;
            //if (previousMonth < 1)
            //{
            //    previousMonth = 12;
            //}

            //this.CurrentMonthTextBox.Text = new DateTime(2010, previousMonth, 1).ToString(
            //    "MMMM",
            //    CultureInfo.InvariantCulture);
            //this.DrawAvailableRooms(previousMonth);
        }

        /// <summary>
        /// The available rooms on html data cell prepared.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        private void AvailableRoomsOnHtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            AvailableStatus status;
            if (e.DataColumn.FieldName != "RoomId" && Enum.TryParse(e.CellValue.ToString(), out status))
            {
                e.Cell.Text = string.Empty;
                switch (status)
                {
                    case AvailableStatus.Available:
                        e.Cell.BackColor = Color.Green;
                        break;
                    case AvailableStatus.NotAvailable:
                        e.Cell.BackColor = Color.Yellow;
                        break;
                    case AvailableStatus.NotAvailableOccupied:
                        e.Cell.BackColor = Color.Red;
                        break;
                    case AvailableStatus.NotAvailableBilled:
                        e.Cell.BackColor = Color.Blue;
                        break;
                    case AvailableStatus.NotExistingDay:
                        e.Cell.BackColor = Color.Gray;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// The Draw Available rooms.
        /// </summary>
        /// <param name="month">
        /// The month.
        /// </param>
        private void DrawAvailableRooms(DateTime date)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.roomAvailabilityController = new RoomAvailabilityController();

            try
            {
               this.calendarList = this.roomAvailabilityController.BookingCalendar(date);
            }
            catch (Exception ex)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = ex.Message;
                }
            }

            this.availableRooms.DataSource = this.calendarList;
            this.availableRooms.DataBind();
            this.availableRooms.HtmlDataCellPrepared += this.AvailableRoomsOnHtmlDataCellPrepared;
        }

        protected void de_Init(object sender, EventArgs e)
        {
            de.Date = DateTime.Today;
        }

        protected void OnDateChanged(object sender, EventArgs e)
        {

            this.DrawAvailableRooms(this.de.Date);
        }
    }
}