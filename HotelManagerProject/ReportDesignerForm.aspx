<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportDesignerForm.aspx.cs" Inherits="HotelManagerProject.ReportDesignerForm" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraReports.Web" Assembly="DevExpress.XtraReports.v16.2.Web, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <dx:ASPxReportDesigner ID="ASPxReportDesigner" runat="server"></dx:ASPxReportDesigner>

    </div>
    </form>
</body>
</html>
