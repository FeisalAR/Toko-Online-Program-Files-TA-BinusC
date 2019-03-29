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
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //init          
            string s_UserID = Session["SessionUserID"].ToString();
            string s_CartID = Session["SessionCartID"].ToString();

            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            SqlDataAdapter ProgramFilesAdapter = new SqlDataAdapter();
            DataTable ProgramFilesTable = new DataTable();

            ProgramFilesCon.Open();

            //ListView DataSource
            SqlCommand PopulateListView = new SqlCommand("select * from CartDetail cd, Products p where p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
            ProgramFilesAdapter.SelectCommand = PopulateListView;
            ProgramFilesAdapter.Fill(ProgramFilesTable);
            ProgramFilesAdapter.Dispose();
            PopulateListView.Dispose();

            //Count Number of Items
            SqlCommand CountNumberofItems = new SqlCommand("SELECT COUNT(cd.CartID) from Cart c, CartDetail cd, Products p where c.CartID = cd.CartID and p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
            string NumberOfItems = CountNumberofItems.ExecuteScalar().ToString();
            LabelNumberofItems.Text = NumberOfItems;

            //Total Size 
            SqlCommand CountTotalSize = new SqlCommand("select SUM(p.ProductSize) from Cart c, CartDetail cd, Products p where c.CartID = cd.CartID and p.ProductID=cd.ProductID and cd.CartID=" + s_CartID + "", ProgramFilesCon);
            LabelTotalSize.Text = CountTotalSize.ExecuteScalar().ToString();

            //Needed CD Calculations
            double CDNeededRounded = Math.Ceiling((Convert.ToDouble(LabelTotalSize.Text)) / 10);
            LabelCDNeeded.Text = CDNeededRounded.ToString(); 
           
            //CD Price
            double CDPrice = ((Convert.ToDouble(LabelCDNeeded.Text)) * 6000);
            LabelCDPrice.Text = CDPrice.ToString();
            Session["CDPrice"] = LabelCDPrice.Text;

            LabelCDWeight.Text = (Convert.ToDouble(LabelCDNeeded.Text) * 0.125).ToString();
            LabelCDWeightRounded.Text = (Math.Ceiling(Convert.ToDouble(LabelCDWeight.Text))).ToString();
            Session["WeightRounded"] = LabelCDWeightRounded.Text;

            //Burning fee calculation
            double BurnFee = (Convert.ToDouble(LabelCDNeeded.Text)) * 2500;
            LabelBurningFee.Text = BurnFee.ToString();
            Session["BurningFee"] = LabelBurningFee.Text;
            //Update BurningFee
            SqlCommand UpdateBurnFee = new SqlCommand("UPDATE Cart SET BurningFee="+BurnFee+" WHERE CartID="+s_CartID+"", ProgramFilesCon);
            UpdateBurnFee.ExecuteNonQuery();          
            

            ProgramFilesCon.Close();

            ListViewCheckout.DataSource = ProgramFilesTable;
            ListViewCheckout.DataBind();
        }

        protected void RadioButtonListServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string s_CartID = Session["SessionCartID"].ToString();

            //Service Type Session radio
            Session["SelectedServiceType"] = RadioButtonListServiceType.SelectedItem.Text.ToString();

            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            //DeliveryPrice
            double RoundedWeight = (Convert.ToDouble(Session["WeightRounded"].ToString()));
            double BurningFee = Convert.ToDouble(Session["BurningFee"].ToString());
            double CDPrice = Convert.ToDouble(Session["CDPrice"].ToString());

            double SelectedDeliveryService = Convert.ToDouble(RadioButtonListServiceType.SelectedItem.Value);
            double DeliveryPrice = (SelectedDeliveryService) * (RoundedWeight);
            LabelDeliveryFee.Text = DeliveryPrice.ToString();

            //TotalPrice calculation
            double TotalPrice = CDPrice + BurningFee + DeliveryPrice;
            LabelTotalPrice.Text = TotalPrice.ToString();
            Session["TotalPrice"] = LabelTotalPrice.Text;

            //Update CartPrice
            ProgramFilesCon.Open();
            SqlCommand UpdateCartPrice = new SqlCommand("UPDATE Cart SET CartPrice=" + TotalPrice + " WHERE CartID=" + s_CartID + "", ProgramFilesCon);
            UpdateCartPrice.ExecuteNonQuery();
            ProgramFilesCon.Close();
        }

        protected void LinkButtonDPDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
    }
}