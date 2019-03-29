using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Search_Result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string searchtype = Request.QueryString["type"];
        string searchvalue = Request.QueryString["value"];
        LabelSearchValue.Text = searchvalue;
        SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
        SqlDataAdapter PFAdapter = new SqlDataAdapter();
        DataTable PFTable = new DataTable();
        ProgramFilesCon.Open();


        string query = "";

        switch (searchtype)
        {
            case "ProductID":
                query = "select * from Products  p, License l, Category c, OperatingSystem o WHERE p.LicenseID=l.LicenseID AND p.OSID=o.OSID AND p.CategoryID=c.CategoryID AND p.ProductID='" + searchvalue + "'";
                break;
            case "Name":
                query = "select * from Products  p, License l, Category c, OperatingSystem o WHERE p.LicenseID=l.LicenseID AND p.OSID=o.OSID AND p.CategoryID=c.CategoryID AND p.ProductName LIKE '%" + searchvalue + "%'";
                break;
            case "CategoryID":
                query = "select * from Products  p, License l, Category c, OperatingSystem o WHERE p.LicenseID=l.LicenseID AND p.OSID=o.OSID AND p.CategoryID=c.CategoryID AND p.CategoryID='" + searchvalue + "'";
                break;
            case "OSID":
                query = "select * from Products  p, License l, Category c, OperatingSystem o WHERE p.LicenseID=l.LicenseID AND p.OSID=o.OSID AND p.CategoryID=c.CategoryID AND p.OSID='" + searchvalue + "'";
                break;
            case "LicenseID":
                query = "select * from Products  p, License l, Category c, OperatingSystem o WHERE p.LicenseID=l.LicenseID AND p.OSID=o.OSID AND p.CategoryID=c.CategoryID AND p.LicenseID='" + searchvalue + "'";
                break;
        }

        SqlCommand SearchProduct = new SqlCommand(query, ProgramFilesCon);
        PFAdapter.SelectCommand = SearchProduct;
        PFAdapter.Fill(PFTable);
        PFAdapter.Dispose();
        SearchProduct.Dispose();
        ProgramFilesCon.Close();
        Repeater1.DataSource = PFTable;
        Repeater1.DataBind();

    }
}