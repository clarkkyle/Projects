using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Odbc;

namespace HelloWorldWeb
{
    public partial class DBTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;

            //Database Connection
            var conn = new OdbcConnection();
            conn.ConnectionString = connStr;

            //SQL Statement
            string sql = "select count(*) from Students";

            //Command
            var command = new OdbcCommand();
            command.CommandText = sql;
            command.Connection = conn;

            //var command1 = new odbcCommand(sql, conn); -- Another way to perform the command above.

            // Open Connection to DB
            conn.Open();

            //Execute the command
            lblDisplayData.Text = command.ExecuteScalar().ToString();

            //Cleanup
            command.Dispose();
            conn.Close();
        }

        protected void btnLookup_Click(object sender, EventArgs e)
        {
            string sql = "select firstname, lastname from Students where studentid = ?";

            string connStr = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;

            var conn = new OdbcConnection();
            conn.ConnectionString = connStr;

            var command = new OdbcCommand(sql, conn);

            try
            {

                conn.Open();

                command.Parameters.Add(new OdbcParameter("ID_NUM", OdbcType.Int) { Value = txtIDLookup.Text });

                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    lblDisplayData.Text = dr["firstname"].ToString() + "" + dr["lastname"].ToString();
                }
            }
            catch (OdbcException ex)
            {
                lblDisplayData.Text = "A database error has occured. " + ex.Message;
            }
            catch (Exception ex)
            {
                lblDisplayData.Text = "General Error: " + ex.Message;
            }
            finally
            {
                command.Dispose();
                conn.Close();
            }

        }
    }
}