using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Text;

namespace WebApplication_Datasheets
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(mainconn);

            string Query = "select * from college.student;";
            MySqlCommand sqlcomm = new MySqlCommand(Query, con);
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=1>");
            sb.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToString());
                sb.Append("</th>");
            }

            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            Panel1.Controls.Add(new Label { Text = sb.ToString() });
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(mainconn);

            string Query = "SELECT Student.Student_FName, ROUND((Student.Alegbra + Student.Calculus + Student.Programming + Student.S_Databases) / 4, 1) AS Average FROM Student;";
            MySqlCommand sqlcomm = new MySqlCommand(Query, con);
            con.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=1>");
            sb.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToString());
                sb.Append("</th>");
            }

            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<th>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</th>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            Panel1.Controls.Add(new Label { Text = sb.ToString() });
            con.Close();
        }
    }
}