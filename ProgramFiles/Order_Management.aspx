<%@ Page Title="Order Management" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Order_Management.aspx.cs" Inherits="ProgramFiles.Order_Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Order Management</h2>

Order Status : 
    <asp:RadioButtonList ID="RadioButtonListStatusOption" runat="server" 
        RepeatDirection="Horizontal" AutoPostBack="True" 
        onselectedindexchanged="RadioButtonListStatusOption_SelectedIndexChanged">
        <asp:ListItem>All</asp:ListItem>
        <asp:ListItem>Awaiting Payment</asp:ListItem>
        <asp:ListItem>On Process</asp:ListItem>
        <asp:ListItem>Completed</asp:ListItem>
    </asp:RadioButtonList>

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
                    <asp:Label ID="LabelOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'></asp:Label>
                </td> 
                <td>
                    <asp:Label ID="LabelUserName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelUserID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelCartID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CartID") %>'></asp:Label>
                </td>
                
                <td>
                    <asp:Label ID="LabelOrderStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderStatus") %>' Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="ButtonDetails" runat="server" Text="Details" OnClick="ButtonDetails_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>'/>
                </td>
                                     
            </tr>
        </table>
    </ItemTemplate>
    </asp:Repeater>


</asp:Content>
