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
            if (!this.Page.IsPostBack)
            {
                this.hotelController = new HotelController();
                this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
                this.HotelGridView.DataBind();
            }
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
            this.hotel = new Hotel();
            this.hotelController = new HotelController();
            this.hotel.Name = this.nameTextBox.Text;
            this.hotel.Address = this.addressTextBox.Text;
            this.hotel.Manager = this.managerTextBox.Text;
            this.hotel.Email = this.emailTextBox.Text;
            this.hotel.Phone = this.phoneTextBox.Text;
            this.hotel.TaxId = this.taxIdSpinEdit.Text;
            this.hotelController.CreateOrUpdateEntity(this.hotel);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);

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

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
                    this.HotelGridView.DataBind();
                }
            }
        }
    }
}