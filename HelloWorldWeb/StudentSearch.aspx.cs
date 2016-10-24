using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWeb
{
    public partial class StudentSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearchName.Text.Length > 0)
            {
                string searchText = ConstructSearchText(txtSearchName.Text);
                if(FullSearchResults(searchText) == 0)
                {
                    lblMessage.Text = $"There were no results when searching for '{txtSearchName.Text}'";
                }
                else
                {
                    lblMessage.Text = "You must enter a search value before clicking!";
                }
            }
        }

        private string ConstructSearchText(string s)
        {
            if(!s.StartsWith("%"))
            {
                s = "%" + s;

                if (!s.EndsWith("%"))
                    s = s + "%";
                return s;
            }
            return "No search results available.";
        }

        private int FullSearchResults (string searchText)
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectStudent = "SELECT FirstName, LastName, Email, Phone from Students where (LastName like ? OR FirstName like ?) order by lastname, firstname";

                cmd = new OdbcCommand(sqlSelectStudent, conn);

                cmd.Parameters.Add(new OdbcParameter("FirstName", searchText));
                cmd.Parameters.Add(new OdbcParameter("LastName", searchText));

                conn.Open();

                OdbcDataReader dr = cmd.ExecuteReader();
                rptSearchResults.DataSource = dr;
                rptSearchResults.DataBind();

                return rptSearchResults.Items.Count;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
            return 0;
        }

        protected void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchName.Text.Length > 0)
            {
                string searchText = ConstructSearchText(txtSearchName.Text);
                if (FullSearchResults(searchText) == 0)
                {
                    lblMessage.Text = $"There were no results when searching for '{txtSearchName.Text}'";
                }
                else
                {
                    lblMessage.Text = "You must enter a search value before clicking!";
                }
            }
        }
    }
}