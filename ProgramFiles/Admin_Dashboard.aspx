<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Admin_Dashboard" Codebehind="Admin_Dashboard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Site Administration</h2>
    <p style="text-decoration: underline">
        <strong>Manage Products</strong></p>
    <p>
        Add, delete, and edit products.</p>
        <div class="AddCart_button">
                  		<p><a href="Product_Management.aspx">Manage Products></a></p>
                  </div>  
    <p style="text-decoration: underline">
        <strong>Manage Orders</strong></p>
        <div class="AddCart_button">
                  		<p><a href="Order_Management.aspx">Manage Orders></a></p>
                  </div>  

    <p style="text-decoration: underline">
        <strong>Manage Users</strong></p>
        <div class="AddCart_button">
                  		<p><a href="User_Management.aspx">Manage Users></a></p>
                  </div>  
    
</asp:Content>

