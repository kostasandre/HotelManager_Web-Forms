<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PricingListWebForm.aspx.cs" Inherits="HotelManagerProject.PricingListWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script type="text/javascript">
        function ShowLoginWindow() {
            if (createPricingListButton) {
                idTextBox.SetText("0");
                //typeOFRadioButtonList.SetChecked(false);
                //roomTypeComboBox.SetText("");
                //serviceComboBox.SetText("");
                validFromDateEdit.SetText("");
                validToDateEdit.SetText("");
                priceSpinEdit.SetText("");
                VatPrcSpinEdit.SetText("");

            }
            PricingListDetailView.Show();
        }

        function EndCallback(s, e) {
            idTextBox.SetText(s.cp_text1);
            //typeOFRadioButtonList.SetChecked(s.cp_text2);
            typeOFRadioButtonList.visible = 'false';
            //roomTypeComboBox.SetText(s.cp_text3);
            //serviceComboBox.SetText(s.cp_text4);
            validFromDateEdit.SetText(s.cp_text5);
            validToDateEdit.SetText(s.cp_text6);
            priceSpinEdit.SetText(s.cp_text7);
            VatPrcSpinEdit.SetText(s.cp_text8);
        }
    </script>

    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ID="createPricingListButton" ClientIDMode="Static" CssClass="button" ToolTip="Creates a new PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create PricingList" >
                    <ClientSideEvents Click="function(s, e) {
	{ ShowLoginWindow(); }
}"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deletePricingListButton" CssClass="button" ToolTip="Deletes the selected PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete PricingList" OnClick="DeletePricingListButton_OnClick"/>
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                <dx:ASPxGridView ID="PricingListGridView" OnCustomButtonCallback="PricingListGridView_OnCustomButtonCallback" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True" KeyFieldName="Id" ClientIDMode="Static">
                    <ClientSideEvents CustomButtonClick="function(s, e) {
	e.processOnServer = true;
             	        ShowLoginWindow(e.visibleIndex);

}"
                        EndCallback="EndCallback
"></ClientSideEvents>

                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
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
                        <dx:GridViewDataTextColumn FieldName="BillableEntityCode" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ValidFrom" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="ValidTo" VisibleIndex="6">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="VatPrc" VisibleIndex="7">
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
    
    <dx:ASPxPopupControl ID="PricingListDetailView" ClientIDMode="Static" runat="server" CloseAction="CloseButton" Width="350px" Height="250px" CloseOnEscape="True" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="PricingListDetailView"
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

                                        <div class="container" style="width: 100%">
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="idLabel" CssClass="hidden" runat="server" Text="Name"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="idTextBox" CssClass="hidden" runat="server" Width="170px" ClientIDMode="Static"></dx:ASPxTextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="typeOfLabel" runat="server" Text="Type Of Service"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">

                                                    <asp:RadioButtonList ID="typeOFRadioButtonList" runat="server" OnSelectedIndexChanged="TypeOFRadioButtonList_OnSelectedIndexChanged" AutoPostBack="True" ClientIDMode="Static">
                                                    </asp:RadioButtonList>

                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="roomTypeLabel" runat="server" Text="Room Type"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" ValueField="Id" TextField="Code" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static"></dx:ASPxComboBox>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="serviceLabel" runat="server" Text="Service"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="serviceComboBox" NullText="Select Service" ValueField="Id" TextField="Description" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static"></dx:ASPxComboBox>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="ValidFrom" runat="server" Text="ValidFrom"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxDateEdit ID="validFromDateEdit" runat="server" ClientIDMode="Static"></dx:ASPxDateEdit>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="ValidTo" runat="server" Text="ValidTo"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxDateEdit ID="validToDateEdit" runat="server" ClientIDMode="Static"></dx:ASPxDateEdit>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="priceLabel" runat="server" Text="Price"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxSpinEdit ID="priceSpinEdit" runat="server" Number="0" ClientIDMode="Static">
                                                    </dx:ASPxSpinEdit>
                                                </div>
                                            </div>
                                            
                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="VatPrcLabel" runat="server" Text="Vat Prc"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxSpinEdit ID="VatPrcSpinEdit" runat="server" Number="0" ClientIDMode="Static">
                                                    </dx:ASPxSpinEdit>
                                                </div>
                                            </div>

                                        </div>

                                        <br />
                                    </td>
                                    <td rowspan="4">
                                        <div class="pcmSideSpacer">
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="pcmButton">
                                            <dx:ASPxButton ID="btOK" runat="server" Text="OK" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="SaveButton_OnClick">
                                                <ClientSideEvents Click="function(s, e) { if(ASPxClientEdit.ValidateGroup('entryGroup')) PricingListDetailView.Hide(); }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { PricingListDetailView.Hide(); }" />
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
