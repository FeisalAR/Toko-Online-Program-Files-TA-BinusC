<%@ Page Title="Order Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Order_Details.aspx.cs" Inherits="ProgramFiles.Order_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Order Details</h2>

    <asp:Repeater ID="RepeaterOrderDetails" runat="server">
        <ItemTemplate>
                OrderID:<asp:Label ID="LabelOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>' Font-Bold="True"></asp:Label>
                <br>
                OrderStatus:<asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderStatus") %>' Font-Bold="True"></asp:Label>
                <br>
                OrderDate:<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderDate") %>'></asp:Label>
                <br>
                UserID:<asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'></asp:Label>
                <br>
                UserName:<asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>'></asp:Label>
                <br>
                CartID:<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CartID") %>'></asp:Label>
                <br>
                FinalPrice: Rp.<asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FinalPrice") %>'></asp:Label>
                <br>
                NumberOfItems:<asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfItems") %>'></asp:Label>
                <br>
                CDNeeded: <asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CDNeeded") %>'></asp:Label>CD
                <br>
                <br>
                Recipient Name:<asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientName") %>'></asp:Label>
                <br>
                Recipient Address:<asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientAddress") %>'></asp:Label>
                <br>
                Recipient City:<asp:Label ID="Label11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientCity") %>'></asp:Label>
                </br>
                Recipient Province/State :<asp:Label ID="Label12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientProvince") %>'></asp:Label>
                </br>
                Recipient Phone:<asp:Label ID="Label13" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientPhone") %>'></asp:Label>
                </br>
                Recipient Postal Code:<asp:Label ID="Label14" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientPostalCode") %>'></asp:Label>
                </br>
                <br>
                Delivery Service Type:<asp:Label ID="Label15" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryServiceType") %>'></asp:Label>
                </br>
                Payment Method:<asp:Label ID="Label16" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentMethod") %>'></asp:Label>
                </br>
                Customer Bank Account Name:<asp:Label ID="Label17" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBankAccountName") %>'></asp:Label>
                </br>
                Customer Bank Account Number:<asp:Label ID="Label18" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBankAccountNumber") %>'></asp:Label>
                </br>
                Customer Bank:<asp:Label ID="Label19" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBank") %>'></asp:Label>
                </br>

        </ItemTemplate> 
    </asp:Repeater>

<h3>Ordered Items</h3>
    <asp:ListView ID="ListViewCheckout" runat="server">
        <ItemTemplate>
            <table class="CheckoutTable">
                <tr>
                    <td>
                         <div><%# DataBinder.Eval(Container.DataItem, "ProductName") %></div>                 
                    </td>
                    <td>
                         <div><%# DataBinder.Eval(Container.DataItem, "ProductSize") %> MB</div> 
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:ListView>
    <p>&nbsp;</p>
    <asp:Label ID="LabelChangeStatus" runat="server" Text="Change Order Status :" Font-Bold="True"></asp:Label>
    <asp:RadioButtonList ID="RadioButtonListStatusOption" runat="server" 
        RepeatDirection="Horizontal" AutoPostBack="True" 
        onselectedindexchanged="RadioButtonListStatusOption_SelectedIndexChanged">
        <asp:ListItem Selected="True">Awaiting Payment</asp:ListItem>
        <asp:ListItem>On Process</asp:ListItem>
        <asp:ListItem>Completed</asp:ListItem>
    </asp:RadioButtonList>

</asp:Content>
