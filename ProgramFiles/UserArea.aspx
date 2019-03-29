<%@ Page Title="User Area" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="UserArea" Codebehind="UserArea.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <strong>Welcome,
        <asp:Label ID="LabelUserWelcome" runat="server" Text="Username"></asp:Label>
        </strong>
        <p style="text-decoration: underline">
        <strong>Profile</strong></p>
    <p>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            Name       : <%# DataBinder.Eval(Container.DataItem, "FullName") %><br>
            Email      : <%# DataBinder.Eval(Container.DataItem, "Email") %><br>
            Address    : <%# DataBinder.Eval(Container.DataItem, "UserAddress") %><br>
            City       : <%# DataBinder.Eval(Container.DataItem, "City") %><br>
            Phone      : <%# DataBinder.Eval(Container.DataItem, "Phone") %><br>        
        </ItemTemplate>
        </asp:Repeater>
    Active CartID : 
   <asp:Label ID="LabelCartID" runat="server" Text="Label"></asp:Label>
    </p>
   UserID :<asp:Label ID="LabelUserID" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <p style="text-decoration: underline">
        <strong>My Orders</strong></p>
    <p style="text-decoration: underline">
        <asp:Repeater ID="RepeaterEditOS" runat="server">
            <HeaderTemplate>
                <table class="CheckoutTable">
                    <tr>
                        <td>
                            <b>OrderID</b>
                        </td>
                        <td>
                            <b>UserName</b>
                        </td>
                        <td>
                            <b>UserID</b>
                        </td>
                        <td>
                            <b>CartID</b>
                        </td>
                        <td>
                            <b>OrderStatus</b>
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table class="CheckoutTable">
                    <tr>
                        <td>
                            <asp:Label ID="LabelOrderID" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelUserName" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelUserID" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelCartID" runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "CartID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LabelOrderStatus" runat="server" Font-Bold="True" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "OrderStatus") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="ButtonDetails" runat="server" 
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>' 
                                OnClick="ButtonDetails_Click" Text="Details" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </p>
    <br />
    <p style="text-decoration: underline">
        <strong>Log Out</strong></p>
    <p>
        <asp:Button ID="ButtonLogOut" runat="server" Text="Log Out" 
            CausesValidation="False" CssClass="AddCart_button" 
            onclick="ButtonLogOut_Click" />
    </p>
    <p>
        &nbsp;</p>
    
</asp:Content>

