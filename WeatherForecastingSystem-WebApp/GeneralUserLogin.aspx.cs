using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeatherForecastingSystem_WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = "Server=tcp:myweatherdb.database.windows.net,1433;Initial Catalog=POE6211POEDB;Persist Security Info=False;User ID=christokonidaris;Password=Ckon2809;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();


            SqlCommand cmd; 
            SqlDataReader dr;
            String sql, UserName = "", Password = "", Output = "";
            

            UserName = txtUserName.Text;
            Password = txtPassword.Text;

            sql = "select * from GeneralUserLogin;";

            cmd = new SqlCommand(sql, cnn);
            
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Output = Output + dr.GetValue(0) + " \t " + dr.GetValue(1) + " \n ";
                if (UserName == (string)dr.GetValue(0) && (Password == (string)dr.GetValue(1)))
                {
                    Response.Redirect("View.aspx");
                }
                else
                {
                    lblmessage.Visible = true;
                }
            }
            dr.Close();
            cmd.Dispose();
            cnn.Close();
        }
    }
}