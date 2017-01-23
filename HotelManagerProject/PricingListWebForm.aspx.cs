// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListWebForm.aspx.cs" company="Data Communication">
//   Hotel Manager
// </copyright>
// <summary>
//   The pricing list web form.
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

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The pricing list web form.
    /// </summary>
    public partial class PricingListWebForm : Page
    {
        /// <summary>
        /// The pricing list controller.
        /// </summary>
        private IEntityController<PricingList> pricingListController;

        /// <summary>
        /// The room type controller.
        /// </summary>
        private IEntityController<RoomType> roomTypeController;

        /// <summary>
        /// The service controller.
        /// </summary>
        private IEntityController<Service> serviceController;

        /// <summary>
        /// The pricing list.
        /// </summary>
        private PricingList pricingList;

        /// <summary>
        /// The page_ initialize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.pricingListController = new PricingListController();
            this.PricingListGridView.DataSource = this.pricingListController.RefreshEntities();
            this.PricingListGridView.DataBind();

            this.typeOFRadioButtonList.DataSource = typeof(TypeOfBillableEntity).GetEnumValues();
            this.typeOFRadioButtonList.DataBind();
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
            this.roomTypeController = new RoomTypeController();
            this.serviceController = new ServiceController();

            var roomTypeList = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypeList;
            this.roomTypeComboBox.DataBind();
            this.roomTypeLabel.Visible = false;
            this.roomTypeComboBox.Visible = false;

            var serviceList = this.serviceController.RefreshEntities();
            this.serviceComboBox.DataSource = serviceList;
            this.serviceComboBox.DataBind();
            this.serviceLabel.Visible = false;
            this.serviceComboBox.Visible = false;
        }

        /// <summary>
        /// The type of radio button list_ on selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void TypeOFRadioButtonList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.typeOFRadioButtonList.SelectedItem.Value == "RoomType")
            {
                this.roomTypeLabel.Visible = true;
                this.roomTypeComboBox.Visible = true;
            }

            if (this.typeOFRadioButtonList.SelectedItem.Value == "Service")
            {
                this.serviceLabel.Visible = true;
                this.serviceComboBox.Visible = true;
            }
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
            this.pricingList = new PricingList();
            this.pricingListController = new PricingListController();
            this.pricingList.TypeOfBillableEntity =
                (TypeOfBillableEntity)
                Enum.Parse(typeof(TypeOfBillableEntity), this.typeOFRadioButtonList.SelectedItem.Text);
            if (this.typeOFRadioButtonList.SelectedItem.Value == "RoomType")
            {
                var roomTypeList = this.roomTypeComboBox.DataSource as List<RoomType>;
                if (roomTypeList != null)
                {
                    var roomTypeTemp =
                        roomTypeList.SingleOrDefault(
                            x => x.Id == Convert.ToInt32(this.roomTypeComboBox.SelectedItem.Value));
                    this.pricingList.BillableEntityId = roomTypeTemp.Id;
                }
            }
            else if (this.typeOFRadioButtonList.SelectedItem.Value == "Service")
            {
                var serviceList = this.serviceComboBox.DataSource as List<Service>;
                if (serviceList != null)
                {
                    var serviceTemp =
                        serviceList.SingleOrDefault(
                            x => x.Id == Convert.ToInt32(this.serviceComboBox.SelectedItem.Value));
                    this.pricingList.BillableEntityId = serviceTemp.Id;
                }
            }

            this.pricingList.Price = Convert.ToDouble(this.priceSpinEdit.Number);
            this.pricingList.VatPrc = Convert.ToDouble(this.VatPrcSpinEdit.Number);
            this.pricingList.ValidFrom = this.validFromDateEdit.Date;
            this.pricingList.ValidTo = this.validToDateEdit.Date;
            this.pricingListController.CreateOrUpdateEntity(this.pricingList);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
        }

        /// <summary>
        /// The delete pricing list button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void DeletePricingListButton_OnClick(object sender, EventArgs e)
        {
            this.pricingListController = new PricingListController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.PricingListGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = $"There are no Pricing Lists to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys =
                    this.PricingListGridView.GetSelectedFieldValues(this.PricingListGridView.KeyFieldName, "Id");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a Pricing List first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var pricingListTemp = new PricingList() { Id = id };
                    try
                    {
                        this.pricingListController.DeleteEntity(pricingListTemp);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = $"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $"'{pricingListTemp.Id}',";
                        this.PricingListGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException exp)
                    {
                        errorlabel.Text = $"Sql error: " + exp.Message;
                    }

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                    this.Session["errorMessage"] = errorlabel.Text;
                    this.PricingListGridView.DataSource = this.pricingListController.RefreshEntities();
                    this.PricingListGridView.DataBind();
                }
            }
        }
    }
}