<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ProgramFiles.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Shopping Cart</h3>
    <br />
    <asp:Label ID="LabelEmptyCart" runat="server" 
        Text="Your Shopping Cart is empty" Font-Bold="True" Font-Size="Larger"></asp:Label>
    <br />
    <asp:Repeater ID="RepeaterShoppingCart" runat="server">
        <HeaderTemplate>            
        </HeaderTemplate>
        <ItemTemplate>
            <div class="repeater_ProductList">            
                <div class="repeater_image"> <img src='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' width='100px' alt='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>'/></div>                
                <div class="repeater_ProductSize"><%# DataBinder.Eval(Container.DataItem, "ProductName") %></div> 
                <div class="repeater_ProductSize"><%# DataBinder.Eval(Container.DataItem, "ProductSize") %> MB</div> 
                <div class="Details_Button">
                    <asp:LinkButton ID="RemoveButton" runat="server" OnClick="RemoveButton_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Remove</asp:LinkButton>
                </div>
            </div>  
        </ItemTemplate>
    </asp:Repeater>
    Number of Items ::&nbsp;<asp:Label ID="LabelNumberofItems" runat="server" Text="Label"></asp:Label>
    <br />
    Total Size : 
    <asp:Label ID="LabelTotalSize" runat="server" Text="Label"></asp:Label>
    &nbsp;MB
    <br/>
    CD Needed : 
        <asp:Label ID="LabelCDNeeded" runat="server" Text="Label"></asp:Label> &nbsp;CD
    
    <div class="Checkout_Button">    
        <p>
            <asp:LinkButton ID="LinkButtonCheckout" runat="server" 
                onclick="LinkButtonCheckout_Click">Checkout</asp:LinkButton></p>
    </div> 
</asp:Content>
