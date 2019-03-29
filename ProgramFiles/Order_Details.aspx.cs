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
    public partial class Order_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckUserGroup();

            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
            DataTable ProgramFilesTable = new DataTable();
            ProgramFilesCon.Open();

            string OrderID = Request.QueryString["OrderID"].ToString();
            string CartID = Request.QueryString["CartID"].ToString();

            if (!IsPostBack)
            {
                //Repeater
                SqlCommand PopulateODRepeater = new SqlCommand("select * from Cart c, Orders o, Users u WHERE c.CartID=o.CartID and u.UserID=c.UserID AND o.OrderID='" + OrderID + "'", ProgramFilesCon);
                ProgramFilesAdapter.SelectCommand = PopulateODRepeater;
                ProgramFilesAdapter.Fill(ProgramFilesTable);
                ProgramFilesAdapter.Dispose();
                PopulateODRepeater.Dispose();
                ProgramFilesCon.Close();
                RepeaterOrderDetails.DataSource = ProgramFilesTable;
                RepeaterOrderDetails.DataBind();

                //Listview                
                SqlDataAdapter ProgramFilesAdapter2 = new SqlDataAdapter();
                DataTable ProgramFilesTable2 = new DataTable();

                ProgramFilesCon.Open();

                //ListView DataSource
                SqlCommand PopulateODListView = new SqlCommand("select * from CartDetail cd, Products p where p.ProductID=cd.ProductID and cd.CartID=" + CartID + "", ProgramFilesCon);
                ProgramFilesAdapter2.SelectCommand = PopulateODListView;
                ProgramFilesAdapter2.Fill(ProgramFilesTable2);
                ProgramFilesAdapter2.Dispose();
                PopulateODListView.Dispose();
                ListViewCheckout.DataSource = ProgramFilesTable2;
                ListViewCheckout.DataBind();

                string OrderStatus = ProgramFilesTable.Rows[0]["OrderStatus"].ToString();
                switch (OrderStatus)
                {
                    case "Awaiting Payment":
                        RadioButtonListStatusOption.SelectedIndex = 0;
                        break;
                    case "On Process":
                        RadioButtonListStatusOption.SelectedIndex = 1;
                        break;
                    case "Completed":
                        RadioButtonListStatusOption.SelectedIndex = 2;
                        break;

                }
            }
        }

        protected void RadioButtonListStatusOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");

            string NewOrderStatus = RadioButtonListStatusOption.SelectedItem.Text;
            string OrderID = Request.QueryString["OrderID"].ToString();
            ProgramFilesCon.Open();

            SqlCommand UpdateOrderStatus = new SqlCommand("UPDATE Orders SET OrderStatus='" + NewOrderStatus + "' WHERE OrderID=" + OrderID + "", ProgramFilesCon);
            UpdateOrderStatus.ExecuteNonQuery();


            ProgramFilesCon.Close();
            Response.Redirect(Request.RawUrl);
        }

        public void CheckUserGroup()
        {
            string LoginStatus = string.Format("{0}", Session["SessionUserName"]);
            if (LoginStatus == "") //VISITOR
            {
                Response.Redirect("Login.aspx");

            }
            else if (Session["SessionUserGroup"].ToString() == "0") //ADMIN
            {
                LabelChangeStatus.Visible = true;
                RadioButtonListStatusOption.Visible = true;
            }
            else if (Session["SessionUserGroup"].ToString() == "1") //REGISTERED USER
            {
                LabelChangeStatus.Visible = false;
                RadioButtonListStatusOption.Visible = false;
            }
        }
    }
}