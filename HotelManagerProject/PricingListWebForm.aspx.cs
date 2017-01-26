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
    using System.Globalization;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DevExpress.Web;
    using DevExpress.XtraPrinting.Native;

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
        private PricingListController pricingListController;

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
        protected void Page_Init(object sender , EventArgs e)
        {
            this.pricingListController = new PricingListController();
            this.roomTypeController = new RoomTypeController();
            this.serviceController = new ServiceController();

            this.RefreshPricingListEntityWithCodeInside();

            this.typeOFRadioButtonList.DataSource = typeof(TypeOfBillableEntity).GetEnumValues();
            this.typeOFRadioButtonList.DataBind();

            var roomTypeList = this.roomTypeController.RefreshEntities();
            this.roomTypeComboBox.DataSource = roomTypeList;
            this.roomTypeComboBox.DataBind();
            this.roomTypeLabel.ClientVisible = false;
            this.roomTypeComboBox.ClientVisible = false;

            var serviceList = this.serviceController.RefreshEntities();
            this.serviceComboBox.DataSource = serviceList;
            this.serviceComboBox.DataBind();
            this.serviceLabel.ClientVisible = false;
            this.serviceComboBox.ClientVisible = false;
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
        /// The type of radio button list_ on selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void TypeOFRadioButtonList_OnSelectedIndexChanged(object sender , EventArgs e)
        {
            this.DisplayBillableServiceControl(this.typeOFRadioButtonList.SelectedItem.Value.ToString());
        }

        private void DisplayBillableServiceControl(string billableServiceType)
        {
            if (billableServiceType == "RoomType")
            {
                this.roomTypeLabel.ClientVisible = true;
                this.roomTypeComboBox.ClientVisible = true;
                this.serviceLabel.ClientVisible = false;
                this.serviceComboBox.ClientVisible = false;
            }

            if (billableServiceType == "Service")
            {
                this.roomTypeLabel.ClientVisible = false;
                this.roomTypeComboBox.ClientVisible = false;
                this.serviceLabel.ClientVisible = true;
                this.serviceComboBox.ClientVisible = true;
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
        protected void SaveButton_OnClick(object sender , EventArgs e)
        {
            this.pricingList = new PricingList();
            this.pricingListController = new PricingListController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                this.pricingList.Id = Convert.ToInt32(this.idTextBox.Text);

                if (this.pricingList.Id == 0)
                {
                    this.pricingList.TypeOfBillableEntity =
                        (TypeOfBillableEntity)
                        Enum.Parse(typeof(TypeOfBillableEntity), this.typeOFRadioButtonList.SelectedItem.Text);
                    if (this.typeOFRadioButtonList.SelectedItem.Value.ToString() == "RoomType")
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
                    else if (this.typeOFRadioButtonList.SelectedItem.Value.ToString() == "Service")
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
                }



                this.pricingList.Price = Convert.ToDouble(this.priceSpinEdit.Number);
                this.pricingList.VatPrc = Convert.ToDouble(this.VatPrcSpinEdit.Number);
                this.pricingList.ValidFrom = this.validFromDateEdit.Date;
                this.pricingList.ValidTo = this.validToDateEdit.Date;
                if (this.pricingListController.ValidationDateForPricingList(
                    this.pricingList.ValidFrom,
                    this.pricingList.ValidTo,
                    this.pricingList.TypeOfBillableEntity,
                    this.pricingList.BillableEntityId))
                {
                    this.pricingListController.CreateOrUpdateEntity(this.pricingList);
                    this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
                }
                else
                {
                    this.validToDateEdit.IsValid = false;
                    this.validFromDateEdit.IsValid = false;
                    this.validToDateEdit.ErrorText = "There is allready Pricing List for the period you declared!";
                }
            }

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
        protected void DeletePricingListButton_OnClick(object sender , EventArgs e)
        {
            this.pricingListController = new PricingListController();
            this.roomTypeController = new RoomTypeController();
            this.serviceController = new ServiceController();

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
                    this.PricingListGridView.GetSelectedFieldValues(this.PricingListGridView.KeyFieldName , "Id");
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

                    errorlabel.Text = errorlabel.Text.TrimEnd(' ' , ',');
                    this.Session["errorMessage"] = errorlabel.Text;

                    this.RefreshPricingListEntityWithCodeInside();
                }
            }
        }

        protected void PricingListGridView_OnCustomButtonCallback(object sender , ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.pricingListController = new PricingListController();
            this.roomTypeController = new RoomTypeController();
            this.serviceController = new ServiceController();




            var gridviewIndex = e.VisibleIndex;
            var row = this.PricingListGridView.GetRow(gridviewIndex) as PricingList;
            var myPricingList = this.pricingListController.GetEntity(row.Id);

            if (myPricingList.TypeOfBillableEntity == TypeOfBillableEntity.RoomType)
            {
                var roomTypeTemp =
                    this.roomTypeController.RefreshEntities()
                        .SingleOrDefault(x => x.Id == myPricingList.BillableEntityId) as RoomType;
                myPricingList.BillableEntityCode = roomTypeTemp.Code;
            }
            else
            {
                var serviceTemp =
                    this.serviceController.RefreshEntities()
                        .SingleOrDefault(x => x.Id == myPricingList.BillableEntityId) as Service;
                myPricingList.BillableEntityCode = serviceTemp.Code;
            }

            this.PricingListGridView.JSProperties["cp_text1"] = myPricingList.Id;
            this.PricingListGridView.JSProperties["cp_text2"] = (int)myPricingList.TypeOfBillableEntity;
            this.PricingListGridView.JSProperties["cp_text3"] = myPricingList.BillableEntityCode;
            this.PricingListGridView.JSProperties["cp_text4"] = myPricingList.BillableEntityCode;
            this.PricingListGridView.JSProperties["cp_text5"] = myPricingList.ValidFrom.ToString(CultureInfo.CurrentCulture);
            this.PricingListGridView.JSProperties["cp_text6"] = myPricingList.ValidTo.ToString(CultureInfo.CurrentCulture);
            this.PricingListGridView.JSProperties["cp_text7"] = myPricingList.Price;
            this.PricingListGridView.JSProperties["cp_text8"] = myPricingList.VatPrc;

            if (e.ButtonID == "editButton")
            {
                this.DisplayBillableServiceControl(myPricingList.TypeOfBillableEntity.ToString());
            }
        }

        protected void RefreshPricingListEntityWithCodeInside()
        {
            var pricingListList = this.pricingListController.RefreshEntities();
            foreach (var pricingList in pricingListList)
            {
                if (pricingList.TypeOfBillableEntity == TypeOfBillableEntity.RoomType)
                {
                    var roomTypeTemp =
                        this.roomTypeController.RefreshEntities()
                            .SingleOrDefault(x => x.Id == pricingList.BillableEntityId) as RoomType;
                    pricingList.BillableEntityCode = roomTypeTemp.Code;
                }
                else
                {
                    var serviceTemp =
                        this.serviceController.RefreshEntities()
                            .SingleOrDefault(x => x.Id == pricingList.BillableEntityId) as Service;
                    pricingList.BillableEntityCode = serviceTemp.Code;
                }
            }

            this.PricingListGridView.DataSource = pricingListList;
            this.PricingListGridView.DataBind();
        }
    }
}