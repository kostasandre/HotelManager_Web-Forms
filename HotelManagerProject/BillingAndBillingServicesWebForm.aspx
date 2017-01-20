<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingAndBillingServicesWebForm.aspx.cs" Inherits="HotelManagerProject.BillingWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            BookingList.Show();
        }
        function EndCallback(s, e) {
            if (s.cp_text !== 0) {
                sumOfServicesTextBox.SetText(s.cp_text);
                totalSumTextBox.SetText(s.cp_text2);
                //saveButton.enabled = true;
            }
        }

    </script>


    <div class="MainForm">
        <div class="container" style="width: 100%">

            <div class="row">
                <div class="col-lg-0 col-md-0 col-sm-0 col-xs-0">
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxButton ID="SearchButton" runat="server" ToolTip="Search for your desired booking." Theme="BlackGlass">
                        <Image Width="50px" Height="20px" Url="Images/searched.jpg"></Image>
                        <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                    </dx:ASPxButton>
                </div>
                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="Booking :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="bookingIdTextBox" runat="server"></dx:ASPxTextBox>
                </div>
                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="Price :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="priceValueTextBox" runat="server"></dx:ASPxTextBox>
                </div>
                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="Customer :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="customerIdTextBox" runat="server"></dx:ASPxTextBox>
                </div>
                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="From :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="fromTextBox" runat="server"></dx:ASPxTextBox>
                </div>
                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="To :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ID="toTextBox" runat="server"></dx:ASPxTextBox>
                </div>
            </div>
        </div>

        <div class="container" style="width: 100%">
            <br>
            <br>

            <div class="row">
                <div class="col-lg-4 col-md-2 col-sm-1 col-xs-0">
                </div>
                <div class="col-lg-4 col-md-3 col-sm-2 col-xs-2">
                    <dx:ASPxGridView ID="BillingListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id" OnRowUpdating="BillingListGridViewOnRowUpdating">
                        <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
                        <ClientSideEvents  EndCallback="EndCallback"/>
                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                        <Columns>
                            <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="True" ShowClearFilterButton="True">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn Caption="Service Description" FieldName="Description" VisibleIndex="1" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="5" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Quantity" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Price Per Unit" FieldName="PricePerUnit" VisibleIndex="4" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Total Price" FieldName="TotalPrice" VisibleIndex="5" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
            <br>
            <div class="row">
                <div class="col-lg-7 col-md-4 col-sm-3 col-xs-0">
                </div>
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" Text="Sum of Services :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox  ClientInstanceName="sumOfServicesTextBox" ID="sumOfServicesTextBox" runat="server"></dx:ASPxTextBox>
                </div>

            </div>
            <div class="row">
                <div class="col-lg-4 col-md-2 col-sm-1 col-xs-0">
                </div>
                <div class="col-lg-3 col-md-2 col-sm-2 col-xs-12">
                    <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="Paid :" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxCheckBox ID="paidCheckBox" runat="server"></dx:ASPxCheckBox>
                </div>
                <div class="col-lg-2 col-md-3 col-sm-3 col-xs-12">
                    <dx:ASPxLabel CssClass="Text2" ForeColor="Black" Text="Total Sum :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    <dx:ASPxTextBox ClientInstanceName="totalSumTextBox" ID="totalSumTextBox" runat="server"></dx:ASPxTextBox>
                </div>
            </div>
            <br>
            <br>
            <br>
            <div class="row">
                <div class="col-lg-9 col-md-8 col-sm-6 col-xs-2">
                </div>
                <div class="col-lg-1 col-md-2 col-sm-1 col-xs-3">
                    <dx:ASPxButton ClientInstanceName="saveButton" ID="saveButton" CssClass="Text2" ForeColor="Aquamarine" Text="Save" runat="server" EnableTheming="True" Theme="BlackGlass" OnClick="SaveButtonClick"></dx:ASPxButton>
                </div>
                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <dx:ASPxButton runat="server" CssClass="Text2" ForeColor="Aquamarine" Text="Cancel" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
                </div>
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
                                            <SettingsBehavior AllowSelectSingleRowOnly="True"></SettingsBehavior>

                                            <SettingsSearchPanel Visible="True" />
                                            <Columns>
                                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0">
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
                                            <dx:ASPxButton ID="btOK" runat="server" Text="OK" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="BtOkClick">
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
