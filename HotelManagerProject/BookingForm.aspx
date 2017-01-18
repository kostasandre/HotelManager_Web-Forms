<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="ASPxButton">
            <ClientSideEvents Click="function(s, e) {	popup.ShowWindow(popup.GetWindowByName('createUserPopUp'));  }" />
        </dx:ASPxButton>
        
        <div class="container" style="width: 100%">

                <div class="row">
                    <div class="col-xs-1">
                         <label>Room Type:</label> 
                    </div>
                    <div class="col-xs-1">
                       <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" runat="server" ValueField="Id" TextField="Code" OnInit="roomTypeComboBox_OnInit" IncrementalFilteringMode= "None" DropDownStyle= "DropDownList">
                        </dx:ASPxComboBox>
                    </div>
                </div>
             <div class="row">
                    <div class="col-xs-1">
                         <label>Date From:</label> 
                    </div>
                    <div class="col-xs-1">
                        <dx:ASPxDateEdit ID= "dateFromCalendar" runat="server"></dx:ASPxDateEdit>
                    </div>
                 <div class="col-xs-1">
                        
                    </div>
                 <div class="col-xs-1">
                        <label>Date To:</label> 
                    </div>
                 <div class="col-xs-1">
                        <dx:ASPxDateEdit ID= "dateToCalendar" runat="server"></dx:ASPxDateEdit>
                    </div>
                </div>
            <br/>
                <div class="row">
                        <div class="col-xs-1">
                            <dx:ASPxButton OnClick="calculateRoomTypePriceButton_OnClick" ID= "calculateRoomTypePriceButton" runat="server" Text="Calculate" ToolTip="Calculates the price of the selected room"></dx:ASPxButton>  
                        </div>
                        <div class="col-xs-1">
                            <dx:ASPxTextBox ID= "roomTypePriceTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                        </div>
                    </div>
            <br/>
            <div class="row">
                        <div class="col-xs-12">
                           <h3 style="text-align: center">Available Rooms</h3>
                        </div>
                        
                    </div>
            <br/>
            <div class="row" style="align-content: center">
                <div class="col-xs-12">
                    <dx:ASPxGridView ID="availableRoomsGridView" runat="server" Theme="BlackGlass">
                        <Settings ShowFilterRow="True"></Settings>
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                        <Columns>

                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                            
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="4" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="HotelId" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="RoomTypeId" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
                        
            </div>

        </div>

    </div>
    <dx:ASPxPopupControl ClientInstanceName="ASPxPopupClientControl" Width="330px" Height="250px"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createUserPopUp"
        ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Area of Countries"
        runat="server" EnableViewState="false" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" EnableHierarchyRecreation="True">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="container" style="width: 100%">
                        <div class="row">
                            <div class="col-xs-1">
                                 <label>Room Type:</label> 
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ClientSideEvents CloseUp="function(s, e) { SetImageState(false); }" PopUp="function(s, e) { SetImageState(true); }" />
    </dx:ASPxPopupControl>

</asp:Content>
