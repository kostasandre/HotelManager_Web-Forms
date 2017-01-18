// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoomWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The room web form.
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
    /// The room web form.
    /// </summary>
    public partial class RoomWebForm : Page
    {
        /// <summary>
        /// The room controller.
        /// </summary>
        private IEntityController<Room> roomController;

        /// <summary>
        /// The page_ initialize
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.roomController = new RoomController();
            this.RoomGridView.DataSource = this.roomController.RefreshEntities();
            this.RoomGridView.DataBind();
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