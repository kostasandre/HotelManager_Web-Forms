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
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Utils;
    using DevExpress.Web;
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

        /// <summary>
        /// The hotel.
        /// </summary>
        private Hotel hotel;

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
        protected void Page_Load(object sender , EventArgs e)
        {

        }

        /// <summary>
        /// The bt o k_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            this.hotelController = new HotelController();
            //this.hotel = new Hotel();
            try
            {
                this.hotel = new Hotel()
                                 {
                                     Id = Convert.ToInt32(this.idTextBox.Text),
                                     Name = this.nameTextBox.Text,
                                     Address = this.addressTextBox.Text,
                                     Manager = this.managerTextBox.Text,
                                     Email = this.emailTextBox.Text,
                                     Phone = this.phoneTextBox.Text,
                                     TaxId = this.taxIdSpinEdit.Text
                };

                this.hotelController.CreateOrUpdateEntity(this.hotel);
                this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
                this.HotelGridView.DataBind();
            }
            catch (SqlException exp)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Something went wrong with the database.Please check the connection string.";
                }
            }
            catch (ArgumentNullException exp)
            {
                if (errorlabel != null)
                {
                    errorlabel.Text = "Couldn't create the current Hotel";
                }
            }
        }

        /// <summary>
        /// The delete hotel button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeleteHotelButtonClick(object sender, EventArgs e)
        {
            this.hotelController = new HotelController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.HotelGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There are no Hotels to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.HotelGridView.GetSelectedFieldValues(this.HotelGridView.KeyFieldName, "Name");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Hotel first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var hotelName = row[1].ToString();
                    var hotelTemp = new Hotel() { Id = id };
                    try
                    {
                        this.hotelController.DeleteEntity(hotelTemp);
                        this.deleteHotelButton.ClientSideEvents.Click = "function(s,e){ sessionStorage.removeItem('Hotel'); sessionStorage.removeItem('tempHotelName'); e.processOnServer = true; }";
                        this.Session["Hotel"] = null;
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $"'{hotelTemp.Name}',";
                        this.HotelGridView.Selection.UnselectRowByKey(id);

                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }
                    catch (Exception exp)
                    {
                        errorlabel.Text = $"First you shoud delete the Rooms and Services which belongs to this Hotel!";
                    }

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
                    this.HotelGridView.DataBind();
                }
            }
        }

        /// <summary>
        /// The hotel grid view_ on custom button callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void HotelGridView_OnCustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.hotelController = new HotelController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.HotelGridView.GetRow(gridviewIndex) as Hotel;
            if (row != null)
            {
                var myHotel = this.hotelController.GetEntity(row.Id);
                this.HotelGridView.JSProperties["cp_text1"] = myHotel.Id;
                this.HotelGridView.JSProperties["cp_text2"] = myHotel.Name;
                this.HotelGridView.JSProperties["cp_text3"] = myHotel.Address;
                this.HotelGridView.JSProperties["cp_text4"] = myHotel.Manager;
                this.HotelGridView.JSProperties["cp_text5"] = myHotel.Email;
                this.HotelGridView.JSProperties["cp_text6"] = myHotel.Phone;
                this.HotelGridView.JSProperties["cp_text7"] = myHotel.TaxId;
            }
        }

        /// <summary>
        /// The select hotel as px button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void SelectHotelAsPxButtonClick(object sender , EventArgs e)
        {
            this.hotelController = new HotelController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.HotelGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There is no Hotel selected";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys = this.HotelGridView.GetSelectedFieldValues(this.HotelGridView.KeyFieldName , "Name");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Hotel first";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    
                    try
                    {
                        var localHotel = this.hotelController.GetEntity(id);
                        this.Session["Hotel"] = localHotel;
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"Please select a Hotel first ";
                            firstRun = false;
                        }
                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }
                    catch (Exception exp)
                    {
                        errorlabel.Text = exp.Message;
                    }
                    
                    this.Session["errorMessage"] = errorlabel.Text;
                    
                }
            }
        }
    }
}