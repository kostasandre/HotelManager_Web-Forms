<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowLoginWindow() {
            createUserPopUp.Show();
        }

    </script>

    <div class="container" style="width: 100%">
        <div class="row">
            <div class="MainForm" style="width: 1000px">

                <a style="font-size: 20px; color: black; font-weight: bold">Booking Form</a>
                <br />
                <div class="container" style="width: 100%">

                    <div class="row">
                        <div style="height: 45px; padding-left: unset" class="col-xs-1 col-sm-1 col-md-2 col-lg-2">
                            <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Room Type :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                        </div>
                        <div class="col-xs-3 col-sm-1 col-md-10 col-lg-3">
                            <dx:ASPxComboBox ID="roomTypeComboBox" NullText="Select Room Type" runat="server" ValueField="Id" TextField="Code" IncrementalFilteringMode="None" DropDownStyle="DropDownList">
                            </dx:ASPxComboBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-1 col-sm-1 col-md-2 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Date From :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div style="height: 45px;" class="col-xs-11 col-sm-11 col-md-10 col-lg-3">
                        <dx:ASPxDateEdit AllowUserInput="False" ID="dateFromCalendar" runat="server" AllowNull="False" ClientIDMode="Static">
                            <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                <ErrorFrameStyle Font-Size="Large" />
                                <RequiredField IsRequired="True" ErrorText="Valid from is required" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </div>

                    <div class="col-xs-1 col-sm-1 col-md-2 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Date To :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div class="col-xs-10 col-sm-4 col-md-3 col-lg-3">
                        <dx:ASPxDateEdit AllowUserInput="False" ID="dateToCalendar" runat="server" AllowNull="False" ClientIDMode="Static">
                            <ClientSideEvents Validation="function(s, e) {
