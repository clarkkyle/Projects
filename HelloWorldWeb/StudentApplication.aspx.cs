using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;

namespace HelloWorldWeb
{
    public partial class StudentApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            ddlIntendedMajor.DataSource = Majors.GetMajors();
            ddlIntendedMajor.DataTextField = "MajorName";
            ddlIntendedMajor.DataValueField = "MajorCode";
            ddlIntendedMajor.DataBind();
            }
            catch (Exception ex)
            {
                litMessage.Text = ex.Message;
                litMessage.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                if(ProcessApplication())
                { 
                litMessage.Text = $"<p style='color: red'>Thank you, {txtFirstName.Text} {txtLastName.Text} for applying!</p>";
                litMessage.Visible = true;
                pnlApplication.Visible = false;

                lblFirstName.Text = txtFirstName.Text;
                lblLastName.Text = txtLastName.Text;
                lblEmail.Text = txtEmail.Text;
                lblPhone.Text = txtPhone.Text;
                lblIntendedMajor.Text = ddlIntendedMajor.SelectedValue;
                lblResidentStatus.Text = rbtnlResidentStatus.SelectedItem.Text;
                lblEssay.Text = txtEssay.Text;
                pnlSummary.Visible = true;
                }
            }
            else 
            {
                litMessage.Text = "<p style='color: red'>Unable to process your application. Please see indicated fields below. </p>";
                litMessage.Visible = true;
            }
        }

        private bool ProcessApplication()
        {
            OdbcConnection conn = null;
            OdbcCommand cmd = null;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlInsertApp = @"INSERT INTO OnlineApplications 
                                        (FirstName, LastName, Email, Phone, IntendedMajor, ResidentStatus, Essay) 
                                        VALUES 
                                        (?, ?, ?, ?, ?, ?, ?)";

                cmd = new OdbcCommand(sqlInsertApp, conn);
                cmd.Parameters.Add(new OdbcParameter("FirstName", OdbcType.VarChar, 50) { Value = txtFirstName.Text });
                cmd.Parameters.Add(new OdbcParameter("LastName", OdbcType.VarChar, 50) { Value = txtLastName.Text });
                cmd.Parameters.Add(new OdbcParameter("Email", OdbcType.VarChar, 50) { Value = txtEmail.Text });
                cmd.Parameters.Add(new OdbcParameter("Phone", OdbcType.VarChar, 20) { Value = txtPhone.Text });
                cmd.Parameters.Add(new OdbcParameter("IntendedMajor", OdbcType.VarChar, 10) { Value = ddlIntendedMajor.SelectedValue });
                cmd.Parameters.Add(new OdbcParameter("ResidentStatus", OdbcType.VarChar, 1) { Value = rbtnlResidentStatus.SelectedItem.Value });
                cmd.Parameters.Add(new OdbcParameter("Essay", OdbcType.VarChar) { Value = txtEssay.Text });

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (OdbcException ex)
            {
                litMessage.Text = ex.Message;
                litMessage.Visible = true;
                EventLog.WriteEntry("An error occured:", ex.Message + ex.StackTrace);
                return false;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
            }


        }
    }
}