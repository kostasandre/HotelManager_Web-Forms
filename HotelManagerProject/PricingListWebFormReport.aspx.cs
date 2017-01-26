// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PricingListWebFormReport.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The pricing list web form report.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Enums;
    using HotelManagerLib.Models.Persistant;

    using HotelManagerProject.Reports;

    #endregion

    /// <summary>
    /// The pricing list web form report.
    /// </summary>
    public partial class PricingListWebFormReport : Page
    {
        /// <summary>
        /// The pricing list entity controller.
        /// </summary>
        private IEntityController<PricingList> pricingListEntityController;

        /// <summary>
        /// The room typ entity controller.
        /// </summary>
        private IEntityController<RoomType> roomTypEntityController;

        /// <summary>
        /// The servic entity controller.
        /// </summary>
        private IEntityController<Service> servicEntityController;

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
            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (!this.IsPostBack)
            {
                this.pricingListEntityController = new PricingListController();
                this.roomTypEntityController = new RoomTypeController();
                this.servicEntityController = new ServiceController();
                try
                {
                    var pricingListList = this.pricingListEntityController.RefreshEntities();
                    foreach (var pricingList in pricingListList)
                    {
                        if (pricingList.TypeOfBillableEntity == TypeOfBillableEntity.RoomType)
                        {
                            var roomTypeTemp =
                                this.roomTypEntityController.RefreshEntities()
                                    .SingleOrDefault(x => x.Id == pricingList.BillableEntityId) as RoomType;
                            if (roomTypeTemp != null)
                            {
                                pricingList.BillableEntityCode = roomTypeTemp.Code;
                            }
                        }
                        else
                        {
                            var serviceTemp =
                                this.servicEntityController.RefreshEntities()
                                    .SingleOrDefault(x => x.Id == pricingList.BillableEntityId) as Service;
                            if (serviceTemp != null)
                            {
                                pricingList.BillableEntityCode = serviceTemp.Code;
                            }
                        }
                    }

                    var report = new PricingListReport { DataSource = pricingListList };
                    this.ASPxPricingListWebDocumentViewer.OpenReport(report);
                }
                catch (SqlException ex)
                {
                    if (errorlabel != null)
                    {
                        errorlabel.Text = ex.Message;
                    }
                }
                catch (ArgumentNullException ex)
                {
                    if (errorlabel != null)
                    {
                        errorlabel.Text = "Couldn't create the current Billing";
                    }
                }
                catch (Exception ex)
                {
                    if (errorlabel != null)
                    {
                        errorlabel.Text = ex.Message;
                    }
                }
            }
        }
    }
}