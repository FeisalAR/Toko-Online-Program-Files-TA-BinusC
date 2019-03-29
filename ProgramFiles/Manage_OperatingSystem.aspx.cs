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
    public partial class Edit_OperatingSystem : System.Web.UI.Page
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


                    SqlCommand PopulateOSRepeater = new SqlCommand("select * from OperatingSystem", ProgramFilesCon);
                    ProgramFilesAdapter.SelectCommand = PopulateOSRepeater;
                    ProgramFilesAdapter.Fill(ProgramFilesTable);
                    ProgramFilesAdapter.Dispose();
                    PopulateOSRepeater.Dispose();
                    ProgramFilesCon.Close();
                    RepeaterEditOS.DataSource = ProgramFilesTable;
                    RepeaterEditOS.DataBind();
                }
            }
        }



        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (TextBoxNameAdd.Text != "")
            {
                SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
                ProgramFilesCon.Open();

                SqlCommand commInsert = new SqlCommand("INSERT INTO OperatingSystem (OSName) VALUES (@OSName)", ProgramFilesCon);
                commInsert.Parameters.AddWithValue("@OSName", TextBoxNameAdd.Text);


                commInsert.ExecuteNonQuery();

                Response.Redirect(Request.RawUrl);
                ProgramFilesCon.Close();
            }
            else 
            {
                Response.Redirect(Request.RawUrl);
            }

        }



        protected void RepeaterEditOS_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();
            SqlCommand OSEditCommand = new SqlCommand();
            OSEditCommand.Connection = ProgramFilesCon;

            switch (e.CommandName)
            {
                case "ButtonDelete_ClickComm" :
                    {
                        string OSID = e.CommandArgument.ToString();
                        OSEditCommand.CommandText = "DELETE FROM OperatingSystem WHERE OSID=" + OSID;
                        OSEditCommand.ExecuteNonQuery();
                        Response.Redirect(Request.RawUrl);
                        break;                    
                    }
                
            }
            ProgramFilesCon.Close();
        }


        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();
            SqlCommand OSEditCommand = new SqlCommand();
            OSEditCommand.Connection = ProgramFilesCon;

            Button UpdateButton = (Button)sender;
            //Find the sender button's row
            var CurrentRow = (RepeaterItem)UpdateButton.NamingContainer;
            //Find Label and Textbox, then assign its value to a variable
            string OSIDTextBox = ((Label)CurrentRow.FindControl("LabelOSID")).Text;
            String OSNameTextBox = ((TextBox)CurrentRow.FindControl("TextBoxName")).Text;

            if (OSIDTextBox != "")
            {
                OSEditCommand.CommandText = "UPDATE OperatingSystem SET OSName=@OSName WHERE OSID=@OSID";
                OSEditCommand.Parameters.AddWithValue("@OSName", OSNameTextBox);
                OSEditCommand.Parameters.AddWithValue("@OSID", OSIDTextBox);
                OSEditCommand.ExecuteNonQuery();
                ProgramFilesCon.Close();
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ProgramFilesCon.Close();
                Response.Redirect(Request.RawUrl);
            }

        }

    }
}