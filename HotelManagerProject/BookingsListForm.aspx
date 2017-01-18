<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingsListForm.aspx.cs" Inherits="HotelManagerProject.BookingsListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
    <br />
  <br />
  <br />
  <div class="row">
   <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
    <dx:ASPxButton id="createBookingButton" CssClass="button" tooltip="Creates a new Booking" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Booking"/>
   </div>
   <div class="col-lg-1 col-sm-1 col-xs-4">
    <dx:ASPxButton runat="server" CssClass="button" tooltip="Deletes the selected Booking" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Booking" />
   </div>
  </div>

  <div class="row">
   <div class="col-xs-0 col-sm-3 col-lg-4">
   </div>
   <div class="col-xs-4">
        <h1 style="background-color: red; color: white;">Bookings List</h1>
        <dx:ASPxGridView ID="bookingsGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False">
            <Settings ShowFilterRow="True"></Settings>
            <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False"></SettingsDataSecurity>
            <Columns>

                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="Status" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Customer.Name" VisibleIndex="5">
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
        <br/>
        
       </div>
      </div>

    </div>
</asp:Content>
