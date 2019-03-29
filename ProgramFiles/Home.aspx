<%@ Page Title="Home - Program Files" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="_Default" Codebehind="Home.aspx.cs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="Content">
        <asp:SqlDataSource ID="ProgramFilesDBSource" runat="server" ConnectionString="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS"
            ProviderName="System.Data.SqlClient" SelectCommand="select * from Products"></asp:SqlDataSource>
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <h3>Featured Products</h3>
        </HeaderTemplate>
            <ItemTemplate>
                <div class="repeater_ProductList">
                <div class="repeater_image"> <img src='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' alt='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>'/></div>                
                <div class="repeater_ProductName"><%# DataBinder.Eval(Container.DataItem, "ProductName") %></div>                
                <div class="repeater_ProductCategory"><%# DataBinder.Eval(Container.DataItem, "CategoryName") %></div>
                <div class="repeater_ProductOS"><%# DataBinder.Eval(Container.DataItem, "OSName") %></div>
                <div class="repeater_ProductSize"><%# DataBinder.Eval(Container.DataItem, "ProductSize") %> MB</div>   
                <div class="Details_Button">
                  		<p><a href="Product_Details.aspx?ProductID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>">Details</a></p>
                </div>               
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
