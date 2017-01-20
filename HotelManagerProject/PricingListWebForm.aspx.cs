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
    using System.Web.UI;

    using DevExpress.Data.PLinq;

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

        private IEntityController<RoomType> roomTypeController;

        private IEntityController<Service> serviceController;

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

            this.typeOFRadioButtonList.DataSource = typeof(TypeOfBillableEntity).GetEnumValues();
            this.typeOFRadioButtonList.DataBind();

            //this.RadioButton1.DataItemContainer. = typeof(TypeOfBillableEntity).GetEnumValues();
            //this.RadioButton1.

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

        protected void typeOFRadioButtonList_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            var a = this.typeOFRadioButtonList.SelectedIndex.ToString();
            var b = this.typeOFRadioButtonList.SelectedItem.Selected;
            var c = this.typeOFRadioButtonList.SelectedItem.Text;
            var d = this.typeOFRadioButtonList.SelectedItem.Value;
            var f = this.typeOFRadioButtonList.SelectedItem.Index;
            var g = this.typeOFRadioButtonList.SelectedItem.ValueString;
        }

        protected void typeOFRadioButtonList_OnValueChanged(object sender, EventArgs e)
        {
            var a = this.typeOFRadioButtonList.SelectedIndex.ToString();
            var b = this.typeOFRadioButtonList.SelectedItem.Selected;
            var c = this.typeOFRadioButtonList.SelectedItem.Text;
            var d = this.typeOFRadioButtonList.SelectedItem.Value;
            var f = this.typeOFRadioButtonList.SelectedItem.Index;
            var g = this.typeOFRadioButtonList.SelectedItem.ValueString;
        }
    }
}