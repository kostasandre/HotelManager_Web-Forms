<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingListWebForm.aspx.cs" Inherits="HotelManagerProject.BillingListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CssClasses/StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript">
        function ShowLoginWindow() {
            createBillingPopUp.Show();
        }
        function EndCallback(s, e) {
            paidCheckBox.SetChecked(s.cp_text);
            priceForRoomTextBox.SetText(s.cp_text1);
            priceForServicesTextBox.SetText(s.cp_text2);
            totalPricerTextBox.SetText(s.cp_text3);
        }


    </script>
    <div class="container" style="width: 100%">
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ID="CreateBillingButton" CssClass="button" ToolTip="Creates a new Billing" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Billing">
                    <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); e.processOnServer = true; }" />
                </dx:ASPxButton>
            </div>
            <div class="col-lg-3 col-sm-2 col-xs-4">
                <dx:ASPxButton runat="server" ID="DeleteBillingButon" CssClass="button" ToolTip="Deletes the selected Billing" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Billing" OnClick="DeleteBillingButtonClick">
                   
                </dx:ASPxButton>
            </div>



            <div class="col-xs-12 col-lg-4 col-sm-4">
                <dx:ASPxGridView  ID="BillingListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" OnCustomButtonCallback="BillingListGridView_OnCustomButtonCallback" KeyFieldName="Id">
                    <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                    <ClientSideEvents EndCallback="EndCallback" CustomButtonClick="function(s, e) { ShowLoginWindow(); e.processOnServer = true; }" />
                    <Columns>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="editButton">
                                    <Image Url="Images/edit.png" Width="35px" ToolTip="Edit"></Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PriceForRoom" VisibleIndex="3" ReadOnly="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="PriceForServices" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="TotalPrice" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Paid" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <dx:ASPxPopupControl ClientInstanceName="createBillingPopUp" Width="330px" Height="250px" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createBillingPopUp"
        ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Billing Details"
        runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableHierarchyRecreation="True" AllowDragging="True" Theme="BlackGlass">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup');}" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <label>Booking : </label>
                            </td>
                            <td>
                                <dx:ASPxComboBox ValueField="Id" TextField="Id" ID="bookingComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True"></dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Paid:
                                </label>
                            </td>
                            <td>
                                <dx:ASPxCheckBox ClientIDMode="Static" ClientInstanceName="paidCheckBox" ID="paidCheckBox" runat="server" CheckState="Unchecked" Width="170px">
                                </dx:ASPxCheckBox>
                            </td>
                            <tr>
                                <td>
                                    <label>Price For Room:  </label>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ClientInstanceName="priceForRoomTextBox" ID="priceForRoomTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <label>Price For Services:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="priceForServicesTextBox" ID="priceForServicesTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Total Price:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="totalPricerTextBox" ID="totalPricerTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="pcmButton">
                        <dx:ASPxButton ID="btOK" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="btOK_Click">
                            <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) createBillingPopUp.Hide(); }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { createBillingPopUp.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

</asp:Content>
