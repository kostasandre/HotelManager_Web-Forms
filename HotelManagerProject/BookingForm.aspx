<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        
            <div style="width: 10%; float: left">
               <label>Room Type</label> 
            </div>
            <div style="width: 50%;">
                <dx:ASPxComboBox ID=ASPxComboBox1 runat="server" ValueType="System.String"></dx:ASPxComboBox>  
            </div>
            
               
        </div>
    
</asp:Content>
