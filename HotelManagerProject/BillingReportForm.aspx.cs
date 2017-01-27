// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingReportForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The billing report.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Diagnostics.Eventing.Reader;
    using System.IO;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.XtraReports.UI;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The billing report.
    /// </summary>
    public partial class BillingReport : Page
    {
        /// <summary>
        /// The billing entity controller.
        /// </summary>
        private IEntityController<Billing> billingEntityController;

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
            var hotel = this.Session["Hotel"] as Hotel;
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            
                if (!this.IsPostBack)
                {
                    this.billingEntityController = new BillingEntityController();
                    try
                    {
                        var report = hotel != null ? new BillingsReport { DataSource = this.billingEntityController.RefreshEntities().Where(x => x.Booking.Room.HotelId == hotel.Id) } : new BillingsReport() { DataSource = this.billingEntityController.RefreshEntities() };
                        this.ASPxBillingWebDocumentViewer.OpenReport(report);
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
                    catch (Exception ex)
                    {
                        if (errorlabel != null)
                        {
                            errorlabel.Text = ex.Message;
                        }
                    }
                }
        }
    }
}