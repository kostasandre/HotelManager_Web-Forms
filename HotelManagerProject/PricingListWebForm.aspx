﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PricingListWebForm.aspx.cs" Inherits="HotelManagerProject.PricingListWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ShowLoginWindow() {
            if (createPricingListButton) {
                idTextBox.SetText("0");
                validFromDateEdit.SetText("");
                validToDateEdit.SetText("");
                priceSpinEdit.SetText("");
                VatPrcSpinEdit.SetText("");

            }
            PricingListDetailView.Show();
        }

        function EndCallback(s, e) {
            idTextBox.SetText(s.cp_text1);
            typeOFRadioButtonList.SetSelectedIndex(s.cp_text2);
            if (s.cp_text2 === 0) {
                if (roomTypeLabel.SetVisible) {
                    roomTypeLabel.SetVisible(true);
                } else {
                    roomTypeLabel.classList.remove('hidden');
                }

                if (roomTypeComboBox.SetVisible) {
                    roomTypeComboBox.SetVisible(true);
                } else {
                    roomTypeComboBox.classList.remove('hidden');
                }

                if (serviceLabel.SetVisible) {
                    serviceLabel.SetVisible(false);
                } else {
                    serviceLabel.classList.add('hidden');
                }

                if (serviceComboBox.SetVisible) {
                    serviceComboBox.SetVisible(false);
                } else {
                    serviceComboBox.classList.add('hidden');
                }
            }

            if (s.cp_text2 === 1) {
                if (roomTypeLabel.SetVisible) {
                    roomTypeLabel.SetVisible(false);
                } else {
                    roomTypeLabel.classList.add('hidden');
                }

                if (roomTypeComboBox.SetVisible) {
                    roomTypeComboBox.SetVisible(false);
                } else {
                    roomTypeComboBox.classList.add('hidden');
                }

                if (serviceLabel.SetVisible) {
                    serviceLabel.SetVisible(true);
                } else {
                    serviceLabel.classList.remove('hidden');
                }

                if (serviceComboBox.SetVisible) {
                    serviceComboBox.SetVisible(true);
                } else {
                    serviceComboBox.classList.remove('hidden');
                }
            }
            typeOFRadioButtonList.SetEnabled(false);
            roomTypeComboBox.SetText(s.cp_text3);
            roomTypeComboBox.SetEnabled(false);
            serviceComboBox.SetText(s.cp_text4);
            serviceComboBox.SetEnabled(false);
            validFromDateEdit.SetText(s.cp_text5);
            validToDateEdit.SetText(s.cp_text6);
            priceSpinEdit.SetText(s.cp_text7);
            VatPrcSpinEdit.SetText(s.cp_text8);
        }
    </script>

    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ID="createPricingListButton" ClientIDMode="Static" CssClass="button" ToolTip="Creates a new PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create PricingList">
                    <ClientSideEvents Click="function(s, e) {
	                    { ShowLoginWindow(); }
                        }"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deletePricingListButton" CssClass="button" ToolTip="Deletes the selected PricingList" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete PricingList" OnClick="DeletePricingListButton_OnClick" />
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                <div class="MainForm" style="width: 1200px">
                    <a style="font-size: 20px; color: black; font-weight: bold">Pricing List</a>
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
    </div>

    <dx:ASPxPopupControl ID="PricingListDetailView" ClientIDMode="Static" runat="server" CloseAction="CloseButton" Width="350px" Height="250px" CloseOnEscape="True" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="PricingListDetailView"
        HeaderText="Pricing List" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" EnableTheming="True" Theme="BlackGlass">
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

                                                    <dx:ASPxRadioButtonList ID="typeOFRadioButtonList" runat="server" OnSelectedIndexChanged="TypeOFRadioButtonList_OnSelectedIndexChanged" AutoPostBack="True" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Type of billing is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxRadioButtonList>

                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="roomTypeLabel" runat="server" Text="Room Type" ClientIDMode="Static"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" ValueField="Id" TextField="Code" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Room type is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="serviceLabel" runat="server" Text="Service" ClientIDMode="Static"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="serviceComboBox" NullText="Select Service" ValueField="Id" TextField="Description" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Service is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="ValidFrom" runat="server" Text="ValidFrom"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxDateEdit ID="validFromDateEdit" runat="server" ClientIDMode="Static">

                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Valid from is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="ValidTo" runat="server" Text="ValidTo"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxDateEdit ID="validToDateEdit" runat="server" ClientIDMode="Static">
                                                        <ClientSideEvents Validation="function(s, e) {
	                                                        e.isValid = (CheckDifference()&gt;=0)
e.errorText = &quot;The Date From is greater than Date To!&quot;
                                                            }
                                                            "></ClientSideEvents>

                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Valid to is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxDateEdit>
                                                </div>
                                            </div>

                                            <script type="text/javascript">
                                                function CheckDifference() {
                                                    var startDate = new Date();
                                                    var endDate = new Date();
                                                    var difference = -1;
                                                    startDate = validFromDateEdit.GetDate();
                                                    if (startDate != null) {
                                                        endDate = validToDateEdit.GetDate();
                                                        var startTime = startDate.getTime();
                                                        var endTime = endDate.getTime();
                                                        difference = (endTime - startTime) / 86400000;

                                                    }
                                                    return difference;

                                                }
                                            </script>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="priceLabel" runat="server" Text="Price"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxSpinEdit ID="priceSpinEdit" runat="server" Number="0" MinValue="0" DecimalPlaces="2" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Price is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxSpinEdit>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="VatPrcLabel" runat="server" Text="Vat Prc"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxSpinEdit ID="VatPrcSpinEdit" runat="server" Number="0" MinValue="0" MaxValue="100" DecimalPlaces="0" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Vat is required" />
                                                        </ValidationSettings>
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
                                                <ClientSideEvents Click="function(s, e) { 
                                                    if (eval(&#39;validFromDateEdit&#39;).lastChangedValue == null || eval(&#39;validToDateEdit&#39;).lastChangedValue == null || eval(&#39;priceSpinEdit&#39;).lastChangedValue == null || eval(&#39;VatPrcSpinEdit&#39;).lastChangedValue == null || eval(&#39;typeOFRadioButtonList&#39;).lastChangedValue == null ) 
                                                    {
                                                    return false;
                                                    }

                                                    if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) PricingListDetailView.Hide(); 
                                                    }" />
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
