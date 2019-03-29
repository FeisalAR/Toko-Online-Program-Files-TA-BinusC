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
    public partial class Order_Management : System.Web.UI.Page
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
                    SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                    SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
                    DataTable ProgramFilesTable = new DataTable();
                    ProgramFilesCon.Open();

                    SqlCommand PopulateOMRepeater = new SqlCommand("select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID", ProgramFilesCon);
                    ProgramFilesAdapter.SelectCommand = PopulateOMRepeater;
                    ProgramFilesAdapter.Fill(ProgramFilesTable);
                    ProgramFilesAdapter.Dispose();
                    PopulateOMRepeater.Dispose();
                    ProgramFilesCon.Close();
                    RepeaterEditOS.DataSource = ProgramFilesTable;
                    RepeaterEditOS.DataBind();
                }
            }
        }


        protected void ButtonDetails_Click(object sender, EventArgs e)
        {
            Button DetailsButton = (Button)(sender);
            string ButtonOrderIDArg = DetailsButton.CommandArgument;
            //Find the sender button's row
            var CurrentRow = (RepeaterItem)DetailsButton.NamingContainer;
            //Find Label and Textbox, then assign its value to a variable
            string CartIDText = ((Label)CurrentRow.FindControl("LabelCartID")).Text;

            Response.Redirect("Order_Details.aspx?OrderID="+ButtonOrderIDArg+"&CartID="+CartIDText+"");
        }


        protected void RadioButtonListStatusOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
            DataTable ProgramFilesTable = new DataTable();
            ProgramFilesCon.Open();

            string SelectedRBL = RadioButtonListStatusOption.SelectedItem.Text;
            string query = "";

            switch (SelectedRBL)
            {
                case "All":
                    query = "select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID";
                    break;
                case "Awaiting Payment":
                    query = "select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID AND OrderStatus='Awaiting Payment'";
                    break;
                case "On Process":
                    query = "select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID AND OrderStatus='On Process'";
                    break;
                case "Completed":
                    query = "select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID AND OrderStatus='Completed'";
                    break;
            }


            SqlCommand UpdateOrdersList = new SqlCommand(query, ProgramFilesCon);
            ProgramFilesAdapter.SelectCommand = UpdateOrdersList;
            ProgramFilesAdapter.Fill(ProgramFilesTable);
            ProgramFilesAdapter.Dispose();
            UpdateOrdersList.Dispose();
            ProgramFilesCon.Close();
            RepeaterEditOS.DataSource = ProgramFilesTable;
            RepeaterEditOS.DataBind();


            ProgramFilesCon.Close();
        }        
    }
}