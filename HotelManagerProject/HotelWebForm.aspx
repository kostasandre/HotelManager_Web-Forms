<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HotelWebForm.aspx.cs" Inherits="HotelManagerProject.HotelWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            HotelDetailView.Show();
        }

    </script>
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createHotelButton" CssClass="button" ToolTip="Creates a new Hotel" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Hotel">
                    <ClientSideEvents Click="function(s, e) {
	{ ShowLoginWindow(); }
}"></ClientSideEvents>
                </dx:ASPxButton>

            </div>
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteHotelButton" CssClass="button" ToolTip="Deletes the selected Hotel" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete Hotel" />
            </div>
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID=HotelGridView runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Manager" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TaxId" VisibleIndex="7">
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

    <dx:ASPxPopupControl ID="HotelDetailView" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="HotelDetailView"
        HeaderText="Bookings" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" EnableTheming="True" Theme="BlackGlass">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup');}" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <dx:ASPxPanel ID="Panel1" runat="server" DefaultButton="btOK">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                            <table>
                                <tr>
                                    <td rowspan="4">
                                        <div class="pcmSideSpacer">
                                        </div>
                                    </td>
                                    <td class="pcmCellText">
                                        <%--<dx:ASPxGridView runat="server" ID="BookingListGridview" AutoGenerateColumns="False" KeyFieldName="Id" Theme="BlackGlass">
                                            <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                                            <SettingsSearchPanel Visible="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0">
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="Comments" VisibleIndex="2" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="5" Visible="False">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="From" VisibleIndex="4" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="To" VisibleIndex="6" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SystemPrice" VisibleIndex="7" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AgreedPrice" VisibleIndex="3" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                            </Columns>
                                        </dx:ASPxGridView>--%>
                                        <div class="container" style="width: 100%">

                                            <div class="row">
                                                <div class="col-xs-6">
                                                    <dx:ASPxLabel ID="nameLabel" runat="server" Text="Name"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="nameTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-6">
                                                <dx:ASPxLabel ID="addressLabel" runat="server" Text="Address"></dx:ASPxLabel>
                                            </div>
                                            <div class="col-xs-6">
                                                <dx:ASPxTextBox ID="addressTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-6">
                                                <dx:ASPxLabel ID="managerLabel" runat="server" Text="Manager"></dx:ASPxLabel>
                                            </div>
                                            <div class="col-xs-6">
                                                <dx:ASPxTextBox ID="managerTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-6">
                                                <dx:ASPxLabel ID="emailLabel" runat="server" Text="Email"></dx:ASPxLabel>
                                            </div>
                                            <div class="col-xs-6">
                                                <dx:ASPxTextBox ID="emailTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-6">
                                                <dx:ASPxLabel ID="phoneLabel" runat="server" Text="Phone"></dx:ASPxLabel>
                                            </div>
                                            <div class="col-xs-6">
                                                <dx:ASPxTextBox ID="phoneTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-xs-6">
                                                <dx:ASPxLabel ID="taxIdLabel" runat="server" Text="Tax Id"></dx:ASPxLabel>
                                            </div>
                                            <div class="col-xs-6">
                                                <dx:ASPxSpinEdit ID="taxIdSpinEdit" runat="server" Number="0" MaxLength="9">
                                                </dx:ASPxSpinEdit>
                                            </div>
                                        </div>

                                    </td>
                                    <td rowspan="4">
                                        <div class="pcmSideSpacer">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="pcmButton">
                                            <dx:ASPxButton ID="btOK" runat="server" Text="OK" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) HotelDetailView.Hide(); }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { HotelDetailView.Hide(); }" />
                                            </dx:ASPxButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
