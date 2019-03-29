<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ProgramFiles.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3>Checkout</h3>

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
    Number of Items :<asp:Label ID="LabelNumberofItems" runat="server" Text="Label"></asp:Label>
    <br />
    Total Size : 
    <asp:Label ID="LabelTotalSize" runat="server" Text="Label"></asp:Label>
    &nbsp;MB
    <br/>
    CD Needed : 
        <asp:Label ID="LabelCDNeeded" runat="server" Text="Label"></asp:Label> &nbsp;CD&nbsp;: Rp.&nbsp;<asp:Label ID="LabelCDPrice" runat="server" Text="Label"></asp:Label>
    <br />
    Burning Fee : Rp.&nbsp; 
    <asp:Label ID="LabelBurningFee" runat="server" Text="Label"></asp:Label>


    <br />
    Total Weight:&nbsp;
    <asp:Label ID="LabelCDWeight" runat="server" Text="Label"></asp:Label>&nbsp;Kg&nbsp; 
    ---&gt;&nbsp;<asp:Label ID="LabelCDWeightRounded" runat="server" Text="Label"></asp:Label> &nbsp;Kg
    <br />
    <br />
    Delivery Options<br />
    Delivery Service Type (per Kg) :<asp:RadioButtonList ID="RadioButtonListServiceType" 
        runat="server" AutoPostBack="True" Height="56px" RepeatDirection="Horizontal" 
        Width="566px" 
        onselectedindexchanged="RadioButtonListServiceType_SelectedIndexChanged">
        <asp:ListItem Value="45000">Priority (Rp. 45.000)</asp:ListItem>
        <asp:ListItem Value="33000">Regular (Rp. 33.000)</asp:ListItem>
        <asp:ListItem Value="21000">Economy (Rp. 21.000)</asp:ListItem>
    </asp:RadioButtonList>
    Delivery Fee: Rp.&nbsp;<asp:Label ID="LabelDeliveryFee" runat="server" Text="Please Select Delivery Service Type"></asp:Label>
    <br />
    <br />
    Total Price : Rp.&nbsp;
    <asp:Label ID="LabelTotalPrice" runat="server" Text="Please Select Delivery Service Type"></asp:Label>
    <br />
    <br />
    


<div class="Details_Button">
      <p><asp:LinkButton ID="LinkButtonDPDetails" runat="server" 
              onclick="LinkButtonDPDetails_Click">Delivery & Payment Details &gt;&gt;</asp:LinkButton></p>    
 </div>
</asp:Content>
