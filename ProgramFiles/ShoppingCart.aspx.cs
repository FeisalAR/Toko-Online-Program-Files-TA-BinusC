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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelEmptyCart.Visible = true;
            //Check if User has logged in
            if (Session["SessionUserID"] != null)
            {
                string s_UserID = Session["SessionUserID"].ToString();
                string s_CartID = Session["SessionCartID"].ToString();

                SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
                DataTable ProgramFilesTable = new DataTable();

                ProgramFilesCon.Open();

                //Count Number of Items
                SqlCommand CountNumberofItems = new SqlCommand("SELECT COUNT(cd.CartID) from Cart c, CartDetail cd, Products p where c.CartID = cd.CartID and p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
                string NumberOfItems = CountNumberofItems.ExecuteScalar().ToString();

                //Check if cart is not empty
                if ((NumberOfItems != "") || (NumberOfItems != "0"))
                {                   

                    //Repeater DataSource
                    SqlCommand PopulateSCRepeater = new SqlCommand("select * from CartDetail cd, Products p where p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
                    ProgramFilesAdapter.SelectCommand = PopulateSCRepeater;
                    ProgramFilesAdapter.Fill(ProgramFilesTable);
                    ProgramFilesAdapter.Dispose();
                    PopulateSCRepeater.Dispose();

                    LabelNumberofItems.Text = NumberOfItems;


                    //Update NumberOfItems in dbo.Cart
                    SqlCommand UpdateNumberOfItems = new SqlCommand("UPDATE Cart SET NumberOfItems=" + NumberOfItems + " WHERE CartID=" + s_CartID + "", ProgramFilesCon);
                    UpdateNumberOfItems.ExecuteNonQuery();

                    //Sum Total Size
                    SqlCommand CountTotalSize = new SqlCommand("SELECT SUM(p.ProductSize) from Cart c, CartDetail cd, Products p where c.CartID = cd.CartID and p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
                    string TotalSize = CountTotalSize.ExecuteScalar().ToString();

                    //Check if not null or 0 and set label & button visibility
                    if ((TotalSize != "") || (TotalSize == "0"))
                    {
                        LabelTotalSize.Text = TotalSize;
                        LabelEmptyCart.Visible = false;                        
                    }
                    else
                    {
                        LabelTotalSize.Text = "0";
                        LabelEmptyCart.Visible = true;
                        LinkButtonCheckout.Visible = false;
                    }


                    //Needed CD Calculations
                    double CDNeededRounded = Math.Ceiling((Convert.ToDouble(LabelTotalSize.Text)) / 10);
                    LabelCDNeeded.Text = CDNeededRounded.ToString();

                    //Update CDNeeded in dbo.Cart
                    SqlCommand UpdateCDNeeded = new SqlCommand("UPDATE Cart SET CDNeeded=" + LabelCDNeeded.Text + " WHERE CartID=" + s_CartID + "", ProgramFilesCon);
                    UpdateCDNeeded.ExecuteNonQuery();


                    ProgramFilesCon.Close();

                    //Repeater Data Binding
                    RepeaterShoppingCart.DataSource = ProgramFilesTable;
                    RepeaterShoppingCart.DataBind();
                }
            }
            else
            {
                Response.Redirect("Login.aspx?status=NotLoggedIn");
            }

        }

        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            //Retrieve Button's Command Argument
            LinkButton RemoveButton = (LinkButton)(sender);
            string ButtonProductID = RemoveButton.CommandArgument;
            string s_CartID = Session["SessionCartID"].ToString();

            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();          

            //Remove Selected Item
            SqlCommand RemoveCartItem = new SqlCommand("DELETE FROM CartDetail WHERE CartID=" + s_CartID + " AND ProductID=" + ButtonProductID + "", ProgramFilesCon);
            RemoveCartItem.ExecuteNonQuery();

            //Update TotalItemSize in dbo.Cart
            SqlCommand UpdateTotalItemSize = new SqlCommand("UPDATE Cart SET TotalItemSize=" + LabelTotalSize.Text + " WHERE CartID=" + s_CartID + "", ProgramFilesCon);
            UpdateTotalItemSize.ExecuteNonQuery();

            ProgramFilesCon.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void LinkButtonCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}