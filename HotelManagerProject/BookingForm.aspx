<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        
            <div style="width: 10%; float: left">
               <label>Room Type</label> 
            </div>
            <div style="width: 50%;">
                <dx:ASPxDropDownEdit ID=ASPxDropDownEdit1 runat="server"></dx:ASPxDropDownEdit> 
            </div>
            
               
        </div>
    
</asp:Content>
