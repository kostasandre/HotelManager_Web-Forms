// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceWebForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The service web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Web.UI;

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
        /// The service controller.
        /// </summary>
        private IEntityController<Service> serviceController;

        private Service service;

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
        }

        protected void btOK_OnClick(object sender, EventArgs e)
        {
            this.service = new Service();
            this.serviceController = new ServiceController();
            this.service.Code = this.codeTextBox.Text;
            this.service.Description = this.descriptionTextBox.Text;
            this.serviceController.CreateOrUpdateEntity(this.service);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString() , true);
        }
    }
}