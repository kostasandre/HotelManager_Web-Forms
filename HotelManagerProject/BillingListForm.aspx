<%@ page title="" language="C#" masterpagefile="~/MasterPage.Master" autoeventwireup="true" codebehind="BillingListForm.aspx.cs" inherits="HotelManagerProject.BillingListForm" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="BillingListGridView" runat="server" Theme="BlackGlass">
        <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="PriceForRoom" VisibleIndex="2" ReadOnly="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="3" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PriceForServices" VisibleIndex="4" >
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalPrice" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Paid" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
            </Columns>
    </dx:ASPxGridView>
</asp:content>