e.isValid = (CheckDifference()&gt;=0)
e.errorText = &quot;The Date From is greater than Date To!&quot;
}"></ClientSideEvents>

                            <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                <ErrorFrameStyle Font-Size="Large" />
                                <RequiredField IsRequired="True" ErrorText="Valid to is required" />
                            </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2">
                        <dx:ASPxButton OnClick="CalculateAvailableRoomsButton" ID="calculateRoomTypePriceButton" runat="server" Text="Check Availability and Price" ToolTip="Calculates the price and the availability of given days"></dx:ASPxButton>
                    </div>

                </div>

                <script type="text/javascript">
                    function CheckDifference() {
                        var startDate = new Date();
                        var endDate = new Date();
                        var difference = -1;
                        startDate = dateFromCalendar.GetDate();
                        if (startDate != null) {
                            endDate = dateToCalendar.GetDate();
                            var startTime = startDate.getTime();
                            var endTime = endDate.getTime();
                            difference = (endTime - startTime) / 86400000;

                        }
                        return difference;

                    }
                </script>

                <br />
                <div class="row">
                    <div class="col-xs-12">
                        <a style="font-size: 20px; color: black; font-weight: bold">Available Rooms</a>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12 col-sm-8 col-md-8 col-lg-6" style="margin-bottom: 10px">
                        <dx:ASPxGridView ID="availableRoomsGridView" runat="server" Theme="BlackGlass" AutoGenerateColumns="False" KeyFieldName="Id">
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>

                            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>
                            <Columns>

                                <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="4" Visible="False">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="HotelId" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="RoomTypeId" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>

                </div>
                <br />

                <div class="row">
                    <div class="col-xs-0 col-sm-0 col-md-0 col-lg-6">
                    </div>
                    <div class="col-xs-1 col-sm-1 col-md-1 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="System Price :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div class="col-xs-11 col-sm-4 col-md-3 col-lg-2">
                        <dx:ASPxTextBox ID="roomTypePriceTextBox" runat="server" Width="170px" ReadOnly=True></dx:ASPxTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-0 col-sm-0 col-md-0 col-lg-6">
                    </div>
                    <div class="col-xs-1 col-sm-1 col-md-1 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Agreed Price :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div class="col-xs-11 col-sm-4 col-md-3 col-lg-2">
                        <dx:ASPxTextBox ID="agreedPriceTextBox" runat="server" Width="170px">
                        <ClientSideEvents KeyDown="function(s, e) {
	                        if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || (e.htmlEvent.keyCode &gt;= 96&amp;&amp; e.htmlEvent.keyCode &lt;= 105) ||  (e.htmlEvent.keyCode == 188) ||(e.htmlEvent.keyCode == 110) ||
                               (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                e.htmlEvent.keyCode == 39))) 
                            ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }">
                            
                        </ClientSideEvents>
                        </dx:ASPxTextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-0 col-sm-0 col-md-0 col-lg-6">
                    </div>
                    <div class="col-xs-1 col-sm-1 col-md-1 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Search Customer :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div style="height: 45px;" class="col-xs-3 col-sm-3 col-md-3 col-lg-2">
                        <dx:ASPxComboBox OnValueChanged="customerComboBox_OnValueChanged" ID="customerComboBox" NullText="Search Customer" runat="server" ValueField="Id" TextField="Name" IncrementalFilteringMode="Contains" DropDownStyle="DropDown" TextFormatString="{0} {1}">
                            <Columns>
                                <dx:ListBoxColumn FieldName="Name" Visible="True" Caption="Name" />
                                <dx:ListBoxColumn Caption="Surname" FieldName="Surname" />
                            </Columns>
                        </dx:ASPxComboBox>
                         <dx:ASPxButton ID="createCustomerButton" runat="server" Text="New Customer">
                            <ClientSideEvents Click="function(s, e) { ShowLoginWindow(); }" />
                        </dx:ASPxButton>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-0 col-sm-0 col-md-0 col-lg-6">
                    </div>
                    <div class="col-xs-1 col-sm-1 col-md-1 col-lg-2">
                        <dx:ASPxLabel CssClass="Text" ForeColor="#222222" Text="Comments :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                    </div>
                    <div class="col-xs-4 col-sm-4 col-md-3 col-lg-3">
                        <dx:ASPxMemo ID="commentMemoBox" runat="server" Height="71px" Width="170px"></dx:ASPxMemo>
                    </div>
                </div>
                <br/>
                <div class="row">
                    <div class="col-lg-9 col-sm-2 col-md-2 col-xs-4">
                        
                    </div>
                        <div class="col-lg-1 col-sm-2 col-md-2 col-xs-4">
                            <dx:ASPxButton OnClick="saveBookingButton_OnClick" ID="saveBookingButton" CssClass="button" ToolTip="Saves the Booking" ForeColor="AquaMarine" Theme="BlackGlass" runat="server" Text="Save" />
                        </div>
                        <div class="col-lg-1 col-md-2 col-sm-2 col-xs-4">
                            <dx:ASPxButton OnClick="cancelButton_OnClick" ID="cancelButton" runat="server" CssClass="button" ToolTip="Cancel" ForeColor="AquaMarine" Theme="BlackGlass" Text="Cancel" />
                        </div>
                    </div>
                <br />
            </div>
        </div>
    </div>



    <dx:ASPxPopupControl ClientInstanceName="createUserPopUp" Width="330px" Height="250px"
        MaxWidth="900px" MaxHeight="800px" MinHeight="150px" MinWidth="150px" ID="createUserPopUp"
        PopupElementID="imgButton" HeaderText="Customer Details"
        runat="server" EnableViewState="false" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" EnableHierarchyRecreation="True" AllowDragging="True" PopupAnimationType="Fade" Modal="True" Theme="BlackGlass">
        <ModalBackgroundStyle BackColor="Black">
        </ModalBackgroundStyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:Panel ID="Panel1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Name :"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="nameTextBox" ValidateRequestMode="Enabled" ID="nameTextBox" runat="server" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large" />
                                        <RequiredField IsRequired="True" ErrorText="Name is required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Surname:"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="surnameText" ValidateRequestMode="Enabled" ID="surNameTextBox" runat="server" Width="170px">
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large" />
                                        <RequiredField IsRequired="True" ErrorText="Surname is required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Id:"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ClientInstanceName="idNumberText" ID="idNumberTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {
	                                 if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) ||(e.htmlEvent.keyCode &gt;= 96&amp;&amp; e.htmlEvent.keyCode &lt;= 105) || (e.htmlEvent.keyCode &gt;= 65 &amp;&amp; e.htmlEvent.keyCode &lt;= 90) ||
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); }"></ClientSideEvents>
                                    <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip" ErrorTextPosition="Right" SetFocusOnError="true">
                                        <ErrorFrameStyle Font-Size="Large" />
                                        <RequiredField IsRequired="True" ErrorText="Id number is required" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Tax Id :"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="taxIdTextBox" runat="server" Width="170px">

                                    <ClientSideEvents KeyDown="function(s, e) {
	 if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || (e.htmlEvent.keyCode &gt;= 96 &amp;&amp; e.htmlEvent.keyCode &lt;= 105) ||
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent); 
}"></ClientSideEvents>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Address:"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="addressTextBox" runat="server" Width="170px"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Email :"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="emailTextBox" runat="server" Width="170px">
                                    <ValidationSettings>
                                        <RegularExpression ErrorText="Invalid mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Phone :"></asp:Label>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="phoneTextBox" runat="server" Width="170px">
                                    <ClientSideEvents KeyDown="function(s, e) {
	  if (!((e.htmlEvent.keyCode &gt;= 48 &amp;&amp; e.htmlEvent.keyCode &lt;= 57) || (e.htmlEvent.keyCode &gt;= 96 &amp;&amp; e.htmlEvent.keyCode &lt;= 105) ||
                                           (e.htmlEvent.keyCode == 8 || e.htmlEvent.keyCode == 46 || e.htmlEvent.keyCode == 37 || 
                                            e.htmlEvent.keyCode == 39))) 
                                        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
}"></ClientSideEvents>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="pcmButton">
                        <dx:ASPxButton OnClick="CustomersPopUpSaveButton" ID="customersPopUpSaveButton" runat="server" Text="Save" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) {if (eval(&#39;nameTextBox&#39;).lastChangedValue == null || eval(&#39;surnameText&#39;).lastChangedValue == null || eval(&#39;idNumberText&#39;).lastChangedValue == null) {
                                                    return false;
                                                            }
                                                 if(ASPxClientEdit.ValidateGroup(&#39;entryGroup&#39;)) createUserPopUp.Hide(); 
                                                }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="btCancel" runat="server" Text="Cancel" Width="80px" AutoPostBack="False" Style="float: left; margin-right: 8px">
                            <ClientSideEvents Click="function(s, e) { createUserPopUp.Hide(); }" />
                        </dx:ASPxButton>
                    </div>
                </asp:Panel>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

</asp:Content>
