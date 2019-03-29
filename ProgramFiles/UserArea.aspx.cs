using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionUserName"] != null)
        {
            if (!IsPostBack)
            {
                LabelUserWelcome.Text = Session["SessionUserName"].ToString();
                LabelCartID.Text = Session["SessionCartID"].ToString();
                LabelUserID.Text = Session["SessionUserID"].ToString();
                SqlConnection UserAreaPFCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                SqlDataAdapter PFAdapter = new SqlDataAdapter();
                DataTable PFTable = new DataTable();

                string UserID = LabelUserID.Text;
                string username = Session["SessionUserName"].ToString();
                UserAreaPFCon.Open();
                SqlCommand LoadUserData = new SqlCommand("select FullName, Email, UserAddress, City, Phone from Users where Username='" + username + "'", UserAreaPFCon);
                PFAdapter.SelectCommand = LoadUserData;
                PFAdapter.Fill(PFTable);
                PFAdapter.Dispose();
                LoadUserData.Dispose();
                UserAreaPFCon.Close();
                Repeater1.DataSource = PFTable;
                Repeater1.DataBind();

                SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
                DataTable ProgramFilesTable = new DataTable();
                ProgramFilesCon.Open();

                SqlCommand PopulateUARepeater = new SqlCommand("select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID and c.UserID=" + UserID + "", ProgramFilesCon);
                ProgramFilesAdapter.SelectCommand = PopulateUARepeater;
                ProgramFilesAdapter.Fill(ProgramFilesTable);
                ProgramFilesAdapter.Dispose();
                PopulateUARepeater.Dispose();
                ProgramFilesCon.Close();
                RepeaterEditOS.DataSource = ProgramFilesTable;
                RepeaterEditOS.DataBind();
            }            
        }
        else
        {
            Response.Redirect("Login.aspx?status=NotLoggedIn");
        }
    }


    protected void ButtonDetails_Click(object sender, EventArgs e)
    {
        Button DetailsButton = (Button)(sender);
        string ButtonOrderIDArg = DetailsButton.CommandArgument;
        //Find the sender button's row
        var CurrentRow = (RepeaterItem)DetailsButton.NamingContainer;
        //Find Label and Textbox, then assign its value to a variable
        string CartIDText = ((Label)CurrentRow.FindControl("LabelCartID")).Text;

        Response.Redirect("Order_Details.aspx?OrderID=" + ButtonOrderIDArg + "&CartID=" + CartIDText + "");
    }


    protected void ButtonLogOut_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Response.Redirect("Login.aspx?status=LogOut");
    }
    
}