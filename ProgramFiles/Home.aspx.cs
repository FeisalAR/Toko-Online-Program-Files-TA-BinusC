using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
        SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
        DataTable ProgramFilesTable = new DataTable();

        ProgramFilesCon.Open();
        SqlCommand LoadHomePage = new SqlCommand("select * from Products p, OperatingSystem o, Category c where p.CategoryID=c.CategoryID and p.OSID=o.OSID;", ProgramFilesCon);
        ProgramFilesAdapter.SelectCommand = LoadHomePage;
        ProgramFilesAdapter.Fill(ProgramFilesTable);
        ProgramFilesAdapter.Dispose();
        LoadHomePage.Dispose();
        ProgramFilesCon.Close();
        Repeater1.DataSource = ProgramFilesTable;
        Repeater1.DataBind();
    }
   
}
