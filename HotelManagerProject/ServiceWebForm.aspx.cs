// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The service web form.
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
    /// The service web form.
    /// </summary>
    public partial class ServiceWebForm : Page
    {
        /// <summary>
        /// The service.
        /// </summary>
        private Service service;

        /// <summary>
        /// The service controller.
        /// </summary>
        private IEntityController<Service> serviceController;

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
            this.serviceController = new ServiceController();
            this.ServiceGridView.DataSource = this.serviceController.RefreshEntities();
            this.ServiceGridView.DataBind();
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
            //if (!this.Page.IsPostBack)
            //{
            //    this.serviceController = new ServiceController();
            //    this.ServiceGridView.DataSource = this.serviceController.RefreshEntities();
            //    this.ServiceGridView.DataBind();
            //}
        }

        /// <summary>
        /// The save button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void SaveButton_OnClick(object sender, EventArgs e)
        {
            this.service = new Service();
            this.serviceController = new ServiceController();
            this.service.Id = Convert.ToInt32(this.idTextBox.Text);
            this.service.Code = this.codeTextBox.Text;
            this.service.Description = this.descriptionTextBox.Text;
            this.serviceController.CreateOrUpdateEntity(this.service);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
        }

        /// <summary>
        /// The delete service button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteServiceButton_OnClick(object sender, EventArgs e)
        {
            this.serviceController = new ServiceController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.ServiceGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There are no Services to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.ServiceGridView.GetSelectedFieldValues(
                    this.ServiceGridView.KeyFieldName,
                    "Code");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Service first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var serviceCode = row[1].ToString();
                    var serviceTemp = new Service() { Id = id, Code = serviceCode };
                    try
                    {
                        this.serviceController.DeleteEntity(serviceTemp);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $"'{serviceTemp.Code}',";
                        this.ServiceGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.ServiceGridView.DataSource = this.serviceController.RefreshEntities();
                    this.ServiceGridView.DataBind();
                }
            }
        }

        protected void ServiceGridView_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.serviceController = new ServiceController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.ServiceGridView.GetRow(gridviewIndex) as Service;
            var myService = this.serviceController.GetEntity(row.Id);
            this.ServiceGridView.JSProperties["cp_text1"] = myService.Id;
            this.ServiceGridView.JSProperties["cp_text2"] = myService.Code;
            this.ServiceGridView.JSProperties["cp_text3"] = myService.Description;
        }
    }
}