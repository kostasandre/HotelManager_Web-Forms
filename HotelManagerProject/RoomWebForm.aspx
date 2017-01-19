<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomWebForm.aspx.cs" Inherits="HotelManagerProject.RoomWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createRoomButton" CssClass="button" ToolTip="Creates a new Room" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Room" />
            </div>
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteRoomButton" CssClass="button" ToolTip="Deletes the selected Room" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete Room" />
            </div>
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID=RoomGridView runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="HotelName" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
