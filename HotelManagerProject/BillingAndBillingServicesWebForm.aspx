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

            }
        }

    </script>


    <div class="MainForm">
        <div class="container" style="width: 100%">
            <a style="font-size: 20px; color: black; font-weight: bold">Billing and BillingServices Form</a>
            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                    <dx:ASPxLabel CssClass="Text" Width="90px" ForeColor="Black" runat="server" Text="Booking :" Theme="BlackGlass"></dx:ASPxLabel>
                </div>
                <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                    <dx:ASPxButton ID="SearchButton" runat="server" ToolTip="Search for your desired booking." Theme="BlackGlass">
                        <Image Width="50px" Height="20px" Url="Images/searched.jpg"></Image>
                        <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                    </dx:ASPxButton>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxLabel CssClass="Text" Width="100px" ForeColor="Black" runat="server" Text="Customer :" Theme="BlackGlass"></dx:ASPxLabel>
            </div>
            <div class="col-lg-2 col-md-10 col-sm-8 col-xs-7">
                <dx:ASPxTextBox ID="customerSurnameTextBox" NullText="Surname" runat="server"></dx:ASPxTextBox>
            </div>
            <div class="col-lg-1 col-md-2 col-sm-3 col-xs-2">
                <dx:ASPxTextBox ID="customerNameTextBox" NullText="Name" runat="server"></dx:ASPxTextBox>
            </div>
        </div>


        <div class="row" style="margin-top: 10px;">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxLabel CssClass="Text" Width="100px" ForeColor="Black" runat="server" Text="Room :" Theme="BlackGlass"></dx:ASPxLabel>
            </div>
            <div class="col-lg-1 col-md-1 col-sm-2 col-xs-3">
                <dx:ASPxTextBox ID="roomTextBox" NullText="Code" runat="server"></dx:ASPxTextBox>
            </div>
        </div>


        <div class="row" style="margin-top: 10px;">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxLabel CssClass="Text" ForeColor="Black" runat="server" Text="Stay :" Theme="BlackGlass"></dx:ASPxLabel>
            </div>
            <div class="col-lg-2 col-md-10 col-sm-8 col-xs-7">
                <dx:ASPxTextBox NullText="From" ID="fromTextBox" runat="server"></dx:ASPxTextBox>
            </div>
            <div class="col-lg-1 col-md-2 col-sm-3 col-xs-2">
                <dx:ASPxTextBox NullText="To" ID="toTextBox" runat="server"></dx:ASPxTextBox>
            </div>
        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-lg-7 col-md-5 col-sm-0 col-xs-0">
            </div>
            <div class="col-lg-2 col-md-2 col-sm-3 col-xs-5">
                <dx:ASPxLabel CssClass="Text" Width="150px" ForeColor="Black" runat="server" Text="Price for room :" Theme="BlackGlass"></dx:ASPxLabel>
            </div>
            <div class="col-lg-1 col-md-2 col-sm-1 col-xs-1">
                <dx:ASPxTextBox ID="priceValueTextBox" runat="server"></dx:ASPxTextBox>
            </div>
            <div>
                <dx:ASPxTextBox ID="bookingIdTextBox" CssClass="hidden" runat="server"></dx:ASPxTextBox>
            </div>

        </div>



        <div class="container" style="width: 100%">
            <br>
            <br>

            <div class="row">
                <div class="col-lg-4 col-md-3 col-sm-2 col-xs-2">
                    <dx:ASPxGridView ID="BillingListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id" OnRowUpdating="BillingListGridViewOnRowUpdating">
                        <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
                        <ClientSideEvents EndCallback="EndCallback" />
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
            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-7 col-md-5 col-sm-0 col-xs-0">
                </div>
                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-6">
                    <dx:ASPxLabel CssClass="Text" Width="250px" ForeColor="Black" ID="sumOfServicesLabel" Text="Price for services :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                </div>
                <div class="col-lg-1 col-md-2 col-sm-1 col-xs-1">
                    <dx:ASPxTextBox ClientInstanceName="sumOfServicesTextBox" ClientIDMode="Static" ID="sumOfServicesTextBox" runat="server"></dx:ASPxTextBox>
                </div>
            </div>

            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-7 col-md-5 col-sm-0 col-xs-0">
                </div>
                <div class="col-lg-2 col-md-2 col-sm-3 col-xs-6">
                    <dx:ASPxLabel CssClass="Text" ID="totalSumLabel" ForeColor="#222222" Text="Total price :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                </div>
                <div class="col-lg-1 col-md-2 col-sm-1 col-xs-1">
                    <dx:ASPxTextBox ClientInstanceName="totalSumTextBox" ID="totalSumTextBox" runat="server"></dx:ASPxTextBox>
                </div>
            </div>

            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-9 col-md-7 col-sm-3 col-xs-6">
                </div>
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-2">
                    <dx:ASPxLabel CssClass="Text" Width="80px"  ID="paidLabel" ForeColor="Black" runat="server" Text="Paid :" Theme="BlackGlass"></dx:ASPxLabel>
                </div>
                <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1">
                    <dx:ASPxCheckBox ID="paidCheckBox" runat="server"></dx:ASPxCheckBox>
                </div>
            </div>

        </div>
        <br>
        <br>
        <br>
        <div class="row">
            <div class="col-lg-9 col-md-8 col-sm-6 col-xs-2">
            </div>
            <div class="col-lg-1 col-md-2 col-sm-1 col-xs-3">
                <dx:ASPxButton ClientInstanceName="saveButton" ID="saveButton" CssClass="button" ForeColor="Aquamarine" Text="Save" runat="server" EnableTheming="True" Theme="BlackGlass" OnClick="SaveButtonClick">
                    <ClientSideEvents CheckedChanged="function(s, e) {document.getElementById(&#39;sumOfServicesTextBox&#39;).SetEnabled(true)
}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                <dx:ASPxButton ID="cancelButton" runat="server" CssClass="button" ForeColor="Aquamarine" Text="Cancel" EnableTheming="True" Theme="BlackGlass" OnClick="CancelButtonOnClick"></dx:ASPxButton>
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
                                                <dx:GridViewDataTextColumn FieldName="Customer.Name" VisibleIndex="1" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Customer.Surname" VisibleIndex="2" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn Caption="Room" FieldName="Room.Code" VisibleIndex="3" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Comments" VisibleIndex="4" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="5" Visible="False">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="From" VisibleIndex="6" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="To" VisibleIndex="7" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="SystemPrice" VisibleIndex="8" ReadOnly="True">
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AgreedPrice" VisibleIndex="9" ReadOnly="True">
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
