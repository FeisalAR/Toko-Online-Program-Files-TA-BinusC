using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product_Management : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["SessionUserGroup"].ToString() != "0")
        {
            Response.Redirect("Home.aspx");
        }
    }
    protected void ButtonAddProuct_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddProduct.aspx");
    }


    protected void ButtonCategory_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_Category.aspx");
    }



    protected void ButtonOS_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_OperatingSystem.aspx");
    }



    protected void ButtonLicenseAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("Manage_License.aspx");
    }



    protected void ButtonProductSearch_Click(object sender, EventArgs e)
    {
        string searchtype = RadioButtonListSearchType.SelectedItem.Text.ToString();
        string searchvalue = TextBoxProductSearch.Text;

        switch (searchtype)
        {
            case("ProductID"):
                Response.Redirect("Search_Result.aspx?type=ProductID&value=" + searchvalue);
            break;
            case ("Name"):
                Response.Redirect("Search_Result.aspx?type=Name&value=" + searchvalue);
            break;
            case ("CategoryID"):
                Response.Redirect("Search_Result.aspx?type=CategoryID&value=" + searchvalue);
            break;
            case ("OSID"):
                Response.Redirect("Search_Result.aspx?type=OSID&value=" + searchvalue);
            break;
            case ("LicenseID"):
                Response.Redirect("Search_Result.aspx?type=LicenseID&value=" + searchvalue);
            break;
        }
    }

    
   
}