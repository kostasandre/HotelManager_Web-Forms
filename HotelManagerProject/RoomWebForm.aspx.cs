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
    using System.Collections.Generic;
    using System.Linq;
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

        private IEntityController<Hotel> hotelController;

        private IEntityController<RoomType> roomTypeController;

        private Room room;

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
            this.hotelController = new HotelController();
            this.roomTypeController = new RoomTypeController();
            var hotelList = this.hotelController.RefreshEntities();
            this.hotelComboBox.DataSource = hotelList;
            this.hotelComboBox.DataBind();
            var roomTypeList = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypeList;
            this.roomTypeComboBox.DataBind();

        }

        protected void btOK_OnClick(object sender, EventArgs e)
        {
            this.room = new Room();
            this.roomController = new RoomController();
            this.room.Code = this.codeTextBox.Text;

            var hotelList = this.hotelComboBox.DataSource as List<Hotel>;
            if (hotelList != null)
            {
                var hotelTemp =
                    hotelList.SingleOrDefault(x => x.Id == Convert.ToInt32(this.hotelComboBox.SelectedItem.Value));
                this.room.HotelId = hotelTemp.Id;
                
            }

            var roomTypeList = this.roomTypeComboBox.DataSource as List<RoomType>;
            if (roomTypeList != null)
            {
                var roomTypeTemp =
                    roomTypeList.SingleOrDefault(x => x.Id == Convert.ToInt32(this.roomTypeComboBox.SelectedItem.Value));
                this.room.RoomTypeId = roomTypeTemp.Id;
            }

            this.roomController.CreateOrUpdateEntity(this.room);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString() , true);
        }
    }
}