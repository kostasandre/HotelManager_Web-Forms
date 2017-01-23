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
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using View = HotelManagerLib.Enums.View;

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
        /// The room type.
        /// </summary>
        private RoomType roomType;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.roomTypeController = new RoomTypeController();
            this.RoomTypeGridView.DataSource = this.roomTypeController.RefreshEntities();
            this.RoomTypeGridView.DataBind();

            this.bedTypeComboBox.Items.AddRange(typeof(BedType).GetEnumValues());
            this.bedTypeComboBox.DataBind();

            this.ViewComboBox.Items.AddRange(typeof(View).GetEnumValues());
            this.ViewComboBox.DataBind();
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
            this.roomType = new RoomType();
            this.roomTypeController = new RoomTypeController();

            this.roomType.Id = Convert.ToInt32(this.idTextBox.Text);




            this.roomType.Code = this.codeTextBox.Text;
            this.roomType.BedType = (BedType)Enum.Parse(typeof(BedType), this.bedTypeComboBox.SelectedItem.Text);
            this.roomType.View = (View)Enum.Parse(typeof(View), this.ViewComboBox.SelectedItem.Text);
            this.roomType.Sauna = this.SaunaCheckBox.Checked;
            this.roomType.Tv = this.TvCheckBox.Checked;
            this.roomType.WiFi = this.WiFiCheckBox.Checked;
            this.roomTypeController.CreateOrUpdateEntity(this.roomType);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
        }

        /// <summary>
        /// The delete room type button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteRoomTypeButton_OnClick(object sender, EventArgs e)
        {
            this.roomTypeController = new RoomTypeController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.RoomTypeGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There are no Room Types to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.RoomTypeGridView.GetSelectedFieldValues(
                    this.RoomTypeGridView.KeyFieldName,
                    "Code");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Room Type first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var roomTypeCode = row[1].ToString();
                    var roomTypeTemp = new RoomType() { Id = id, Code = roomTypeCode };
                    try
                    {
                        this.roomTypeController.DeleteEntity(roomTypeTemp);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $"'{roomTypeTemp.Code}',";
                        this.RoomTypeGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.RoomTypeGridView.DataSource = this.roomTypeController.RefreshEntities();
                    this.RoomTypeGridView.DataBind();
                }
            }
        }

        protected void RoomTypeGridView_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.roomTypeController = new RoomTypeController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.RoomTypeGridView.GetRow(gridviewIndex) as RoomType;
            var myRoomType = this.roomTypeController.GetEntity(row.Id);

            this.RoomTypeGridView.JSProperties["cp_text1"] = myRoomType.Id;
            this.RoomTypeGridView.JSProperties["cp_text2"] = myRoomType.Code;
            this.RoomTypeGridView.JSProperties["cp_text3"] = myRoomType.BedType.ToString();
            this.RoomTypeGridView.JSProperties["cp_text4"] = myRoomType.View.ToString();
            this.RoomTypeGridView.JSProperties["cp_text5"] = myRoomType.Sauna;
            this.RoomTypeGridView.JSProperties["cp_text6"] = myRoomType.Tv;
            this.RoomTypeGridView.JSProperties["cp_text7"] = myRoomType.WiFi;
        }
    }
}