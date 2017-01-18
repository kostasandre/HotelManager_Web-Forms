<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingServicesWebForm.aspx.cs" Inherits="HotelManagerProject.BillingWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            BookingList.Show();
        }

    </script>
    <div class="container" style="width: 100%">

        <div class="row">
            <div class="col-xs-2">
            </div>
            <div class="col-xs-1">
                <dx:ASPxButton ID="SearchButton" runat="server" ToolTip="Search for your desired booking." Theme="BlackGlass">
                    <Image Width="50px" Height="20px" Url="Images/searched.jpg"></Image>
                    <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                </dx:ASPxButton>
            </div>
            <div class="col-xs-2 billingdiv2">
                <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Booking :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
            <div class="col-xs-2 billingdiv2">
                <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Price :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
            <div class="col-xs-2 billingdiv2">
                <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Customer :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
        </div>
    </div>

    <div class="container" style="width: 100%">
        <br>
        <br>

        <div class="row">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-4">
                <dx:ASPxGridView ID="BillingGridView" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>

                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2" ReadOnly="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="4" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="3" Name="Quantity">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="5" Name="Price">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-4">
            </div>
            <div class="col-xs-3 billingdiv">
                <dx:ASPxLabel CssClass="Text" ForeColor="Aquamarine" Text="Sum of Services :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>

        </div>
        <div class="row">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-1 billingdiv2">
                <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Paid :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxCheckBox runat="server"></dx:ASPxCheckBox>
            </div>
            <div class="col-xs-3 billingdiv">
                <dx:ASPxLabel CssClass="Text2" ForeColor="Aquamarine" Text="Total Sum :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
        </div>
        <br>
        <br>
        <br>
        <div class="row">
            <div class="col-xs-9">
            </div>
            <div class="col-xs-1 billingdiv">
                <dx:ASPxButton CssClass="Text2" ForeColor="Aquamarine" Text="Save" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
            </div>
            <div class="col-xs-2 billingdiv">
                <dx:ASPxButton runat="server" CssClass="Text2" ForeColor="Aquamarine" Text="Cancel" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
            </div>
        </div>


    </div>
    <dx:ASPxPopupControl ID="BookingList" runat="server" CloseAction="CloseButton" CloseOnEscape="True" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="BookingList"
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
                                        <dx:ASPxGridView runat="server" ID="BookingListGridview" AutoGenerateColumns="False" KeyFieldName="Id" Theme="BlackGlass">
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
                                        </dx:ASPxGridView>
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
                                                <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) BookingList.Hide(); }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { BookingList.Hide(); }" />
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
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    

</asp:Content>
