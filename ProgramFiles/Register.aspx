<%@ Page Title="Registration Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Register" Codebehind="Register.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <strong>Registration Form</strong><table style="width: 100%">
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
                    Email</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxEmail" runat="server" Width="440px" MaxLength="30" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="TextBoxEmail" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="TextBoxEmail" ErrorMessage="   Invalid Email Format" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Full Name</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxName" runat="server" Width="440px" MaxLength="50" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBoxName" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Address</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxAddress" runat="server" Width="440px" Height="60px" 
                        MaxLength="100" TextMode="MultiLine" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="TextBoxAddress" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    City</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxCity" runat="server" Width="440px" MaxLength="30" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TextBoxCity" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Province</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxProvince" runat="server" Width="440px" MaxLength="50" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="TextBoxProvince" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Country</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxCountry" runat="server" Width="440px" MaxLength="30" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="TextBoxCountry" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Postal Code</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxPostal" runat="server" Width="440px" MaxLength="10" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="TextBoxPostal" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 140px">
                    Phone</td>
                <td style="width: 459px">
                    <asp:TextBox ID="TextBoxPhone" runat="server" Width="440px" MaxLength="20" CssClass="textbox"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="TextBoxPhone" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ErrorMessage="Must contains numbers only" ForeColor="Red" 
                        ValidationExpression="^\d+$" ControlToValidate="TextBoxPhone"></asp:RegularExpressionValidator>
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
            </tr>
            <tr>
                <td style="width: 140px">
                    &nbsp;</td>
                <td style="width: 459px">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    Already Registered?
                    <asp:Button ID="ButtonLogin" runat="server" CausesValidation="False" 
                        CssClass="AddCart_button" onclick="ButtonLogin_Click" Text="Login" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

