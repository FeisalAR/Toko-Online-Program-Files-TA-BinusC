using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckUserGroup();
    }

    public void CheckUserGroup()
    {
        string LoginStatus = string.Format("{0}", Session["SessionUserName"]);
        if (LoginStatus == "") //VISITOR
        {
            MenuAdmin.Visible = false;
            MenuRegistered.Visible = false;

        }
        else if (Session["SessionUserGroup"].ToString() == "0") //ADMIN
        {
            MenuAdmin.Visible = true;
            MenuVisitor.Visible = false;
            MenuRegistered.Visible = true;
        }
        else if (Session["SessionUserGroup"].ToString() == "1") //REGISTERED USER
        {
            MenuAdmin.Visible = false;
            MenuRegistered.Visible = true;
            MenuVisitor.Visible = false;
        }
    }
}

