<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HotelWebForm.aspx.cs" Inherits="HotelManagerProject.HotelWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ShowLoginWindow() {
            if (createHotelButton) {
                idTextBox.SetText("0");
                nameTextBox.SetText("");
                addressTextBox.SetText("");
                managerTextBox.SetText("");
                emailTextBox.SetText("");
                phoneTextBox.SetText("");
                taxIdSpinEdit.SetText("");
            }
            HotelDetailView.Show();
        }
        function EndCallback(s, e) {
            idTextBox.SetText(s.cp_text1);
            nameTextBox.SetText(s.cp_text2);
            addressTextBox.SetText(s.cp_text3);
            managerTextBox.SetText(s.cp_text4);
            emailTextBox.SetText(s.cp_text5);
            phoneTextBox.SetText(s.cp_text6);
            taxIdSpinEdit.SetText(s.cp_text7);
        }
    </script>

    <div class="container" style="width: 100%">
        
        <div class="row">
            
            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="createHotelButton" ClientIDMode="Static" CssClass="button" ToolTip="Creates a new Hotel" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Hotel">
                    <ClientSideEvents Click="function(s, e) {
	                    { ShowLoginWindow();  e.processOnServer = true;}
                        }"></ClientSideEvents>
                </dx:ASPxButton>

            </div>

            <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                <dx:ASPxButton ID="deleteHotelButton" CssClass="button" ToolTip="Deletes the selected Hotel" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Delete Hotel" OnClick="DeleteHotelButtonClick" />
            </div>

            <div class="col-lg-10 col-md-8 col-sm-8 col-xs-12">
                <div class="MainForm" style="width: 1325px">
                    <a style="font-size: 20px; color: black; font-weight: bold">Hotel List</a>
                    <dx:ASPxGridView ID="HotelGridView" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True" OnCustomButtonCallback="HotelGridView_OnCustomButtonCallback" KeyFieldName="Id">
                        <ClientSideEvents CustomButtonClick="function(s, e) {
	                        ShowLoginWindow(); e.processOnServer = true; 
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
                            <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Manager" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="TaxId" VisibleIndex="8">
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

    <dx:ASPxPopupControl ID="HotelDetailView" ClientIDMode="Static" runat="server" CloseAction="CloseButton" Width="350px" Height="250px" CloseOnEscape="True" Modal="True"
        MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="HotelDetailView"
        HeaderText="Hotels" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" EnableTheming="True" Theme="BlackGlass">
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
                                                    <dx:ASPxLabel ID="nameLabel" runat="server" Text="Name"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="nameTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="addressLabel" runat="server" Text="Address"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="addressTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="managerLabel" runat="server" Text="Manager"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="managerTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                                            <ErrorFrameStyle Font-Size="Large" />
                                                            <RequiredField IsRequired="True" ErrorText="*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="emailLabel" runat="server" Text="Email"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="emailTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ValidationSettings>
                                                            <RegularExpression ErrorText="Invalid mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="phoneLabel" runat="server" Text="Phone"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxTextBox ID="phoneTextBox" runat="server" Width="170px" ClientIDMode="Static">
                                                        <ClientSideEvents KeyDown="function(s, e) {
	if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || 
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);

}"></ClientSideEvents>
                                                    </dx:ASPxTextBox>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-xs-4">
                                                    <dx:ASPxLabel ID="taxIdLabel" runat="server" Text="Tax Id"></dx:ASPxLabel>
                                                </div>
                                                <div class="col-xs-6">
                                                    <dx:ASPxSpinEdit ID="taxIdSpinEdit" runat="server" Number="0" MaxLength="9" ClientIDMode="Static">
                                                        <ClientSideEvents KeyDown="function(s, e) {
	if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || 
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);

}"></ClientSideEvents>
                                                    </dx:ASPxSpinEdit>
                                                </div>
                                            </div>
                                            <br />
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
                                            <dx:ASPxButton ID="btOK" runat="server" Text="OK" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px" OnClick="saveButton_OnClick">
                                                <ClientSideEvents Click="function(s, e) {
if (eval(&#39;nameTextBox&#39;).lastChangedValue == null || eval(&#39;addressTextBox&#39;).lastChangedValue == null || eval(&#39;managerTextBox&#39;).lastChangedValue == null)
 		{
return false;
}

 	if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) HotelDetailView.Hide();
 }" />
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                                                <ClientSideEvents Click="function(s, e) { HotelDetailView.Hide(); }" />
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
