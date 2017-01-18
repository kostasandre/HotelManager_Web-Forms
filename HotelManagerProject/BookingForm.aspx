<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        
        <div class="container" style="width: 100%">

                <div class="row">
                    <div class="col-xs-1">
                         <label>Room Type:</label> 
                    </div>
                    <div class="col-xs-1">
                       <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" runat="server" ValueField="Id" TextField="Code" OnInit="roomTypeComboBox_OnInit" IncrementalFilteringMode=None DropDownStyle=DropDownList>
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
                        <dx:GridViewDataTextColumn FieldName="Hotel Id" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Room Type Id" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
                        
            </div>

        </div>

    </div>
</asp:Content>
