<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="ProgramFiles.AdminRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<strong>Administrator Registration Form</strong><table style="width: 100%">
            <tr>
                <td style="width: 140px">
                    Username</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxUser" runat="server" Width="440px" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelUsername" runat="server" Text="Username already taken" 
                        ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="TextBoxUser" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px; height: 1px">
                    Password</td>
                <td style="height: 1px; width: 459px">
                    <asp:TextBox ID="TextBoxPass" runat="server" Width="440px" MaxLength="20" 
                        TextMode="Password" CssClass="textbox"></asp:TextBox>
                </td>
                <td style="height: 1px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBoxPass" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    &nbsp;</td>
                <td style="width: 459px">
                    <asp:Button ID="Button1" runat="server" Text="Register" 
                        onclick="Button1_Click" CssClass="AddCart_button" />
                </td>
                <td>
                    &nbsp;</td>
                    <td>
                    Already Registered?
                    <asp:Button ID="ButtonLogin" runat="server" CausesValidation="False" 
                        CssClass="AddCart_button" onclick="ButtonLogin_Click" Text="Login" />
                </td>
            </tr>
            </table>
</asp:Content>
