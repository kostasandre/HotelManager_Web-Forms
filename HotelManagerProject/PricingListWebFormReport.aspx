<%@ page title="" language="C#" masterpagefile="~/MasterPage.Master" autoeventwireup="true" codebehind="PricingListWebFormReport.aspx.cs" inherits="HotelManagerProject.PricingListWebFormReport" %>

<%@ register tagprefix="dx" namespace="DevExpress.XtraReports.Web" assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
     <div>
         
         <dx:ASPxWebDocumentViewer ID="ASPxPricingListWebDocumentViewer" runat="server"></dx:ASPxWebDocumentViewer>
            </div>
</asp:content>
