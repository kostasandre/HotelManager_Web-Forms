<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingsListForm.aspx.cs" Inherits="HotelManagerProject.BookingsListForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MainForm">
        <dx:ASPxGridView ID="bookingsGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False">
            <Settings ShowFilterRow="True"></Settings>
            <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
            <Columns>

                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1"  ShowEditButton="True">
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
    </div>
</asp:Content>
