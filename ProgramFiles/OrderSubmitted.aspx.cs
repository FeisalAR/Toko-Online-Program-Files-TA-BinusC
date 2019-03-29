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
    public partial class ConfirmPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelOrderID.Text = Session["OrderID"].ToString();
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
            DataTable ProgramFilesTable = new DataTable();
            ProgramFilesCon.Open();

            string OrderID = Session["OrderID"].ToString();
            string CartID = Session["SessionCartID"].ToString();

            if (!IsPostBack)
            {
                //Repeater
                SqlCommand PopulateOSubRepeater = new SqlCommand("select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID AND o.OrderID='" + OrderID + "'", ProgramFilesCon);
                ProgramFilesAdapter.SelectCommand = PopulateOSubRepeater;
                ProgramFilesAdapter.Fill(ProgramFilesTable);
                ProgramFilesAdapter.Dispose();
                PopulateOSubRepeater.Dispose();
                ProgramFilesCon.Close();
                RepeaterOrderDetails.DataSource = ProgramFilesTable;
                RepeaterOrderDetails.DataBind();
            }

        }
    }
}