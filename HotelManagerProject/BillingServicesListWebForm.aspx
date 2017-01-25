<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingServicesListWebForm.aspx.cs" Inherits="HotelManagerProject.BillingServicesListForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="CssClasses/StyleSheet1.css" rel="stylesheet" />
    <script type="text/javascript">
        function ShowLoginWindow() {
            if (CreateBillingServiceButton) {
                quantityTextBox.SetText("");
                priceTextBox.SetText("");
                idTextBox.SetText("0");

            }
            createBillingServicePopUp.Show();
        }
        function EndCallback(s, e) {
            if (s.cp_text !== 0) {
                quantityTextBox.SetText(s.cp_text);
                priceTextBox.SetText(s.cp_text1);
                billingComboBox.SetValue(s.cp_text2);
                serviceComboBox.SetValue(s.cp_text3);
                idTextBox.SetText(s.cp_text4);
            }
        }
    </script>
    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ClientInstanceName="CreateBillingServiceButton" ID="CreateBillingServiceButton" CssClass="button" ToolTip="Creates a new Billing" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Billing Service">
                    <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                </dx:ASPxButton>
            </div>
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton runat="server" CssClass="button" ToolTip="Deletes the selected Billing" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Billing Service" OnClick="DeleteBillingButtonClick" />
            </div>




            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">


                <div class="MainForm" style="width: 720px;">
                    <a style="font-size: 20px; color: black; font-weight: bold">Billing Services List</a>
                    <dx:ASPxGridView ID="BillingServiceListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" OnCustomButtonCallback="BillingServiceListGridViewOnCustomButtonCallback" KeyFieldName="Id">
                        <ClientSideEvents EndCallback="EndCallback" CustomButtonClick="function(s, e) { ShowLoginWindow(); e.processOnServer = true; }" />
                        <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
                        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                        <Columns>
                            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                                <CustomButtons>
                                    <dx:GridViewCommandColumnCustomButton ID="editButton">
                                        <Image Url="Images/edit.png" Width="35px" ToolTip="Edit"></Image>
                                    </dx:GridViewCommandColumnCustomButton>
                                </CustomButtons>
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="2" Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="BillingId" VisibleIndex="3" ReadOnly="True">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Service.Code" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Quantity" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>

            </div>
        </div>
    </div>


    <dx:ASPxPopupControl ClientInstanceName="createBillingServicePopUp" Width="330px" Height="250px" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createBillingServicePopUp"
        ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Billing Details"
        runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableHierarchyRecreation="True" AllowDragging="True" Theme="BlackGlass">
        <ClientSideEvents PopUp="function(s, e) { ASPxClientEdit.ClearGroup('entryGroup');}" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <label>Billing : </label>
                            </td>
                            <td>
                                <dx:ASPxComboBox ValueField="Id" ClientInstanceName="billingComboBox" TextField="Id" ID="billingComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True"></dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Service : </label>
                            </td>
                            <td>
                                <dx:ASPxComboBox ValueField="Id" ClientInstanceName="serviceComboBox" TextField="Id" ID="serviceComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True">
                                    <Columns>
                                        <dx:ListBoxColumn FieldName="Code" />
                                    </Columns>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="idTextBox" CssClass="hidden" ID="idTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Quantity:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="quantityTextBox" ID="quantityTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {     if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || 
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                         }" />
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large" />
                                        <RequiredField IsRequired="True" ErrorText="*" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Price:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="priceTextBox" ID="priceTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {     if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || (e.htmlEvent.keyCode == 188) ||
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                         }" />
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large" />
                                        <RequiredField IsRequired="True" ErrorText="*" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="pcmButton">
                        <dx:ASPxButton ID="btOK" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="BtOkClick">
                            <ClientSideEvents Click="function(s, e) {
if (eval(&#39;quantityTextBox&#39;).lastChangedValue == null || eval(&#39;priceTextBox&#39;).lastChangedValue == null) {
                                                                                           return false;
                                                                                                          }

 if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) createBillingServicePopUp.Hide();
 }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { createBillingServicePopUp.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
