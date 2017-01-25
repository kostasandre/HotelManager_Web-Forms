<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomTypeWebForm.aspx.cs" Inherits="HotelManagerProject.RoomTypeWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ShowLoginWindow() {
            if (createRoomTypeButton) {
                idTextBox.SetText("0");
                codeTextBox.SetText("");
                bedTypeComboBox.SetText("");
                ViewComboBox.SetText("");
                SaunaCheckBox.SetChecked(false);
                TvCheckBox.SetChecked(false);
                WiFiCheckBox.SetChecked(false);
            }
            RoomTypeDetailView.Show();
        }

        function EndCallback(s, e) {
            idTextBox.SetText(s.cp_text1);
            codeTextBox.SetText(s.cp_text2);
            bedTypeComboBox.SetText(s.cp_text3);
            ViewComboBox.SetText(s.cp_text4);
            SaunaCheckBox.SetChecked(s.cp_text5);
            TvCheckBox.SetChecked(s.cp_text6);
            WiFiCheckBox.SetChecked(s.cp_text7);

        }
    </script>

    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createRoomTypeButton" ClientIDMode="Static" CssClass="button" ToolTip="Creates a new RoomType" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create RoomType">
                    <ClientSideEvents Click="function(s, e) {
	                    { ShowLoginWindow(); }
                        }"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteRoomTypeButton" CssClass="button" ToolTip="Deletes the selected RoomType" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete RoomType" OnClick="DeleteRoomTypeButton_OnClick" />
            </div>
            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                    <div class="MainForm" style="width: 1200px">
                    <a style="font-size: 20px; color: black; font-weight: bold">Room Type List</a>
                    <dx:ASPxGridView ID="RoomTypeGridView" OnCustomButtonCallback="RoomTypeGridView_OnCustomButtonCallback" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True" KeyFieldName="Id" ClientIDMode="Static">
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
                            <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="BedType" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="View" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Sauna" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Tv" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="WiFi" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
           </div>
        </div>
    </div>

    <dx:ASPxPopupControl ID="RoomTypeDetailView" ClientIDMode="Static" runat="server" CloseAction="CloseButton" Width="350px" Height="250px" CloseOnEscape="True" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="RoomTypeDetailView"
        HeaderText="Room Types" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" EnableTheming="True" Theme="BlackGlass">
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
                                                    <dx:ASPxLabel ID="codeLabel" runat="server" Text="Code"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="codeTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="bedTypeLabel" runat="server" Text="Bed Type"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="bedTypeComboBox" NullText="Select Bed Type" ValueField="Id" TextField="Name" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="ViewLabel" runat="server" Text="View"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="ViewComboBox" NullText="Select View" ValueField="Id" TextField="Name" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>

                                            <div class="row>">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="SaunaLabel" runat="server" Text="Sauna"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxCheckBox ID="SaunaCheckBox" runat="server" ClientIDMode="Static"></dx:ASPxCheckBox>
                                                </div>
                                            </div>

                                            <div class="row>">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="TvLabel" runat="server" Text="Tv"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxCheckBox ID="TvCheckBox" runat="server" ClientIDMode="Static"></dx:ASPxCheckBox>
                                                </div>
                                            </div>

                                            <div class="row>">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="WiFiLabel" runat="server" Text="WiFi"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxCheckBox ID="WiFiCheckBox" runat="server" ClientIDMode="Static"></dx:ASPxCheckBox>
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
                                                    if (eval(&#39;codeTextBox&#39;).lastChangedValue == null || eval(&#39;bedTypeComboBox&#39;).lastChangedValue == null || eval(&#39;ViewComboBox&#39;).lastChangedValue == null)
 		                                            {
                                                    return false;
                                                    }

                                                     	if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) RoomTypeDetailView.Hide(); 
                                                    }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { RoomTypeDetailView.Hide(); }" />
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
