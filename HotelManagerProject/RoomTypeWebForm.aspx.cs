// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomTypeWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room type web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The room type web form.
    /// </summary>
    public partial class RoomTypeWebForm : Page
    {
        /// <summary>
        /// The room type controller.
        /// </summary>
        private IEntityController<RoomType> roomTypeController;

        private RoomType roomType;

        /// <summary>
        /// The initialize
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.roomTypeController = new RoomTypeController();
            this.RoomTypeGridView.DataSource = this.roomTypeController.RefreshEntities();
            this.RoomTypeGridView.DataBind();
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
            this.bedTypeComboBox.Items.AddRange(typeof(BedType).GetEnumValues());
            this.bedTypeComboBox.DataBind();

            this.ViewComboBox.Items.AddRange(typeof(View).GetEnumValues());
            this.ViewComboBox.DataBind();
        }

        protected void btOK_OnClick(object sender, EventArgs e)
        {
            this.roomType = new RoomType();
            this.roomTypeController = new RoomTypeController();
            this.roomType.Code = this.codeTextBox.Text;
            this.roomType.BedType = (BedType)Enum.Parse(typeof(BedType), this.bedTypeComboBox.SelectedItem.Text);
            this.roomType.View = (View)Enum.Parse(typeof(View), this.ViewComboBox.SelectedItem.Text);
            this.roomType.Sauna = this.SaunaCheckBox.Checked;
            this.roomType.Tv = this.TvCheckBox.Checked;
            this.roomType.WiFi = this.WiFiCheckBox.Checked;
            this.roomTypeController.CreateOrUpdateEntity(this.roomType);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);

        }
    }
}