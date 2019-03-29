<%@ Page Title="Search Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Search" Codebehind="Search.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p style="text-decoration: underline">
        <strong>Search Products</strong></p>
    <table style="width: 100%">
        <tr>
            <td style="height: 25px; width: 203px">
        Search Products</td>
            <td style="height: 25px">
                <br />
                Search by :<asp:RadioButtonList ID="RadioButtonListSearchType" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">ProductID</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>CategoryID</asp:ListItem>
                    <asp:ListItem>OSID</asp:ListItem>
                    <asp:ListItem>LicenseID</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="TextBoxProductSearch" runat="server" Width="362px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxProductSearch" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="ButtonProductSearch" runat="server" Text="Search" 
                    onclick="ButtonProductSearch_Click" CssClass="AddCart_button"/>
            </td>
        </tr>
        
    </table>
    <p>
        &nbsp;</p>
    <p>
&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>

</asp:Content>

