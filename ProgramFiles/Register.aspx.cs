using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LabelUsername.Text = "";
        }
        else
        {
            LabelUsername.Text = "Username already taken";
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SqlConnection con = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            con.Open();
            SqlCommand FindDuplicate = new SqlCommand("select count(*) from Users where Username='" + TextBoxUser + "'", con);

            int existence = Convert.ToInt32(FindDuplicate.ExecuteScalar().ToString());
            if (existence != 0)
            {
                LabelUsername.Text = "Username already taken";
            }
            else
            {          
                
                //INSERT USER
                SqlCommand RegisterUser = new SqlCommand("INSERT INTO Users (Username, UserPassword, Email, FullName, UserAddress, City, Province, Country, PostalCode, Phone, UserGroup, UserStatus) values (@Username, @UserPassword, @Email, @Fullname, @UserAddress, @City, @Province, @Country, @PostalCode, @Phone, @UserGroup, @UserStatus)", con);
                RegisterUser.Parameters.AddWithValue("@Username", TextBoxUser.Text);
                RegisterUser.Parameters.AddWithValue("@UserPassword", TextBoxPass.Text);
                RegisterUser.Parameters.AddWithValue("@Email", TextBoxEmail.Text);
                RegisterUser.Parameters.AddWithValue("@Fullname", TextBoxName.Text);
                RegisterUser.Parameters.AddWithValue("@UserAddress", TextBoxAddress.Text);
                RegisterUser.Parameters.AddWithValue("@City", TextBoxCity.Text);
                RegisterUser.Parameters.AddWithValue("@Province", TextBoxProvince.Text);
                RegisterUser.Parameters.AddWithValue("@PostalCode", TextBoxPostal.Text);
                RegisterUser.Parameters.AddWithValue("@Country", TextBoxCountry.Text);
                RegisterUser.Parameters.AddWithValue("@Phone", TextBoxPhone.Text);
                RegisterUser.Parameters.AddWithValue("@UserGroup", 1);
                RegisterUser.Parameters.AddWithValue("@UserStatus", 1);

                RegisterUser.ExecuteNonQuery();

                //GENERATE & ASSIGN CART
                SqlCommand GenerateCart = new SqlCommand("EXECUTE AssignCartNew_SP", con);
                GenerateCart.ExecuteNonQuery();               


                Response.Redirect("Login.aspx?status=newuser");
            }

            con.Close();
        }
    }
   
}