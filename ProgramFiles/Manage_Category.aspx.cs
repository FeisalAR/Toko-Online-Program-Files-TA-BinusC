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
    public partial class Manage_Category : System.Web.UI.Page
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


                    SqlCommand PopulateCategoryRepeater = new SqlCommand("select * from Category", ProgramFilesCon);
                    ProgramFilesAdapter.SelectCommand = PopulateCategoryRepeater;
                    ProgramFilesAdapter.Fill(ProgramFilesTable);
                    ProgramFilesAdapter.Dispose();
                    PopulateCategoryRepeater.Dispose();
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

                SqlCommand AddNewCategory = new SqlCommand("INSERT INTO Category (CategoryName) VALUES (@CategoryName)", ProgramFilesCon);
                AddNewCategory.Parameters.AddWithValue("@CategoryName", TextBoxNameAdd.Text);


                AddNewCategory.ExecuteNonQuery();

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
            SqlCommand EditCategory = new SqlCommand();
            EditCategory.Connection = ProgramFilesCon;

            switch (e.CommandName)
            {
                case "ButtonDelete_ClickComm":
                    {
                        string CategoryID = e.CommandArgument.ToString();
                        EditCategory.CommandText = "DELETE FROM Category WHERE CategoryID=" + CategoryID;
                        EditCategory.ExecuteNonQuery();
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
            SqlCommand UpdateCategory = new SqlCommand();
            UpdateCategory.Connection = ProgramFilesCon;

            Button UpdateButton = (Button)sender;
            //Find the sender button's row
            var CurrentRow = (RepeaterItem)UpdateButton.NamingContainer;
            //Find Label and Textbox, then assign its value to a variable
            string OSIDTextBox = ((Label)CurrentRow.FindControl("LabelOSID")).Text;
            String OSNameTextBox = ((TextBox)CurrentRow.FindControl("TextBoxName")).Text;

            if (OSIDTextBox != "")
            {
                UpdateCategory.CommandText = "UPDATE Category SET CategoryName=@CategoryName WHERE CategoryID=@CategoryID";
                UpdateCategory.Parameters.AddWithValue("@CategoryName", OSNameTextBox);
                UpdateCategory.Parameters.AddWithValue("@CategoryID", OSIDTextBox);
                UpdateCategory.ExecuteNonQuery();
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