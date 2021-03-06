﻿<%@ Page Title="Add New Product" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="AddProduct" Codebehind="AddProduct.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p style="text-decoration: underline">
        <strong>Add New Product</strong></p>
    <table style="width: 100%">
        <tr>
            <td style="width: 172px">
                Name</td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxName" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                Size (MB)</td>
            <td>
                <asp:TextBox ID="TextBoxSize" runat="server" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxSize" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>        
        <tr>
            <td style="width: 172px">
                CategoryID</td>
            <td>
                <asp:TextBox ID="TextBoxCategoryID" runat="server" Height="22px" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBoxCategoryID" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                OSID</td>
            <td>
                <asp:TextBox ID="TextBoxOSID" runat="server" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TextBoxOSID" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                LicenseID</td>
            <td>
                <asp:TextBox ID="TextBoxLicenseID" runat="server" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="TextBoxLicenseID" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                Description (Optional)</td>
            <td>
                <asp:TextBox ID="TextBoxDescription" runat="server" Width="400px" Height="100px" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                Image Path / URL</td>
            <td>
                <asp:TextBox ID="TextBoxImagePath" runat="server" Width="400px"></asp:TextBox>                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 172px">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" Width="106px" 
                    onclick="ButtonSubmit_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <p>
        <a href="AddProduct.aspx"><strong>Reset Form</strong></a></p>
    <p>
    <p>
        <a href="Product_Management.aspx"><strong>&lt;&lt;&lt;Back to Product Management</strong></a></p>
    <p>
        &nbsp;</p>
    
</asp:Content>

