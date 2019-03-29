using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Product_Details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string LoginStatus = string.Format("{0}", Session["SessionUserName"]);
        if (LoginStatus == "") //VISITOR
        {
            LinkButtonEdit.Visible = false;
            LinkButtonBackToManagement.Visible = false;

        }
        else if (Session["SessionUserGroup"].ToString() == "0") //ADMIN
        {
            LinkButtonEdit.Visible = true;
            LinkButtonBackToManagement.Visible = true;            
        }
        else if (Session["SessionUserGroup"].ToString() == "1") //REGISTERED USER
        {
            LinkButtonEdit.Visible = false;
            LinkButtonBackToManagement.Visible = false;
        }



        string ProductIDQS = Request.QueryString["ProductID"];
        SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
        
        SqlDataAdapter ProgramFilesPDAdapter = new SqlDataAdapter();
        DataTable ProgramFilesPDTable = new DataTable();

        SqlDataAdapter ProgramFilesReviewAdapter = new SqlDataAdapter();
        DataTable ProgramFilesReviewTable = new DataTable();

        //Populate Product Details Repeater
        ProgramFilesCon.Open();
        SqlCommand PopulatePDRepeater = new SqlCommand("select * from Products p, License l, Category c, OperatingSystem o where p.ProductID='" + ProductIDQS + "' and p.CategoryID=c.CategoryID and p.LicenseID=l.LicenseID and p.OSID=o.OSID", ProgramFilesCon);
        
        ProgramFilesPDAdapter.SelectCommand = PopulatePDRepeater;
        ProgramFilesPDAdapter.Fill(ProgramFilesPDTable);

        //Populate Review Repeater
        SqlCommand PopulateReviewRepeater = new SqlCommand("SELECT * FROM Comments c, Products p, Users u WHERE c.ProductID=p.ProductID AND c.UserID=u.UserID AND c.ProductID='"+ ProductIDQS + "'",ProgramFilesCon);

        ProgramFilesReviewAdapter.SelectCommand = PopulateReviewRepeater;
        ProgramFilesReviewAdapter.Fill(ProgramFilesReviewTable);

        ProgramFilesPDAdapter.Dispose();
        PopulatePDRepeater.Dispose();
        ProgramFilesCon.Close();

        Repeater1.DataSource = ProgramFilesPDTable;
        Repeater1.DataBind();

        RepeaterReview.DataSource = ProgramFilesReviewTable;
        RepeaterReview.DataBind();
    }


    protected void AddtoCartButton_Click(object sender, EventArgs e)
    {
        if (Session["SessionUserName"] != null)
        {
            string ProductIDQS = Request.QueryString["ProductID"].ToString();
            string CartIDQS = Session["SessionCartID"].ToString();
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");

            ProgramFilesCon.Open();

            SqlCommand AddtoCart = new SqlCommand("INSERT INTO CartDetail (CartID, ProductID) values (" + CartIDQS + ", " + ProductIDQS + ")", ProgramFilesCon);
            AddtoCart.ExecuteNonQuery();

            ProgramFilesCon.Close();

            Response.Redirect("ShoppingCart.aspx");
            
        }
        else
        {
            Response.Redirect("Login.aspx?status=NotLoggedIn");
        }
    }

    protected void LinkButtonEdit_Click(object sender, EventArgs e)
    {
        string ProductIDQS = Request.QueryString["ProductID"].ToString();

        Response.Redirect("Edit_Product.aspx?ProductID="+ProductIDQS+"");
    }


    protected void LinkButtonBackToManagement_Click(object sender, EventArgs e)
    {
        Response.Redirect("Product_Management.aspx");
    }

    protected void ButtonPost_Click(object sender, EventArgs e)
    {
        if (Session["SessionUserName"] != null)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
             string ProductIDQS = Request.QueryString["ProductID"].ToString();

            //INSERT NEW REVIEW
            ProgramFilesCon.Open();

            DateTime CurrentTime = DateTime.Now;
            SqlCommand AddReview = new SqlCommand("INSERT INTO Comments (CommentText, DatePosted, Rating, UserID, ProductID) VALUES (@CommentText, @DatePosted, @Rating, @UserID, @ProductID)", ProgramFilesCon);
            AddReview.Parameters.AddWithValue("@CommentText", TextBoxReview.Text);
            AddReview.Parameters.AddWithValue("@DatePosted", CurrentTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            AddReview.Parameters.AddWithValue("@Rating", DropDownListRating.SelectedValue.ToString());
            AddReview.Parameters.AddWithValue("@UserID", Session["SessionUserID"].ToString());
            AddReview.Parameters.AddWithValue("@ProductID", ProductIDQS);         
            AddReview.ExecuteNonQuery();
            

            //RATING TOTAL
            double RatingTotal;
            int UserRated;
            double NewRatingTotal;

            //SUM OF RATING
            SqlCommand SumRating = new SqlCommand("SELECT SUM(Rating) FROM Comments WHERE ProductID = @ProductID", ProgramFilesCon);
            SumRating.Parameters.AddWithValue("@ProductID", ProductIDQS);
            RatingTotal = Convert.ToDouble(SumRating.ExecuteScalar().ToString());

            //COUNT NUMBER OF USER
            SqlCommand CountUser = new SqlCommand("SELECT COUNT(UserID) FROM Comments WHERE ProductID = @ProductID", ProgramFilesCon);
            CountUser.Parameters.AddWithValue("@ProductID", ProductIDQS);
            UserRated = Convert.ToInt32(CountUser.ExecuteScalar().ToString());

            //CALCULATE NEW RATINGTOTAL
            NewRatingTotal = RatingTotal / UserRated;

            //UPDATE RATINGTOTAL
            SqlCommand UpdateRatingTotal = new SqlCommand("UPDATE Products SET RatingTotal = @NewRatingTotal WHERE ProductID = @ProductID", ProgramFilesCon);
            UpdateRatingTotal.Parameters.AddWithValue("@NewRatingTotal", NewRatingTotal);
            UpdateRatingTotal.Parameters.AddWithValue("@ProductID", ProductIDQS);
            UpdateRatingTotal.ExecuteNonQuery();

            Response.Redirect(Request.RawUrl);

            ProgramFilesCon.Close();
        }
        else 
        {
            Response.Redirect("Login.aspx?status=NotLoggedIn");
        }
    }

    //DELETE COMMENT
    protected void DeleteComment_Click(object sender, EventArgs e)
    {       
     
        
    }

    protected void RepeaterReview_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
        ProgramFilesCon.Open();
        
        Label LabelCommentID = e.Item.FindControl("LabelCommentID") as Label;
        string CommentID = LabelCommentID.Text;
        
        SqlCommand DeleteComment = new SqlCommand("DELETE FROM Comments WHERE CommentID = @CommentID",ProgramFilesCon);
        DeleteComment.Parameters.AddWithValue("@CommentID", CommentID);
        DeleteComment.ExecuteNonQuery();
        
        Response.Redirect(Request.RawUrl);
    }
    
}