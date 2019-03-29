<%@ Page Title="User Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="User_Management.aspx.cs" Inherits="ProgramFiles.User_Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Users</h3>

    <asp:Repeater ID="RepeaterUsers" runat="server">
        <HeaderTemplate>
        <table class="CheckoutTable">
            <tr>
                <td>
                    <b>UserID</b>
                </td>
                <td>
                    <b>Username</b>
                </td>
                <td>
                    <b>UserGroup</b>
                </td>
            </tr>
        </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="CheckoutTable">
            <tr>
                <td>
                    <asp:Label ID="LabelOSID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxUserGroup" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserGroup") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Save" OnClick="ButtonUpdate_Click"/>
                </td>
                <td>
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete"/>
                </td>
            </tr>
        </table>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
