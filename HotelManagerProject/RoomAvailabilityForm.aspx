<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomAvailabilityForm.aspx.cs" Inherits="HotelManagerProject.RoomAvailabilityForm" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v16.2, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraScheduler" Assembly="DevExpress.XtraScheduler.v16.2.Core, Version=16.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script type="text/javascript">
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
                document.getElementById("secretInput").click();
                parentDateEdit.HideDropDown();
            }

            fastNav.OnCancelClick = function () {
                var parentDateEdit = this.calendar.owner;
                parentDateEdit.HideDropDown();
            }
        }
    </script>


    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-5">
            </div>
            <div class="col-xs-1 col-sm-1 col-md-1 col-lg-5">
                <dx:ASPxDateEdit AutoPostBack="True" ID="de" runat="server" Theme="BlackGlass" EnableTheming="True" ShowShadow="false"
                    DisplayFormatString="MMM yyyy" EditFormatString="MMM yyyy" OnInit="de_Init">
                    <ClientSideEvents DropDown="OnDropDown" Init="OnInit"/>
                </dx:ASPxDateEdit>
                <asp:Button ID="secretInput" style="display: none" OnClick="OnDateChanged" runat="server" ClientIDMode="Static"/>
            </div>
        </div>
    </div>
    
    <div class="MainForm">
        <h1>Rooms Availability</h1>
        <dx:ASPxGridView ID="availableRooms" runat="server">

            <SettingsBehavior AllowSort="false" AllowGroup="false" AllowDragDrop="False" />
        </dx:ASPxGridView>
        <br />
        <div class="container-fluid">
            <div class="row">

                <div class="col-xs-2" style="margin-bottom: 10px">
                    <img class="imagesSize" alt="Green Square Image" src="Images/green.png" />
                    <asp:Label ID=greenLabel runat="server" Text=":Available Rooms"></asp:Label>
                </div>

                <div class="col-xs-2 ">
                    <img class="imagesSize" alt="Blue Square Image" src="Images/blue.png" />
                    <asp:Label ID=blueLabel runat="server" Text=":Billed Rooms"></asp:Label>
                </div>

                <div class="col-xs-2">
                    <img class="imagesSize" alt="Yellow Square Image" src="Images/yellow.png" />
                    <asp:Label ID=yellowLabel runat="server" Text=":Not Available Rooms"></asp:Label>
                </div>

                <div class="col-xs-2">
                    <img class="imagesSize" alt="Red Square Image" src="Images/red.png" />
                    <asp:Label ID=RedLabel runat="server" Text=":Occupied Rooms"></asp:Label>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
