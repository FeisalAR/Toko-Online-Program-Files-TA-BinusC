using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ButtonProductSearch_Click(object sender, EventArgs e)
    {
        string searchtype = RadioButtonListSearchType.SelectedItem.Text.ToString();
        string searchvalue = TextBoxProductSearch.Text;

        switch (searchtype)
        {
            case ("ProductID"):
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