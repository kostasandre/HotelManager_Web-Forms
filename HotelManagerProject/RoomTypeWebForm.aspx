<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomTypeWebForm.aspx.cs" Inherits="HotelManagerProject.RoomTypeWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createRoomTypeButton" CssClass="button" ToolTip="Creates a new RoomType" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create RoomType" />
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteRoomTypeButton" CssClass="button" ToolTip="Deletes the selected RoomType" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete RoomType" />
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID=RoomTypeGridView runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="BedType" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Sauna" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Tv" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="View" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="WiFi" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="8">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="9">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
</asp:Content>
