﻿<%@ Page Title="License Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Manage_License.aspx.cs" Inherits="ProgramFiles.Manage_License" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Manage Licenses</h2>
    <p style="text-decoration: underline">
        <strong>Add New License</strong></p>
    <table style="width: 100%">
        <tr>
            <td style="width: 186px">
                License Name :</td>
            <td>
                <asp:TextBox ID="TextBoxNameAdd" runat="server" Width="400px"></asp:TextBox>                
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 186px">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonSubmit" runat="server" onclick="ButtonSubmit_Click" 
                    Text="Submit" Width="87px" />
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <h3>Edit/Delete Licenses</h3>
    <asp:Repeater ID="RepeaterEditOS" runat="server" 
        onitemcommand="RepeaterEditOS_ItemCommand">
    <HeaderTemplate>
        <table class="CheckoutTable">
            <tr>
                <td>
                    <b>LicenseID</b>
                </td>
                <td>
                    <b>LicenseName</b>
                </td>
            </tr>
        </table>
    </HeaderTemplate>
    <ItemTemplate>
        <table class="CheckoutTable">
            <tr>
                <td>
                    <asp:Label ID="LabelOSID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LicenseID") %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LicenseName") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Save" OnClick="ButtonUpdate_Click" CommandName="ButtonUpdate_ClickComm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LicenseID") %>'/>
                </td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CommandName="ButtonDelete_ClickComm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LicenseID") %>'/>
                </td>
            </tr>
        </table>
    </ItemTemplate>
    </asp:Repeater>

    <br/>
    <p>
        <a href="Product_Management.aspx"><strong>&lt;&lt;&lt;Back to Product Management</strong></a></p>
    <p>
    <br />





</asp:Content>
