<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ServiceWebForm.aspx.cs" Inherits="HotelManagerProject.ServiceWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createServiceButton" CssClass="button" ToolTip="Creates a new Service" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Service" />
            </div>
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteServiceButton" CssClass="button" ToolTip="Deletes the selected Service" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete Service" />
            </div>
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID=ServiceGridView runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="3">
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
