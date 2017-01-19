<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PricingListWebForm.aspx.cs" Inherits="HotelManagerProject.PricingListWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ID="createPricingListButton" CssClass="button" ToolTip="Creates a new PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create PricingList" />
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deletePricingListButton" CssClass="button" ToolTip="Deletes the selected PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete PricingList" />
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID=PricingListGridView runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ValidFrom" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ValidTo" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VatPrc" VisibleIndex="5">
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
