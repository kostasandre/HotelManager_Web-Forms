<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingWebForm.aspx.cs" Inherits="HotelManagerProject.BillingWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div class="billingdiv">
    <dx:ASPxGridView ID="BillingGridView" runat="server" AutoGenerateColumns="False" Theme="BlackGlass">
        <Columns>
				
				<dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowClearFilterButton="True" ShowSelectCheckbox="True" VisibleIndex="0" ButtonRenderMode="Image">
				</dx:GridViewCommandColumn>
				<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
					<CustomButtons>
						<dx:GridViewCommandColumnCustomButton ID="editButton">
							<Image Url="Images/edit.png" ToolTip="Edit"></Image>
						</dx:GridViewCommandColumnCustomButton>
					</CustomButtons>
				</dx:GridViewCommandColumn>
				 <dx:GridViewDataTextColumn FieldName="CompanyName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="4" Visible="False">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Code" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Balance" VisibleIndex="6">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="7">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="8">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Updated" VisibleIndex="9">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="UpdatedBy" VisibleIndex="11">
				</dx:GridViewDataTextColumn>
			</Columns>
    </dx:ASPxGridView>
        <div class="billingTextBox">
            <dx:ASPxLabel CssClass="Text" ForeColor="Aquamarine" Text="Sum of Services :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
            <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
        </div>
         <div class="billingTextBox">
            <dx:ASPxLabel CssClass="Text2" ForeColor="Aquamarine" Text="Total Sum :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
            <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
        </div>
    <dx:ASPxCheckBox CssClass="billingCheckBox" runat="server"></dx:ASPxCheckBox>
        </div>
    <br>
    <br>
     <br>
    <br>
     <br>
    <br>
     <br>
    
     <div class="billingTextBox">
            <dx:ASPxButton CssClass="Text2" ForeColor="Aquamarine" Text="Save" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
            <dx:ASPxButton runat="server" CssClass="Text2" ForeColor="Aquamarine" Text="Cancel" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
        </div>
        </div>
</asp:Content>
