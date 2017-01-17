using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerProject
{
    using HotelManagerLib.Controllers;
    using HotelManagerLib.Controllers.Interfaces;
    using HotelManagerLib.Models.Persistant;

    public partial class WebForm1 : System.Web.UI.Page
    {
        private IEntityController<RoomType> RoomTypeController;
        protected void Page_Load(object sender , EventArgs e)
        {
            this.RoomTypeController = new RoomTypeController();
            this.RoomTypeController.RefreshEntities();
        }
    }
}