<%@ Page Title="Product Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Product_Management" Codebehind="Product_Management.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p style="text-decoration: underline">
        <strong>Product Management</strong></p>
    <table style="width: 100%">
        <tr>
            <td style="width: 203px">
        Add New Product</td>
            <td>
                <asp:Button ID="ButtonAddProuct" runat="server" Text="Add..." 
                    onclick="ButtonAddProuct_Click" CssClass="AddCart_button" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="width:203px">Manage Categories</td>
            <td>
                <asp:Button ID="ButtonCategory" runat="server" Text="Edit..." 
                    onclick="ButtonCategory_Click" CssClass="AddCart_button" 
                    CausesValidation="False"/>
            </td>
        </tr>
        <tr>
            <td style="width: 203px">
                Manage Operating Systems</td>
            <td>
                <asp:Button ID="ButtonOS" runat="server" Text="Edit..." 
                    CssClass="AddCart_button" onclick="ButtonOS_Click" 
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 203px">
                Manage Licenses</td>
            <td>
                <asp:Button ID="ButtonLicenseAdd" runat="server" Text="Edit..." 
                    CssClass="AddCart_button" onclick="ButtonLicenseAdd_Click" 
                    CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="height: 25px; width: 203px">
        Search Products>
        Search Products</td>
            <td style="height: 25px">
                <br />
                Search by :<asp:RadioButtonList ID="RadioButtonListSearchType" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>ProductID</asp:ListItem>
                    <asp:ListItem>Name</asp:ListItem>
                    <asp:ListItem>CategoryID</asp:ListItem>
                    <asp:ListItem>OSID</asp:ListItem>
                    <asp:ListItem>LicenseID</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox ID="TextBoxProductSearch" runat="server" Width="362px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxProductSearch" ErrorMessage="Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="RadioButtonListSearchType" 
                    ErrorMessage="Choose Search Criteria" ForeColor="Red"></asp:RequiredFieldValidator>
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

</asp:Content>

