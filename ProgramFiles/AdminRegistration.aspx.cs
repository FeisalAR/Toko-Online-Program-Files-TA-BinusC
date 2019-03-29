using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProgramFiles
{
    public partial class AdminRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                con.Open();
                SqlCommand comm = new SqlCommand("select count(*) from Users where Username='" + TextBoxUser + "'", con);

                int existence = Convert.ToInt32(comm.ExecuteScalar().ToString());
                if (existence != 0)
                {
                    LabelUsername.Text = "Username already taken";
                }
                else
                {

                    //INSERT USER
                    SqlCommand commInsert = new SqlCommand("INSERT INTO Users (Username, UserPassword, UserGroup, UserStatus) values (@Username, @UserPassword, @UserGroup, @UserStatus)", con);
                    commInsert.Parameters.AddWithValue("@Username", TextBoxUser.Text);
                    commInsert.Parameters.AddWithValue("@UserPassword", TextBoxPass.Text);
                    commInsert.Parameters.AddWithValue("@UserGroup", 0);
                    commInsert.Parameters.AddWithValue("@UserStatus", 1);

                    commInsert.ExecuteNonQuery();

                    //GENERATE & ASSIGN CART
                    SqlCommand GenerateCart = new SqlCommand("EXECUTE AssignCartNew_SP", con);
                    GenerateCart.ExecuteNonQuery();


                    Response.Redirect("Login.aspx?status=newuser");
                }

                con.Close();
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}