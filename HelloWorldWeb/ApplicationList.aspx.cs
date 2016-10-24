using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Configuration;
using System.Data;

namespace HelloWorldWeb
{
    public partial class ApplicationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateGridWithApps();

                try
                {
                    ddlIntendedMajor.DataSource = Majors.GetMajors();
                    ddlIntendedMajor.DataTextField = "MajorName";
                    ddlIntendedMajor.DataValueField = "MajorCode";
                    ddlIntendedMajor.DataBind();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }

        private void PopulateGridWithApps()
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectApps = @"SELECT ApplicationID, FirstName, LastName FROM OnlineApplications ORDER BY LastName, FirstName";

                cmd = new OdbcCommand(sqlSelectApps, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();
                gvApplicationList.DataSource = dr;
                gvApplicationList.DataBind();
                dr.Close();
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

        }

        protected void gvApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int cmdArg = Convert.ToInt32(e.CommandArgument);
            if (gvApplicationList.DataKeys[cmdArg] == null)
                return;
            int appID = Convert.ToInt32(gvApplicationList.DataKeys[cmdArg].Value);

            switch(e.CommandName)
            {
                case "EditApp":
                    EditApplication(appID);
                    break;
                case "DeleteApp":
                    if(DeleteApplication(appID))
                    {
                        PopulateGridWithApps();
                        lblMessage.Text = "Application deleted successfully";
                        lblMessage.Visible = true;
                    }
                    break;
            }
        }

        private void EditApplication(int appID)
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            OdbcDataAdapter dataAdapter = null;
            pnlApplication.Visible = true;

            try
            {

                string sqlSelectApp = @"SELECT * from OnlineApplications where ApplicationID = ?";
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                cmd = new OdbcCommand(sqlSelectApp, conn);
                cmd.Parameters.Add(new OdbcParameter("appID", OdbcType.Int) { Value = appID });

                conn.Open();

                dataAdapter = new OdbcDataAdapter(cmd);

                DataSet dataSet = new DataSet();

                dataAdapter.Fill(dataSet);

                if (dataSet.Tables.Count == 0)
                    return;

                DataTable dt = dataSet.Tables[0];

                if (dt.Rows.Count == 0)
                    return;

                txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                ddlIntendedMajor.SelectedValue = dt.Rows[0]["IntendedMajor"].ToString();
                rbtnlResidentStatus.SelectedValue = dt.Rows[0]["ResidentStatus"].ToString();
                txtEssay.Text = dt.Rows[0]["Essay"].ToString();

                Session["ApplicationListEditAppID"] = appID;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.Visible = true;
            }
            finally
            {
                dataAdapter.Dispose();
                conn.Close();
            }

        }

        private bool DeleteApplication(int appID)
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string sqlDeleteApps = "DELETE from OnlineApplications where ApplicationID = ?";
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                cmd = new OdbcCommand(sqlDeleteApps, conn);
                cmd.Parameters.Add(new OdbcParameter("appID", OdbcType.Int) { Value = appID });

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
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
            return false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(IsValid && Session["ApplicationListEditAppID"] != null)
            {
                int appID = (int)Session["ApplicationListEditAppID"];
                if(UpdateApplication(appID))
                {
                    Session.Remove("ApplicationListEditAppID");
                    pnlApplication.Visible = false;
                    PopulateGridWithApps();
                }
            }
        }

        private bool UpdateApplication(int appID)
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlUpdateApp = "UPDATE OnlineApplications SET FirstName = ?, LastName = ?, Email = ?, Phone = ?, IntendedMajor = ?, ResidentStatus = ?, Essay = ? where ApplicationID = ?";
             

                cmd = new OdbcCommand(sqlUpdateApp, conn);
                cmd.Parameters.AddRange(new List<OdbcParameter>
                {
                    new OdbcParameter("FirstName", OdbcType.VarChar, 50) { Value = txtFirstName.Text },
                    new OdbcParameter("LastName", OdbcType.VarChar, 50) { Value = txtLastName.Text },
                    new OdbcParameter("Email", OdbcType.VarChar, 50) { Value = txtEmail.Text },
                    new OdbcParameter("Phone", OdbcType.VarChar, 20) { Value = txtPhone.Text },
                    new OdbcParameter("IntendedMajor", OdbcType.VarChar, 10) { Value = ddlIntendedMajor.SelectedValue },
                    new OdbcParameter("ResidentStatus", OdbcType.VarChar, 1) { Value = rbtnlResidentStatus.SelectedItem.Value },
                    new OdbcParameter("Essay", OdbcType.VarChar) { Value = txtEssay.Text },
                    new OdbcParameter("AppID", OdbcType.Int) {Value= appID }
                }.ToArray());

                conn.Open();

                cmd.ExecuteNonQuery();

                return true;
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
            return false;
        }
    }
}