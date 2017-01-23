// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The hotel web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Web.UI;

    using DevExpress.XtraRichEdit.Model.History;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The hotel web form.
    /// </summary>
    public partial class HotelWebForm : Page
    {
        /// <summary>
        /// The hotel controller.
        /// </summary>
        private IEntityController<Hotel> hotelController;

        private Hotel hotel;

        /// <summary>
        /// The page initialize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.hotelController = new HotelController();
            this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
            this.HotelGridView.DataBind();
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
            this.hotel = new Hotel();
            this.hotelController = new HotelController();
            this.hotel.Name = this.nameTextBox.Text;
            this.hotel.Address = this.addressTextBox.Text;
            this.hotel.Manager = this.managerTextBox.Text;
            this.hotel.Email = this.emailTextBox.Text;
            this.hotel.Phone = this.phoneTextBox.Text;
            this.hotel.TaxId = this.taxIdSpinEdit.Text;
            this.hotelController.CreateOrUpdateEntity(this.hotel);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString() , true);

        }
    }
}