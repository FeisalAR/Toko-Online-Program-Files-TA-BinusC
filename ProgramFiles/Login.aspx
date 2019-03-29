<%@ Page Title="Log In Form" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Login" Codebehind="Login.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Log In Form" 
        style="font-weight: 700"></asp:Label>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 182px">
                Username</td>
            <td style="width: 240px">
                <asp:TextBox ID="TextBoxUsername" runat="server" Width="242px" 
                    ValidationGroup="RequiredFields" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="UsernameFieldValidator" runat="server" 
                    ControlToValidate="TextBoxUsername" ErrorMessage="Username Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                Password</td>
            <td style="width: 240px">
                <asp:TextBox ID="TextBoxPassword" TextMode="Password" runat="server" 
                    Width="242px" ValidationGroup="RequiredFields" CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="PassFieldValidator" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="Password Required" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 182px">
                &nbsp;</td>
            <td style="width: 240px">
                <asp:Button ID="ButtonLogin" runat="server" onclick="ButtonLogin_Click" 
                    Text="Login" Width="71px" CssClass="AddCart_button" />
            </td>
            <td>
                </td>
        </tr>
        <tr>
            <td style="width: 182px">
                <asp:Label ID="LabelNotification" runat="server" BorderColor="#FF9900" 
                    BorderStyle="Solid" BorderWidth="1px" ForeColor="#FF9900" Width="174px"></asp:Label>
            </td>
            <td style="width: 240px">
                <asp:Label ID="LabelIncorrect" runat="server" ForeColor="Red" 
                    Text="Incorrect Username or Password"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    &nbsp;<table style="width: 100%">
        <tr>
            <td style="height: 25px; width: 77px">
                New User?</td>
            <td style="height: 25px">
                <asp:Button ID="ButtonRegister" runat="server" onclick="ButtonRegister_Click" 
                    Text="Register" CausesValidation="False" CssClass="AddCart_button" />
            </td>
        </tr>
    </table>
    <br />
   
</asp:Content>

