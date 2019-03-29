<%@ Page Title="Order Successful" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="OrderSubmitted.aspx.cs" Inherits="ProgramFiles.ConfirmPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3>Order Successfully Placed!</h3>


    <b>OrderID : <asp:Label ID="LabelOrderID" runat="server" Text="Label" Font-Bold="True"></asp:Label></b>

 <p>We will process your order as soon as possible. Please send your payment receipt to <b><a href="payments@pfsoft.co.uk">payments@shekelsoft.co.uk</a></b> along with the <b>Order ID</b> above to speed up the verification process. Thank you.</p>
    <b>Payment Information :<br /></b>
    Bank : Barclays Bank<br />
    Bank Account Name : PT. Shekelsoft<br />
    Bank Account Number : 1204-123989<br />
    <br />
    Payments will be be processed during business hours.<br />
<h4>Order Information :</h4>
<asp:Repeater ID="RepeaterOrderDetails" runat="server">
        <ItemTemplate>
                <b>OrderID:<asp:Label ID="LabelOrderID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>' Font-Bold="True"></asp:Label>
                <br />
                FinalPrice: Rp.<asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FinalPrice") %>' Font-Bold="True"></asp:Label>
                <br /></b>
                Recipient Name:<asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientName") %>'></asp:Label>
                <br>
                Recipient Address:<asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientAddress") %>'></asp:Label>
                <br>
                Recipient City:<asp:Label ID="Label11" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientCity") %>'></asp:Label>
                </br>
                Recipient Province/State :<asp:Label ID="Label12" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientProvince") %>'></asp:Label>
                </br>
                Recipient Phone:<asp:Label ID="Label13" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientPhone") %>'></asp:Label>
                <br>
                </br>
                Recipient Postal Code:<asp:Label ID="Label14" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RecipientPostalCode") %>'></asp:Label>
                <br>
                </br>
                <br>
                Delivery Service Type:<asp:Label ID="Label15" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryServiceType") %>'></asp:Label>
                </br>
                Payment Method:<asp:Label ID="Label16" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PaymentMethod") %>'></asp:Label>
                <br>
                </br>
                Customer Bank Account Name:<asp:Label ID="Label17" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBankAccountName") %>'></asp:Label>
                <br>
                </br>
                Customer Bank Account Number:<asp:Label ID="Label18" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBankAccountNumber") %>'></asp:Label>
                <br>
                </br>
                Customer Bank:<asp:Label ID="Label19" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerBank") %>'></asp:Label>
                <br>
                </br>

        </ItemTemplate> 
    </asp:Repeater>
</asp:Content>
