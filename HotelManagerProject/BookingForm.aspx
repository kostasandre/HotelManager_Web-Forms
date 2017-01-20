﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            createUserPopUp.Show();
        }

    </script>
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        
        <div class="container" style="width: 100%">

                <div class="row">
                    <div class="col-xs-1">
                         <label>Room Type:</label> 
                    </div>
                    <div class="col-xs-1">
                       <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" runat="server" ValueField="Id" TextField="Code"  IncrementalFilteringMode= "None" DropDownStyle= "DropDownList">
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
                            <dx:ASPxButton OnClick="CalculateAvailableRoomsButton" ID= "calculateRoomTypePriceButton" runat="server" Text="Calculate Price" ToolTip="Calculates the price of the selected room"></dx:ASPxButton>  
                        </div>
                        <div class="col-xs-1">
                            <dx:ASPxTextBox ID= "roomTypePriceTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                        </div>
                    </div>
            <br/>
            <div class="row">
                        <div class="col-xs-12">
                           <h3>Available Rooms</h3>
                        </div>
                        
            </div>
            <br/>
            <div class="row">
                <div class="col-xs-6">
                    <dx:ASPxGridView ID="availableRoomsGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id">
                        <Settings ShowFilterRow="True"></Settings>
                        <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

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
                            <dx:GridViewDataTextColumn FieldName="RoomTypeId" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
                <div class="col-xs-6">
                    <dx:ASPxMemo ID= "commentMemoBox" runat="server" Height="71px" Width="170px"></dx:ASPxMemo>
                </div>
                        
            </div>
            <br/>
              <div class="row">
                        <div class="col-xs-1">
                           <label>Search Customer:</label>
                        </div>
                        <div class="col-xs-4">
                            <dx:ASPxComboBox ID="customerComboBox" NullText="Search Customer" runat="server" ValueField="Id" TextField="Name" IncrementalFilteringMode= "Contains" DropDownStyle= "DropDown">
                                 <Columns>
                                <dx:ListBoxColumn FieldName="Name" Visible="True" Caption="Name"/>
                                <dx:ListBoxColumn Caption="Surname" FieldName="Surname" />
                                
                            </Columns>
                            </dx:ASPxComboBox>
                        </div>
                        <div class="col-xs-1">
                           <label>Agreed Price:</label>
                        </div>
                        <div class="col-xs-4">
                            <dx:ASPxTextBox ID= "agreedPriceTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                        </div>
                        
            </div>
            <br/>
             <dx:ASPxButton ID="createCustomerButton" runat="server" Text="Create Customer">
                <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
            </dx:ASPxButton>
            
            <br/>
            <br/>
            <div class="row">
                <div class="col-xs-6">
                    
                </div>
                <div class="col-xs-6" style="text-align: right">
                    <dx:ASPxButton OnClick="saveBookingButton_OnClick" ID= "saveBookingButton" runat="server" Text="Save Booking"></dx:ASPxButton>
                </div>
                <br/>
                <br/>
                

            </div>
        </div>

    </div>
    <dx:ASPxPopupControl ClientInstanceName="createUserPopUp" Width="330px" Height="250px"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createUserPopUp"
        ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Customer Form"
        runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableHierarchyRecreation="True" AllowDragging= "True" PopupAnimationType="Fade" Modal="True">
        <modalbackgroundstyle backcolor="Black">
        </modalbackgroundstyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <label>Name:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "nameTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Surname:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "surNameTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Tax Id:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "taxIdTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Id Number:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "idNumberTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                         <tr>
                             <td>
                                <label>Address:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "addressTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Email:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "emailTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Phone:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "phoneTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Created:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "createdTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Created By:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "createdByTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                    </table>
                    <br/>
                    <div class="pcmButton">
                                            <dx:ASPxButton OnClick="customersPopUpSaveButton_OnClick"  ID="customersPopUpSaveButton" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) createUserPopUp.Hide(); }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { createUserPopUp.Hide(); }" />
                                            </dx:ASPxButton>
                                        </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

</asp:Content>
