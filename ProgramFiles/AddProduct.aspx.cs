using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionUserGroup"].ToString() != "0")
        {
            Response.Redirect("Home.aspx");
        }

    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
      
            SqlConnection ProgramFilescon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilescon.Open();

            SqlCommand AddNewProduct = new SqlCommand("INSERT INTO Products (ProductName, ProductSize, ProductDescription, ImagePath, CategoryID, OSID, LicenseID) VALUES (@ProductName, @ProductSize, @ProductDescription, @ImagePath, @CategoryID, @OSID, @LicenseID)", ProgramFilescon);
            AddNewProduct.Parameters.AddWithValue("@ProductName", TextBoxName.Text);
            AddNewProduct.Parameters.AddWithValue("@ProductSize", TextBoxSize.Text);
            AddNewProduct.Parameters.AddWithValue("@ProductDescription", TextBoxDescription.Text);
            AddNewProduct.Parameters.AddWithValue("@CategoryID", TextBoxCategoryID.Text);
            AddNewProduct.Parameters.AddWithValue("@OSID", TextBoxOSID.Text);
            AddNewProduct.Parameters.AddWithValue("@LicenseID", TextBoxLicenseID.Text);
            if (TextBoxImagePath.Text == "")
            {
                TextBoxImagePath.Text = "\\no_image.png";
                AddNewProduct.Parameters.AddWithValue("@ImagePath", TextBoxImagePath.Text);
            }
            else
            {
                AddNewProduct.Parameters.AddWithValue("@ImagePath", TextBoxImagePath.Text);
            }
                
            AddNewProduct.ExecuteNonQuery();

            Response.Redirect("Product_Management.aspx?status=addproductsuccess");
            ProgramFilescon.Close();
            }          
       
 }