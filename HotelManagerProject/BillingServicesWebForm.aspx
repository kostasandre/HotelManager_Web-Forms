<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BillingServicesWebForm.aspx.cs" Inherits="HotelManagerProject.BillingWebForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="width: 100%">

        <div class="row">
            <div class="col-xs-2">
            </div>
            <div class="col-xs-1">
                <dx:ASPxButton ID="SearchButton" runat="server" ToolTip="Search for your desired booking." Theme="BlackGlass">
                    <Image Width="50px" Height="20px" Url="Images/searched.jpg"></Image>
                </dx:ASPxButton>
            </div>
            <div class="col-xs-2 billingdiv2">
                <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Booking :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
            <div class="col-xs-2 billingdiv2" >
                 <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Price :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
             <div class="col-xs-2 billingdiv2" >
                 <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Customer :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
        </div>
    </div>

    <div class="container" style="width: 100%">
        <br>
        <br>

        <div class="row">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-4">
                <dx:ASPxGridView ID="BillingGridView" runat="server" AutoGenerateColumns="False" Theme="BlackGlass" EnableTheming="True">
                    <Settings ShowFilterRow="True" ShowGroupPanel="True" />
                    <SettingsSearchPanel Visible="True" />
                    <Columns>

                        <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="1" ButtonRenderMode="Image">
                            <CustomButtons>
                                <dx:GridViewCommandColumnCustomButton ID="editButton">
                                    <Image Url="Images/edit.png" ToolTip="Edit"></Image>
                                </dx:GridViewCommandColumnCustomButton>
                            </CustomButtons>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn FieldName="Service Type" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="4" Visible="False">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Quantity" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Price" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="Created" VisibleIndex="7">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-4">
            </div>
            <div class="col-xs-3 billingdiv">
                <dx:ASPxLabel CssClass="Text" ForeColor="Aquamarine" Text="Sum of Services :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>

        </div>
        <div class="row">
            <div class="col-xs-3">
            </div>
            <div class="col-xs-1 billingdiv2">
                 <dx:ASPxLabel CssClass="Text" ForeColor="AquaMarine" runat="server" Text="Paid :" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxCheckBox runat="server"></dx:ASPxCheckBox>
            </div>
            <div class="col-xs-3 billingdiv">
                <dx:ASPxLabel CssClass="Text2" ForeColor="Aquamarine" Text="Total Sum :" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxLabel>
                <dx:ASPxTextBox runat="server"></dx:ASPxTextBox>
            </div>
        </div>
        <br>
        <br>
        <br>
        <div class="row">
            <div class="col-xs-9">
            </div>
            <div class="col-xs-1 billingdiv">
                <dx:ASPxButton CssClass="Text2" ForeColor="Aquamarine" Text="Save" runat="server" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
            </div>
            <div class="col-xs-2 billingdiv">
                <dx:ASPxButton runat="server" CssClass="Text2" ForeColor="Aquamarine" Text="Cancel" EnableTheming="True" Theme="BlackGlass"></dx:ASPxButton>
            </div>
        </div>


    </div>

</asp:Content>
