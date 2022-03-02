using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherForecastingSystem_WebApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            ClearAll();
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=tcp:myweatherdb.database.windows.net,1433;Initial Catalog=POE6211POEDB;Persist Security Info=False;User ID=christokonidaris;Password=Ckon2809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();


            SqlCommand command;
            SqlDataReader dr;
            String sql, Output = "";

            sql = "select * from Forecasts;";

            command = new SqlCommand(sql, cnn);

            dr = command.ExecuteReader();

            while (dr.Read())
            {
                Output = Output + " Forecast ID: " + dr.GetValue(0) + " \n City: " + dr.GetValue(1) + " \n Dates: " + dr.GetValue(2) + " \n Minimum Temp: " + dr.GetValue(3) + "\n Maximum Temp: " + dr.GetValue(4) + " \n Precipitation: " + dr.GetValue(5) + " \n Humidity: " + dr.GetValue(6) + " \n Wind Speed: " + dr.GetValue(7) + " \n ===========================\n ";
            }

            txtDisplay1.Text = Output;

            dr.Close();
            command.Dispose();
            cnn.Close();
        }
        
        public void ClearAll()
        {
            txtDisplay1.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClearAll();
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=tcp:myweatherdb.database.windows.net,1433;Initial Catalog=POE6211POEDB;Persist Security Info=False;User ID=christokonidaris;Password=Ckon2809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();


            SqlCommand command;
            SqlDataReader dr;
            String sql, City, Output = "";

            City = ddlCity.Text;

            sql = "select * from Forecasts where City = '" + City + "';";

            command = new SqlCommand(sql, cnn);

            dr = command.ExecuteReader();

            while (dr.Read())
            {
                Output = Output + " Forecast ID: " + dr.GetValue(0) + " \n City: " + dr.GetValue(1) + " \n Dates: " + dr.GetValue(2) + " \n Minimum Temp: " + dr.GetValue(3) + "\n Maximum Temp: " + dr.GetValue(4) + " \n Precipitation: " + dr.GetValue(5) + " \n Humidity: " + dr.GetValue(6) + " \n Wind Speed: " + dr.GetValue(7) + " \n ===========================\n ";
            }

            txtDisplay2.Text = Output;

            dr.Close();
            command.Dispose();
            cnn.Close();
        }

        protected void btnCitites_Click(object sender, EventArgs e)
        {
            ClearAll();
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=tcp:myweatherdb.database.windows.net,1433;Initial Catalog=POE6211POEDB;Persist Security Info=False;User ID=christokonidaris;Password=Ckon2809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();


            SqlCommand command;
            SqlDataReader dr;
            String sql, City, Output = "";


           City = cblCity.Text;

            sql = "select * from Forecasts where City = '" + City + "';";

            command = new SqlCommand(sql, cnn);

            dr = command.ExecuteReader();

            while (dr.Read())
            {
                Output = Output + " Forecast ID: " +  dr.GetValue(0) + " \n City: " + dr.GetValue(1) + " \n Dates: " + dr.GetValue(2) + " \n Minimum Temp: " + dr.GetValue(3) + "\n Maximum Temp: " + dr.GetValue(4) + " \n Precipitation: " + dr.GetValue(5) + " \n Humidity: " + dr.GetValue(6) + " \n Wind Speed: " + dr.GetValue(7) + " \n ===========================\n ";
            }

            txtDisplay3.Text = Output;

            dr.Close();
            command.Dispose();
            cnn.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("GeneralUserLogin.aspx");
        }
    }
}