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
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadioButtonListPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PaymentMethod"] = RadioButtonListPaymentMethod.SelectedItem.Text.ToString();
        }

        protected void LinkButtonPlaceOrder_Click(object sender, EventArgs e)
        {
            SqlConnection ProgramFilesCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ProgramFilesDB;Data Source=ACER-PC\\SQLEXPRESS");
            ProgramFilesCon.Open();

            DateTime CurrentTime = DateTime.Now;

            //Generate new OrderID

            SqlCommand GenerateNewOrder = new SqlCommand("INSERT INTO Orders (OrderDate, OrderStatus, FinalPrice, RecipientName, RecipientAddress, RecipientPostalCode, RecipientPhone, UserID, CartID, DeliveryServiceType, RecipientCity, RecipientProvince, PaymentMethod, CustomerBankAccountNumber, CustomerBankAccountName, CustomerBank) VALUES (@OrderDate, @OrderStatus, @FinalPrice, @RecipientName, @RecipientAddress, @RecipientPostalCode, @RecipientPhone, @UserID, @CartID, @DeliveryServiceType, @RecipientCity, @RecipientProvince, @PaymentMethod, @CustomerBankAccountNumber, @CustomerBankAccountName, @CustomerBank)", ProgramFilesCon);
            GenerateNewOrder.Parameters.AddWithValue("@OrderDate", CurrentTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            GenerateNewOrder.Parameters.AddWithValue("@OrderStatus","Awaiting Payment");
            GenerateNewOrder.Parameters.AddWithValue("@FinalPrice", Session["TotalPrice"].ToString());
            GenerateNewOrder.Parameters.AddWithValue("@RecipientName", TextBoxRName.Text);
            GenerateNewOrder.Parameters.AddWithValue("@RecipientAddress", TextBoxRAddress.Text);
            GenerateNewOrder.Parameters.AddWithValue("@RecipientPostalCode", TextBoxRPostal.Text);
            GenerateNewOrder.Parameters.AddWithValue("@RecipientPhone", TextBoxRPhone.Text);
            GenerateNewOrder.Parameters.AddWithValue("@UserID", Session["SessionUserID"].ToString());
            GenerateNewOrder.Parameters.AddWithValue("@CartID", Session["SessionCartID"].ToString());
            GenerateNewOrder.Parameters.AddWithValue("@DeliveryServiceType", Session["SelectedServiceType"].ToString());
            GenerateNewOrder.Parameters.AddWithValue("@RecipientCity", TextBoxRCity.Text);
            GenerateNewOrder.Parameters.AddWithValue("@RecipientProvince", TextBoxRProvince.Text);
            GenerateNewOrder.Parameters.AddWithValue("@PaymentMethod", RadioButtonListPaymentMethod.SelectedItem.Text.ToString());
            GenerateNewOrder.Parameters.AddWithValue("@CustomerBankAccountNumber", TextBoxBAINumber.Text);
            GenerateNewOrder.Parameters.AddWithValue("@CustomerBankAccountName", TextBoxBAIName.Text);
            GenerateNewOrder.Parameters.AddWithValue("@CustomerBank", TextBoxBAIBank.Text);
            GenerateNewOrder.ExecuteNonQuery();

            string UserID = Session["SessionUserID"].ToString();

            //Assign OrderID
            SqlCommand AssignOrderID = new SqlCommand("select top 1 OrderID from Orders where UserID="+UserID+" order by OrderDate desc", ProgramFilesCon);
            
            Session["OrderID"] = AssignOrderID.ExecuteScalar().ToString();
            string OrderID = Session["OrderID"].ToString();
            //GENERATE & ASSIGN NEW CART
            SqlCommand GenerateCart = new SqlCommand("EXECUTE AssignCartCompletedOrder_SP @UserID="+UserID+"", ProgramFilesCon);
            GenerateCart.ExecuteNonQuery();

            //UPDATE ACTIVE CART DB
            SqlCommand UpdateLoginCart = new SqlCommand("update Users set ActiveCartID=LastCartID where UserID="+UserID+"", ProgramFilesCon);
            UpdateLoginCart.ExecuteNonQuery();

            //UPDATE ACTIVE CART SESSION
            SqlCommand FindActiveCart = new SqlCommand("select ActiveCartID from Users where UserID='" + UserID + "'", ProgramFilesCon);
            string ActiveCart = FindActiveCart.ExecuteScalar().ToString();
    
            Session["SessionCartID"] = ActiveCart;

            ProgramFilesCon.Close();

            Response.Redirect("OrderSubmitted.aspx?OrderID="+OrderID+"");
        
        }
    }
}