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
    using System.Web.UI;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
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
        }
    }
}