using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerProject
{
    using DevExpress.DashboardWeb;

    public partial class ChartWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dashboard = new Dashboard1();
            this.ASPxDashboardViewer1.DashboardSource = dashboard;
            this.ASPxDashboardViewer1.DataLoading += this.AsPxDashboardViewer1OnDataLoading;
        }

        private void AsPxDashboardViewer1OnDataLoading(object sender, DataLoadingWebEventArgs e)
        {
            //var

            //var entityDocumentController = new EntityDocumentController();
            //var documentList = entityDocumentController.RefreshEntities();
        }
    }
}