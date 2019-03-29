<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Search_Result" Codebehind="Search_Result.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
 <p style="text-decoration: underline">
        <strong>Search Result of '
        </strong>
        <asp:Label ID="LabelSearchValue" runat="server" Text="Label" 
            style="font-weight: 700"></asp:Label>
        <strong>&#39;</strong></p>
    <p style="text-decoration: underline"></p>
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <div class="AlbumList">
        <div class="repeater_image"><img src="<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>" width="50px" alt="Cover Image"/></div>            
            ProductName : <%# DataBinder.Eval(Container.DataItem, "ProductName") %><br />            
            Category : <%# DataBinder.Eval(Container.DataItem, "CategoryName") %><br />
            OSName : <%# DataBinder.Eval(Container.DataItem, "OSName") %><br />
            ProductID : <%# DataBinder.Eval(Container.DataItem, "ProductID") %><br />
            <div class="Details_Button">
                  		<p><a href="Product_Details.aspx?ProductID=<%# DataBinder.Eval(Container.DataItem, "ProductID") %>">Details</a></p>
                  </div>
            </div>
        </ItemTemplate>
        </asp:Repeater>
</asp:Content>

