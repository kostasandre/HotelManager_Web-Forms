<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RoomWebForm.aspx.cs" Inherits="HotelManagerProject.RoomWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ShowLoginWindow() {
            if (createRoomButton) {
                idTextBox.SetText("0");
                codeTextBox.SetText("");
                hotelComboBox.SetText("");
                roomTypeComboBox.SetText("");
            }
            RoomDetailView.Show();
        }

        function EndCallback(s, e) {
            if (s.cp_text4 !== undefined) {
                idTextBox.SetText(s.cp_text1);
                codeTextBox.SetText(s.cp_text2);
                hotelComboBox.SetText(s.cp_text3);
                roomTypeComboBox.SetText(s.cp_text4);
                hotelComboBox.SetEnabled(false);
                roomTypeComboBox.SetEnabled(false);
                //hotelComboBox.HideDropDown();
                //roomTypeComboBox.HideDropDown();
                //hotelComboBox.classList.add('readonly');
                //roomTypeComboBox.classList.add('readonly');
                idTextBox.visible = 'false';
            }

        }
    </script>

    <div class="container" style="width: 100%">
        <div class="row">
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createRoomButton" ClientIDMode="Static" CssClass="button" ToolTip="Creates a new Room" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Room">
                    <ClientSideEvents Click="function(s, e) {
	                    { ShowLoginWindow(); }
                        }"></ClientSideEvents>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteRoomButton" CssClass="button" ToolTip="Deletes the selected Room" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete Room" OnClick="DeleteRoomButton_OnClick" />
            </div>
            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">
                <div class="MainForm" style="width: 740px">
                    <a style="font-size: 20px; color: black; font-weight: bold">Room List</a>
                    <dx:ASPxGridView ID="RoomGridView" OnCustomButtonCallback="RoomGridView_OnCustomButtonCallback" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True" KeyFieldName="Id" ClientIDMode="Static">
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
                            <dx:GridViewDataTextColumn FieldName="HotelName" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>

    <dx:ASPxPopupControl ID="RoomDetailView" ClientIDMode="Static" runat="server" CloseAction="CloseButton" Width="350px" Height="250px" CloseOnEscape="True" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="RoomDetailView"
        HeaderText="Rooms" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" EnableTheming="True" Theme="BlackGlass">
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
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Code is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="hotelLabel" runat="server" Text="Hotel"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="hotelComboBox" NullText="Select Hotel" ValueField="Id" TextField="Name" runat="server" IncrementalFilteringMode="None" DropDownStyle="DropDownList" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Hotel is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="roomTypeLabel" runat="server" Text="Room Type"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" ValueField="Id" TextField="Code" runat="server" IncrementalFilteringMode="None" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="Room type is required" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
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
if (eval(&#39;codeTextBox&#39;).lastChangedValue == null || eval(&#39;hotelComboBox&#39;).lastChangedValue == null || eval(&#39;roomTypeComboBox&#39;).lastChangedValue == null)
 		{
return false;
}

 	if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) RoomDetailView.Hide(); 
}" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { RoomDetailView.Hide(); }" />
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
