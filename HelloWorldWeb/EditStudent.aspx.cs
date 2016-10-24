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
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetStudent();
            }
        }

        private void GetStudent()
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectStudent = "SELECT * from Students ORDER BY LastName, FirstName";

                conn.Open();

                cmd = new OdbcCommand(sqlSelectStudent, conn);

                gvStudents.DataSource = cmd.ExecuteReader();
                gvStudents.DataBind();

               


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

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int cmdArg = Convert.ToInt32(e.CommandArgument);

            int studentID = Convert.ToInt32(gvStudents.DataKeys[cmdArg].Value);

            LoadStudentData(studentID);

            Session["SelectedStudentID"] = studentID;

        }

        private void LoadStudentData(int studentID)
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectStudent = @"SELECT * from Students WHERE StudentID = ?";

                conn.Open();

                cmd = new OdbcCommand(sqlSelectStudent, conn);

                cmd.Parameters.Add(new OdbcParameter("StudentID", OdbcType.Int) { Value = studentID });

                var dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtFirstName.Text = dr["FirstName"].ToString();
                        txtLastName.Text = dr["LastName"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        txtPhone.Text = dr["Phone"].ToString();
                    }
                    pnlEditForm.Visible = true;
                }
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

        private bool UpdateStudentInfo()
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlUpdateStudent = @"UPDATE Students Set Firstname = ?, LastName = ?, Email = ?, Phone = ? where StudentID = ? ";

                conn.Open();

                cmd = new OdbcCommand(sqlUpdateStudent, conn);

                cmd.Parameters.AddRange(new List<OdbcParameter>
                {
                    new OdbcParameter("FirstName", OdbcType.VarChar, 50) {Value = txtFirstName.Text },
                    new OdbcParameter("LastName", OdbcType.VarChar, 50) {Value = txtLastName.Text },
                    new OdbcParameter("Email", OdbcType.VarChar, 50) {Value = txtEmail.Text },
                    new OdbcParameter("Phone", OdbcType.VarChar, 20) {Value = txtPhone.Text },
                    new OdbcParameter("StudentID", OdbcType.Int) {Value = Convert.ToInt32(Session["SelectedStudentID"]) }
                }.ToArray());

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
            if(UpdateStudentInfo())
            {
                lblMessage.Text = "Update successful";
                GetStudent();
                Session.Remove("SelectedStudentID");
                pnlEditForm.Visible = false;
            }
        }
    }
}