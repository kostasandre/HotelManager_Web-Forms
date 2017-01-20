﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingsListForm.aspx.cs" Inherits="HotelManagerProject.BookingsListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            createBookingPopUp.Show();
        }

    </script>
    <div class="container" style="width: 100%">
    <br />
  <br />
  <br />
  <div class="row">
   <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
    <dx:ASPxButton OnClick="createBookingButton_OnClick" id="createBookingButton" CssClass="button" tooltip="Creates a new Booking" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Booking"/>
   </div>
   <div class="col-lg-1 col-sm-1 col-xs-4">
    <dx:ASPxButton OnClick="deleteBookingButton_OnClick" ID="deleteBookingButton" runat="server" CssClass="button" tooltip="Deletes the selected Booking" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Booking" />
   </div>
  </div>

  <div class="row">
   <div class="col-xs-0 col-sm-3 col-lg-4">
   </div>
   <div class="col-xs-12">
       <div class="MainForm" style="width: 1370px">
            <h1>Bookings List</h1>
           <dx:ASPxGridView  OnCustomButtonCallback="bookingsGridView_OnCustomButtonCallback" ID="bookingsGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id">

              

               <Settings ShowFilterRow="True"></Settings>
               <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False"></SettingsDataSecurity>
               <ClientSideEvents CustomButtonClick="function(s, e) {
                   e.processOnServer = true;
                    ShowLoginWindow(); }" />
                <Columns>
           
                    <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewCommandColumn>
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="editButton">
                                <Image Url="Images/edit.png" Width="35px" ToolTip="Edit"></Image>
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Room.Code" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="From" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="To" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SystemPrice" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="AgreedPrice" VisibleIndex="13">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Comments" VisibleIndex="9">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="10">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="11">
                </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
           </div>
        <br/>
        
       </div>
      </div>

    </div>
    <dx:ASPxPopupControl  ClientInstanceName="createBookingPopUp" Width="330px" Height="250px" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createBookingPopUp"
        ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Billing Details"
        runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableHierarchyRecreation="True" AllowDragging="True" Theme="BlackGlass">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup');}" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <label>Status : </label>
                            </td>
                            <td>
                                <dx:ASPxComboBox ValueField="Id" TextField="Id" ID="statusComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True"></dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Comments:
                                </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="commentsTextBoxTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                            <tr>
                                <td>
                                    <label>Date From:  </label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="dateFromTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <label>Date To:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="dateToTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>System Price:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="systemPriceTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Agreed Price:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="agreedPriceTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Created:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="createdTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Created By:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="createdByTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="pcmButton">
                        <dx:ASPxButton ID="Save" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) createBookingPopUp.Hide(); }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { createBookingPopUp.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
