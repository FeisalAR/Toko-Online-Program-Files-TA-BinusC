<%@ Page Title="Payment & Delivery Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ProgramFiles.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3>Choose Payment Method</h3>

    <asp:RadioButtonList ID="RadioButtonListPaymentMethod" runat="server" 
        onselectedindexchanged="RadioButtonListPaymentMethod_SelectedIndexChanged">
        <asp:ListItem>Bank Transfer</asp:ListItem>
        <asp:ListItem>Cash</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    -Bank Transfer : 
    PT. Shekelsoft - Account No. 1204-123989 - Barclays Bank London
    <br />
    -Cash by mail  :  
    PT. Shekelsoft, 13 Downing Street, London, SW1 1AA 0DT
<h4>Customer Bank Account Information</h4>
    <p>Name : </p>
    <p>
        <asp:TextBox ID="TextBoxBAIName" runat="server" Width="331px"></asp:TextBox>
    </p>
    <p>Bank Name :</p>
    <p>
        <asp:TextBox ID="TextBoxBAIBank" runat="server" Width="326px"></asp:TextBox>
    </p>
    <p>Account Number :</p>
    <p>
        <asp:TextBox ID="TextBoxBAINumber" runat="server" Width="323px"></asp:TextBox>
    </p>

<h3>Delivery Details</h3>
Recipient Name:
<br />
<asp:TextBox ID="TextBoxRName" runat="server" Width="341px"></asp:TextBox>
<br />
<br />
    
Recipient Address:
<br />
    <asp:TextBox ID="TextBoxRAddress" runat="server" Width="582px" Height="60px"></asp:TextBox>
<br />
<br />
Recipient City:
<br />
    <asp:TextBox ID="TextBoxRCity" runat="server" Width="243px"></asp:TextBox>
<br />
<br />
Recipient Province/State:
<br />
    <asp:TextBox ID="TextBoxRProvince" runat="server" Width="241px"></asp:TextBox>
<br />
<br />
Recipient Postal Code:
<br />
    <asp:TextBox ID="TextBoxRPostal" runat="server" Width="170px"></asp:TextBox>
<br />
<br />
Recipient Phone:
<br />
    <asp:TextBox ID="TextBoxRPhone" runat="server" Width="167px"></asp:TextBox>
<br />
<br />
<br />



<div class="Details_Button">
      <p><asp:LinkButton ID="LinkButtonPlaceOrder" runat="server" 
              onclick="LinkButtonPlaceOrder_Click">Place Order</asp:LinkButton></p>
 </div> 
    
</asp:Content>
