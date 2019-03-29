using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionUserName"] == null)
        {
            if (!Page.IsPostBack)
            {

                LabelNotification.Visible = false;
                string status = Request.QueryString["status"];
                switch (status)
                {
                    case "newuser":
                        LabelNotification.Visible = true;
                        LabelNotification.Text = "Registration successful! Please log in";
                        break;

                    case "NotLoggedIn":
                        LabelNotification.Visible = true;
                        LabelNotification.Text = "Please log in to access the page";
                        break;
                    case "LogOut":
                        LabelNotification.Visible = true;
                        LabelNotification.Text = "Log Out Successful!";
                        break;
                }


                LabelIncorrect.Text = "";
            }
            else
            {
                LabelIncorrect.Text = "Incorrect Username or Password";
            }
        }
        else
        {
            Response.Redirect("UserArea.aspx");
        }
    }





    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        
        SqlConnection LogConn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
        LogConn.Open();
        SqlCommand CheckUsername = new SqlCommand("SELECT count(*) from Users where Username='"+TextBoxUsername.Text+"'", LogConn);
        int existence = Convert.ToInt32(CheckUsername.ExecuteScalar().ToString());
        LogConn.Close();

        if (existence != 0)
        {
            LogConn.Open();
            SqlCommand VerifyPassword = new SqlCommand("select UserPassword from Users where Username='" + TextBoxUsername.Text + "'", LogConn);
            string PassfromDB = VerifyPassword.ExecuteScalar().ToString();
            LogConn.Close();

            if (PassfromDB == TextBoxPassword.Text)
            {                
                LogConn.Open();
                SqlCommand UpdateLoginCart = new SqlCommand("update Users set ActiveCartID=LastCartID where Username=@Username", LogConn);
                UpdateLoginCart.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                UpdateLoginCart.ExecuteNonQuery();

                SqlCommand FindUserID = new SqlCommand("select UserID from Users where Username=@Username", LogConn);
                FindUserID.Parameters.AddWithValue("@Username", TextBoxUsername.Text);
                string UserID = FindUserID.ExecuteScalar().ToString();

                SqlCommand FindActiveCart = new SqlCommand("select ActiveCartID from Users where UserID='" + UserID + "'",LogConn);
                string ActiveCart = FindActiveCart.ExecuteScalar().ToString();
                

                SqlCommand FindUserGroup = new SqlCommand("select UserGroup from Users where UserID='" + UserID + "'", LogConn);
                string UserGroup = FindUserGroup.ExecuteScalar().ToString();

                LogConn.Close();

                Session["SessionUserName"] = TextBoxUsername.Text;
                Session["SessionUserID"] = UserID;
                Session["SessionCartID"] = ActiveCart;
                Session["SessionUserGroup"] = UserGroup;

                Response.Redirect("Home.aspx");
                
            }            
        }
    
    }
    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}