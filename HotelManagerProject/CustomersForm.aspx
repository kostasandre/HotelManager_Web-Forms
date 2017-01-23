<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CustomersForm.aspx.cs" Inherits="HotelManagerProject.CustomersForm" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Import Namespace="DevExpress.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            createUserPopUp.Show();
        }

    </script>


    <div class="container" style="width: 100%">
        <br/>
        <br/>
        <br/>
        <div class="row">
            <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
                <dx:ASPxButton ClientSideEvents="" id="createCustomerButton" CssClass="button" tooltip="Creates a new Customer" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Create Customer ">
                    <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }"/>
                </dx:ASPxButton>
            </div>
            <div class="col-lg-1 col-sm-1 col-xs-4">
                <dx:ASPxButton OnClick="DeleteCustomerButton" runat="server" CssClass="button" tooltip="Deletes the selected Customer" ForeColor="AquaMarine" Theme="BlackGlass" Text="Delete Customer"/>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-0 col-sm-3 col-lg-4">
            </div>
            <div class="col-xs-12">
                <div class="MainForm" style="width: 1325px">
                    <h1>Customer List</h1>
                    <dx:ASPxGridView ID="customersListGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id">
                        <Settings ShowFilterRow="True"></Settings>
                        <SettingsDataSecurity AllowInsert="False" AllowDelete="False" AllowEdit="False"></SettingsDataSecurity>
                        <Columns>

                            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Surname" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="TaxId" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="IdNumber" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Email" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Phone" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="11">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>
    </div>

    <dx:ASPxPopupControl ClientInstanceName="createUserPopUp" Width="330px" Height="250px"
                         MaxWidth="800px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createUserPopUp"
                         ShowFooter="True" FooterText="Runtime: 142 min" PopupElementID="imgButton" HeaderText="Customer Form"
                         runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True" PopupAnimationType="Fade" Modal="True">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <label>Name: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="nameTextBox" ValidateRequestMode="Enabled" ID="nameTextBox" runat="server" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large"/>
                                        <RequiredField IsRequired="True" ErrorText="*"/>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Surname: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="surnameText" ValidateRequestMode="Enabled" ID="surNameTextBox" runat="server" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large"/>
                                        <RequiredField IsRequired="True" ErrorText="*"/>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Tax Id: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="taxIdTextBox" runat="server" Width="170px">

                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Id Number: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="idNumberText" ID="idNumberTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {
	                                 if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || 
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }">
                                    </ClientSideEvents>
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="Text" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large"/>
                                        <RequiredField IsRequired="True" ErrorText="*"/>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Email: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="emailTextBox" runat="server" Width="170px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Address: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="addressTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Phone: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="phoneTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {
	                                 if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || 
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }">
                                    </ClientSideEvents>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Created: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="createdTextBox" runat="server" Width="170px" ReadOnly="True"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>Created By: </label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="createdByTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <br/>
                    <div class="pcmButton">
                        <dx:ASPxButton OnClick="SaveButton_OnClick" ID="saveButton" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) {
if (eval(&#39;nameTextBox&#39;).lastChangedValue == null || eval(&#39;surnameText&#39;).lastChangedValue == null || eval(&#39;idNumberText&#39;).lastChangedValue == null) {
return false;
}

 if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) createUserPopUp.Hide();
 }"/>
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="cancelButton" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { createUserPopUp.Hide(); }"/>
                        </dx:ASPxButton>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>