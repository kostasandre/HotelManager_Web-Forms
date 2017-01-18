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
    using System.Web.UI;

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
        /// The page initialize.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.hotelController = new HotelController();
            this.HotelGridView.DataSource = this.hotelController.RefreshEntities();
            this.HotelGridView.DataBind();

            //var controller = new PricingListController();
            //var datefrom = Convert.ToDateTime("25/05/2017");
            //var dateto = Convert.ToDateTime("05/06/2017");
            //var sum = controller.RoomPricing(datefrom, dateto, 2);

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
    }
}