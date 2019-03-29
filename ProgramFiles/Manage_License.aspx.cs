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
    public partial class Manage_License : System.Web.UI.Page
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


                    SqlCommand PopulateLicenseRepeater = new SqlCommand("select * from License", ProgramFilesCon);
                    ProgramFilesAdapter.SelectCommand = PopulateLicenseRepeater;
                    ProgramFilesAdapter.Fill(ProgramFilesTable);
                    ProgramFilesAdapter.Dispose();
                    PopulateLicenseRepeater.Dispose();
                    ProgramFilesCon.Close();
                    RepeaterEditOS.DataSource = ProgramFilesTable;
                    RepeaterEditOS.DataBind();
                }
            }
        }



        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();

            if (TextBoxNameAdd.Text != "")
            {
                SqlCommand AddNewLicense = new SqlCommand("INSERT INTO License (LicenseName) VALUES (@LicenseName)", ProgramFilesCon);
                AddNewLicense.Parameters.AddWithValue("@LicenseName", TextBoxNameAdd.Text);


                AddNewLicense.ExecuteNonQuery();

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
            SqlCommand EditLicense = new SqlCommand();
            EditLicense.Connection = ProgramFilesCon;

            switch (e.CommandName)
            {
                case "ButtonDelete_ClickComm":
                    {
                        string LicenseID = e.CommandArgument.ToString();
                        EditLicense.CommandText = "DELETE FROM License WHERE LicenseID=" + LicenseID;
                        EditLicense.ExecuteNonQuery();
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
            SqlCommand UpdateLicense = new SqlCommand();
            UpdateLicense.Connection = ProgramFilesCon;

            Button UpdateButton = (Button)sender;
            //Find the sender button's row
            var CurrentRow = (RepeaterItem)UpdateButton.NamingContainer;
            //Find Label and Textbox with specified ID, then assign its value to a string variable
            string OSIDTextBox = ((Label)CurrentRow.FindControl("LabelOSID")).Text;
            String OSNameTextBox = ((TextBox)CurrentRow.FindControl("TextBoxName")).Text;

            if (OSIDTextBox != "")
            {
                UpdateLicense.CommandText = "UPDATE License SET LicenseName=@OSName WHERE LicenseID=@OSID";
                UpdateLicense.Parameters.AddWithValue("@OSName", OSNameTextBox);
                UpdateLicense.Parameters.AddWithValue("@OSID", OSIDTextBox);
                UpdateLicense.ExecuteNonQuery();
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