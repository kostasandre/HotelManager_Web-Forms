<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomAvailabilityForm.aspx.cs" Inherits="HotelManagerProject.RoomAvailabilityForm" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraScheduler" Assembly="DevExpress.XtraScheduler.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <script type="text/javascript">
        function OnInit(s, e) {
            var calendar = s.GetCalendar();
            calendar.owner = s;
            calendar.GetMainElement().style.opacity = '0';
        }

        function OnDropDown(s, e) {
            var calendar = s.GetCalendar();
            var fastNav = calendar.fastNavigation;
            fastNav.activeView = calendar.GetView(0, 0);
            fastNav.Prepare();
            fastNav.GetPopup().popupVerticalAlign = "Below";
            fastNav.GetPopup().ShowAtElement(s.GetMainElement());

            fastNav.OnOkClick = function () {
                var parentDateEdit = this.calendar.owner;
                var currentDate = new Date(fastNav.activeYear, fastNav.activeMonth, 1);
                parentDateEdit.SetDate(currentDate);
                parentDateEdit.HideDropDown();
            }

            fastNav.OnCancelClick = function () {
                var parentDateEdit = this.calendar.owner;
                parentDateEdit.HideDropDown();
            }
        }
    </script>--%>
    
    <div class="row">
        <div style="height: 45px;" class="col-xs-4 col-sm-2 col-md-2 col-lg-3">
        </div>
        <div style ="height: 45px;" class="col-xs-0 col-sm-0 col-md-0 col-lg-1">
            <dx:ASPxButton OnClick="PreviousMonthButton_OnClick" ID= "PreviousMonthButton" runat="server" Text="<"></dx:ASPxButton>              
        </div>
        <div style="height: 45px;" class="col-xs-0 col-sm-0 col-md-0 col-lg-2">
            <dx:ASPxTextBox ReadOnly="True" OnInit="CurrentMonthTextBox_OnInit" ID= "CurrentMonthTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
        </div>
        <div style="height: 45px;" class="col-xs-0 col-sm-0 col-md-0 col-lg-1">
            <dx:ASPxButton OnClick="NextMonthButton_OnClick" ID= "NextMonthButton" runat="server" Text=">">
               
            </dx:ASPxButton>            
        </div>
       <%-- <div style="height: 45px;" class="col-xs-4 col-sm-2 col-md-2 col-lg-0">
        </div>--%>
    </div>

    <dx:ASPxGridView ID= "availableRooms" runat="server">
        <SettingsBehavior AllowSort="false" AllowGroup="false" AllowDragDrop="False" />
    </dx:ASPxGridView>
</asp:Content>
