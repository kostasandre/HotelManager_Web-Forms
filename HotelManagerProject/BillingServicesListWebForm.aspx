<%@ page title="" language="C#" masterpagefile="~/MasterPage.Master" autoeventwireup="true" codebehind="BillingServicesListWebForm.aspx.cs" inherits="HotelManagerProject.BillingServicesListForm" %>

<asp:content id="Content1" contentplaceholderid="head" runat="server">
</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <link href="CssClasses/StyleSheet1.css" rel="stylesheet" />
     <script type="text/javascript">
        function ShowLoginWindow() {
            createBillingServicePopUp.Show();
        }

    </script>
    <div class="container" style="width: 100%">
       <br />
        <br />
        <br />
        <div class="row">
            <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton id="CreateBillingServiceButton" CssClass="button" tooltip="Creates a new Billing" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Billing Service">
                <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                    </dx:ASPxButton>
            </div>
            <div class="col-lg-3 col-sm-2 col-xs-4">
                <dx:ASPxButton runat="server" CssClass="button" tooltip="Deletes the selected Billing" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Billing"  OnClick="DeleteBillingButtonClick"/>
            </div>
        

        
            <div class="col-xs-12 col-lg-4 col-sm-4">
                <dx:ASPxGridView ID="BillingServiceListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id">
                    <Settings ShowGroupPanel="True" ShowFilterRow="True"></Settings>
                    <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                    <Columns>
                          <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" ShowEditButton="True">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="editButton">
                                    <Image Url="Images/edit.png" Width="35px" ToolTip="Edit"></Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="BillingId" VisibleIndex="3" ReadOnly="True">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ServiceId" VisibleIndex="4">
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
                                <dx:ASPxComboBox ValueField="Id" TextField="Id" ID="billingComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True"></dx:ASPxComboBox> 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Service : </label>
                            </td>
                            <td>
                                <dx:ASPxComboBox ValueField="Id" TextField="Id" ID="serviceComboBox" runat="server" Width="170px" Theme="BlackGlass" EnableTheming="True"></dx:ASPxComboBox> 
                            </td>
                        </tr>
                             <td>
                                <label>Quantity:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "quantityTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label>Price:  </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID= "priceTextBox" runat="server" Width="170px"></dx:ASPxTextBox> 
                            </td>
                        </tr>
                    </table>
                    <br/>
                    <div class="pcmButton">
                                            <dx:ASPxButton ID="btOK" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="btOK_Click">
                                                <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) createBillingServicePopUp.Hide(); }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { createBillingServicePopUp.Hide(); }" />
                                            </dx:ASPxButton>
                                        </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:content>
