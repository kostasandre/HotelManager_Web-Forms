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
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

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
        /// The hotel controller.
        /// </summary>
        private IEntityController<Hotel> hotelController;

        /// <summary>
        /// The room type controller.
        /// </summary>
        private IEntityController<RoomType> roomTypeController;

        /// <summary>
        /// The room.
        /// </summary>
        private Room room;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.roomController = new RoomController();
            this.hotelController = new HotelController();
            this.roomTypeController = new RoomTypeController();

            this.RoomGridView.DataSource = this.roomController.RefreshEntities();
            this.RoomGridView.DataBind();

            var hotelList = this.hotelController.RefreshEntities();
            this.hotelComboBox.DataSource = hotelList;
            this.hotelComboBox.DataBind();

            var roomTypeList = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypeList;
            this.roomTypeComboBox.DataBind();
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
            //this.roomController = new RoomController();
            //this.hotelController = new HotelController();
            //this.roomTypeController = new RoomTypeController();
            //this.RoomGridView.DataSource = this.roomController.RefreshEntities();
            //this.RoomGridView.DataBind();
            //var hotelList = this.hotelController.RefreshEntities();
            //this.hotelComboBox.DataSource = hotelList;
            //this.hotelComboBox.DataBind();
            //var roomTypeList = this.roomTypeController.RefreshEntities();
            //this.roomTypeComboBox.DataSource = roomTypeList;
            //this.roomTypeComboBox.DataBind();
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

            this.room = new Room();
            this.roomController = new RoomController();

            //var roomId = Convert.ToInt32(this.idTextBox.Text);

            //var room = this.roomController.GetEntity(Convert.ToInt32(roomId));

            this.room.Id = Convert.ToInt32(this.idTextBox.Text);
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

        /// <summary>
        /// The delete room button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteRoomButton_OnClick(object sender, EventArgs e)
        {
            this.roomController = new RoomController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.RoomGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There are no Rooms to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.RoomGridView.GetSelectedFieldValues(this.RoomGridView.KeyFieldName, "Code");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Room first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var roomCode = row[1].ToString();
                    var roomTemp = new Room() { Id = id, Code = roomCode };
                    try
                    {
                        this.roomController.DeleteEntity(roomTemp);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $"'{roomTemp.Code}',";
                        this.RoomGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.RoomGridView.DataSource = this.roomController.RefreshEntities();
                    this.RoomGridView.DataBind();
                }
            }
        }

        protected void RoomGridView_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.roomController = new RoomController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.RoomGridView.GetRow(gridviewIndex) as Room;
            var myRoom = this.roomController.GetEntity(row.Id);
            this.RoomGridView.JSProperties["cp_text1"] = myRoom.Id;
            this.RoomGridView.JSProperties["cp_text2"] = myRoom.Code;
            this.RoomGridView.JSProperties["cp_text3"] = myRoom.HotelName;
            this.RoomGridView.JSProperties["cp_text4"] = myRoom.RoomType.Code;
        }
    }
}