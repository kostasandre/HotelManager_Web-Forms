<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChartWebForm.aspx.cs" Inherits="HotelManagerProject.ChartWebForm" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.DashboardWeb" Assembly="DevExpress.Dashboard.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <%--<dx:ASPxDashboard ID=ASPxDashboard1 runat="server" Width="100%" Height="100%" ></dx:ASPxDashboard> <%--DashboardStorageFolder="~/App_Data/Dashboards"--%>
        <dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" Height="750px" Width="100%" FullscreenMode="False">
        </dx:ASPxDashboardViewer>
        <%--<dx:ASPxDashboard ID=ASPxDashboard1 runat="server" DashboardStorageFolder="~/App_Data" Height="600px" Width="80%"></dx:ASPxDashboard>--%>
    </div>
</asp:Content>
