<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="True" Inherits="Product_Details" Codebehind="Product_Details.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
    <%# DataBinder.Eval(Container.DataItem, "ItemTitle")%>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="AlbumDetail">
                <div class="detail_image"><img src="<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>" alt="<%# DataBinder.Eval(Container.DataItem, "ProductName") %>"/></div>
                <div class="detail_wrapper">                
                    <div class="detail_ProductName"><%# DataBinder.Eval(Container.DataItem, "ProductName") %></div>
                    <div class="detail_OS">Operating System : <%# DataBinder.Eval(Container.DataItem, "OSName") %></div>
                    <div class="detail_Category">Category : <%# DataBinder.Eval(Container.DataItem, "CategoryName") %></div>
                    <div class="detail_License">License : <%# DataBinder.Eval(Container.DataItem, "LicenseName") %></div>
                    <div class="detail_Description">Description : <%# DataBinder.Eval(Container.DataItem, "ProductDescription") %></div>
                    <div class="detail_ProductSize">Size : <%# DataBinder.Eval(Container.DataItem, "ProductSize") %>  MB</div>
                    <div class="detail_ProductRating">User Rating : <%# DataBinder.Eval(Container.DataItem, "RatingTotal") %>  / 5.00</div>
                    <div class="AddCart_button"><p> <asp:LinkButton ID="AddtoCartButton" runat="server" OnClick="AddtoCartButton_Click" CausesValidation="False">Add to Cart</asp:LinkButton></p>                                       
                    </div>     
                    <br />                              
          </div> 
                </div>              
    </ItemTemplate>

    </asp:Repeater>
    
    <div class="AddCart_button">
                <p> 
                    <asp:LinkButton ID="LinkButtonEdit" runat="server" 
                        OnClick="LinkButtonEdit_Click" CausesValidation="False">Edit</asp:LinkButton></p> 
                </div> 
    <div class="Details_Button">
    <asp:LinkButton ID="LinkButtonBackToManagement" runat="server" 
            onclick="LinkButtonBackToManagement_Click" CausesValidation="False">Back To Product Management</asp:LinkButton>
    </div>

    <div class="ReviewWrapper">
    <h3>User Reviews</h3>
        <asp:Repeater ID="RepeaterReview" runat="server" 
            onitemcommand="RepeaterReview_ItemCommand">
        <ItemTemplate>
            <asp:Label ID="LabelUsername" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserName") %>' Font-Bold="True" Font-Underline="True"></asp:Label>
            <br />
            <asp:Label ID="LabelUserRating" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Rating") %>'></asp:Label>/5
            <br />
            <asp:Label ID="LabelCommentText" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CommentText") %>'></asp:Label>
            <br />
            <asp:Label ID="LabelUserID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' Visible="False"></asp:Label>
            <asp:Label ID="LabelCommentID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CommentID") %>' Visible="False"></asp:Label>
            
            
        <% string LoginStatus = string.Format("{0}", Session["SessionUserName"]);
        if (LoginStatus == "") //VISITOR
        {%>         
            <asp:LinkButton ID="LinkButtonDeleteComment1" runat="server" Visible='false' CausesValidation="False" OnClick="DeleteComment_Click">Delete</asp:LinkButton>
        <%} %>
        <%else if (Session["SessionUserGroup"].ToString() == "0") //ADMIN
        { %>
            <asp:LinkButton ID="LinkButtonDeleteComment2" runat="server" Visible='true' CausesValidation="False" OnClick="DeleteComment_Click">Delete</asp:LinkButton>               
        <%}
        else if (Session["SessionUserGroup"].ToString() == "1") //REGISTERED USER
        { %>
       
            <asp:LinkButton ID="LinkButtonDeleteComment3" runat="server" Visible='false' CausesValidation="False" OnClick="DeleteComment_Click">Delete</asp:LinkButton>
        <%}%>               
               

            <br />
            <br />

        </ItemTemplate>
        <SeparatorTemplate><hr /></SeparatorTemplate>
        </asp:Repeater>

        <h3>Add New Review</h3>
        Your Rating :
        <asp:DropDownList ID="DropDownListRating" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorRating" runat="server" 
            ErrorMessage="Please select a rating" ControlToValidate="DropDownListRating"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TextBoxReview" runat="server" Height="102px" TextMode="MultiLine" 
            Width="677px"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonPost" runat="server" Text="Submit" 
            onclick="ButtonPost_Click" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorReviewText" runat="server" 
            ErrorMessage="Please leave a review" ControlToValidate="TextBoxReview"></asp:RequiredFieldValidator>
        <br />
        <br />

    </div>
</asp:Content>

