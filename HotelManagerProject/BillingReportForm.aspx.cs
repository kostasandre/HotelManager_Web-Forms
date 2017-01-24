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
    using System.IO;
    using System.Web.UI;

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
        private Billing billing;

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
            if (!this.IsPostBack)
            {
                this.billingEntityController = new BillingEntityController();
                var report = new BillingsReport { DataSource = this.billingEntityController.RefreshEntities() };
                this.ASPxBillingWebDocumentViewer.OpenReport(report);
                //var test = this.Request.QueryString["Type"];

                //if (test == "Company")
                //{
                //    this.Session["ChosenFild"] = "Company";
                //    var report = new XtraReport1();
                //    var entityCompanyController = new EntityCompanyController(new VatCalculation());
                //    var companyList = this.Session["SearchedCompanyList"];
                //    var layout = this.Session["Layout"];
                //    if (layout != null)
                //    {
                //        report.LoadLayout((Stream)layout);
                //    }

                //    if (companyList == null)
                //    {
                //        companyList = entityCompanyController.RefreshEntities();
                //    }

                //    report.DataSource = companyList;

                //    this.ASPxWebDocumentViewer1.OpenReport(report);
                //}
                //else if (test == "Document")
                //{
                //    this.Session["ChosenFild"] = "Document";
                //    var report = new XtraDocumentsReport();
                //    var entityDocumentController = new EntityDocumentController();
                //    var layout = this.Session["documentLayout"];
                //    if (layout != null)
                //    {
                //        report.LoadLayout((Stream)layout);
                //    }

                //    var documentsList = entityDocumentController.RefreshEntities();
                //    report.DataSource = documentsList;
                //    this.ASPxWebDocumentViewer1.OpenReport(report);
                //}
            }
        }

        /// <summary>
        /// The edit button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void EditButtonClick(object sender , EventArgs e)
        {

        }
    }
}