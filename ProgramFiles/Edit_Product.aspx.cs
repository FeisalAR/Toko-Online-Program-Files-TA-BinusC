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
    public partial class Edit_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionUserGroup"].ToString() != "0")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string ProductID = Request.QueryString["ProductID"];
                    SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");

                    SqlCommand queryName = new SqlCommand("SELECT ProductName from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand querySize = new SqlCommand("SELECT ProductSize from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand queryDescription = new SqlCommand("SELECT ProductDescription from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand queryCategory = new SqlCommand("SELECT CategoryID from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand queryOS = new SqlCommand("SELECT OSID from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand queryLicense = new SqlCommand("SELECT LicenseID from Products where ProductID=" + ProductID + "", ProgramFilesCon);
                    SqlCommand queryImage = new SqlCommand("SELECT ImagePath from Products where ProductID=" + ProductID + "", ProgramFilesCon);

                    ProgramFilesCon.Open();

                    TextBoxName.Text = queryName.ExecuteScalar().ToString();
                    TextBoxSize.Text = querySize.ExecuteScalar().ToString();
                    TextBoxDescription.Text = queryDescription.ExecuteScalar().ToString();
                    TextBoxCategoryID.Text = queryCategory.ExecuteScalar().ToString();
                    TextBoxImagePath.Text = queryImage.ExecuteScalar().ToString();
                    TextBoxLicenseID.Text = queryLicense.ExecuteScalar().ToString();
                    TextBoxOSID.Text = queryOS.ExecuteScalar().ToString();


                    ProgramFilesCon.Close();
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            string ProductID = Request.QueryString["ProductID"];
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();

            SqlCommand UpdateProduct = new SqlCommand("UPDATE Products SET ProductName=@ProductName, ProductSize=@ProductSize, ProductDescription=@ProductDescription, ImagePath=@ImagePath, CategoryID=@CategoryID, OSID=@OSID, LicenseID=@LicenseID WHERE ProductID=@ProductID", ProgramFilesCon);
            UpdateProduct.Parameters.AddWithValue("@ProductName", TextBoxName.Text);
            UpdateProduct.Parameters.AddWithValue("@ProductSize", TextBoxSize.Text);
            UpdateProduct.Parameters.AddWithValue("@ProductDescription", TextBoxDescription.Text);
            UpdateProduct.Parameters.AddWithValue("@CategoryID", TextBoxCategoryID.Text);
            UpdateProduct.Parameters.AddWithValue("@OSID", TextBoxOSID.Text);
            UpdateProduct.Parameters.AddWithValue("@LicenseID", TextBoxLicenseID.Text);
            UpdateProduct.Parameters.AddWithValue("@ProductID", ProductID);
            if (TextBoxImagePath.Text == "")
            {
                TextBoxImagePath.Text = "\\no_image.png";
                UpdateProduct.Parameters.AddWithValue("@ImagePath", TextBoxImagePath.Text);
            }
            else
            {
                UpdateProduct.Parameters.AddWithValue("@ImagePath", TextBoxImagePath.Text);
            }

            UpdateProduct.ExecuteNonQuery();

            Response.Redirect("Product_Management.aspx?status=addproductsuccess");
            ProgramFilesCon.Close();
        }

        protected void LinkButtonResetEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }       
    }
}