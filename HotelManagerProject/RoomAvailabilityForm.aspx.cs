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
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Models;

    #endregion

    /// <summary>
    /// The room availability form.
    /// </summary>
    public partial class RoomAvailabilityForm : Page
    {
        /// <summary>
        /// The calendar list.
        /// </summary>
        private List<BookingCalendar> calendarList;

        /// <summary>
        /// The room availability controller.
        /// </summary>
        private RoomAvailabilityController roomAvailabilityController;

        /// <summary>
        /// The de_ initialization.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void de_Init(object sender, EventArgs e)
        {
            this.de.Date = DateTime.Today;
        }

        /// <summary>
        /// The on date changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void OnDateChanged(object sender, EventArgs e)
        {
            this.DrawAvailableRooms(this.de.Date);
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
                this.DrawAvailableRooms(DateTime.Now);
                this.availableRooms.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
            }
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
        /// Range exception
        /// </exception>
        private void AvailableRoomsOnHtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            AvailableStatus status;
            if ((e.DataColumn.FieldName != "RoomId") && Enum.TryParse(e.CellValue.ToString(), out status))
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
        /// <param name="date">
        /// The date.
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
    }
}