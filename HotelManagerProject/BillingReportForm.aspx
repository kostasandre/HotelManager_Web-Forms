<%@ page title="" language="C#" masterpagefile="~/MasterPage.Master" autoeventwireup="true" codebehind="BillingReportForm.aspx.cs" inherits="HotelManagerProject.BillingReport" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
     <div>
         <div>
                <dx:ASPxButton CssClass="editButtonClass" ID="editButton" runat="server" Text="Edit Report"/>  
            </div>
         <dx:ASPxWebDocumentViewer ID="ASPxBillingWebDocumentViewer" runat="server"></dx:ASPxWebDocumentViewer>
            </div>
</asp:content>
