<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BookingForm.aspx.cs" Inherits="HotelManagerProject.BookingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="MainForm">
        
        <h1>Booking Form</h1>
        <div>
           
             <div class="dropdown">
                 <label>Room Type</label>
                <button class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">Tutorials
                <span class="caret"></span></button>
                <ul class="dropdown-menu">
                  <li><a href="#">Normal</a></li>
                  <li class="disabled"><a href="#">Disabled</a></li>
                  <li class="active"><a href="#">Active</a></li>
                  <li><a href="#">Normal</a></li>
                </ul>
              </div>
        </div>
    </div>
</asp:Content>
