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
    using System.Linq;
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

            //this.typeOFRadioButtonList.DataSource = typeof(TypeOfBillableEntity).GetEnumValues();
            //this.typeOFRadioButtonList.DataBind();

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

        protected void btOK_OnClick(object sender, EventArgs e)
        {
            this.pricingList = new PricingList();
            this.pricingListController = new PricingListController();
            this.pricingList.TypeOfBillableEntity = (TypeOfBillableEntity)Enum.Parse(typeof(TypeOfBillableEntity) , this.typeOFRadioButtonList.SelectedItem.Text);
            if (this.typeOFRadioButtonList.SelectedItem.Value == "RoomType")
            {
                var roomTypeList = this.roomTypeComboBox.DataSource as List<RoomType>;
                if (roomTypeList != null)
                {
                    var roomTypeTemp =
                        roomTypeList.SingleOrDefault(x => x.Id == Convert.ToInt32(this.roomTypeComboBox.SelectedItem.Value));
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
            this.Page.Response.Redirect(this.Page.Request.Url.ToString() , true);
        }
    }
}