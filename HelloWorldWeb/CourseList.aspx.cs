using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CUS.OdbcConnectionClass3;
using System.Data;

namespace HelloWorldWeb
{
    public partial class CourseList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetCourseList2();
            }
        }

        private void GetCourseList()
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectCourse = @"SELECT CourseCode, CourseName, CourseDescription from Courses ORDER BY CourseCode";

                cmd = new OdbcCommand(sqlSelectCourse, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                if(dr.HasRows)
                {
                    //rptCourseList.DataSource = dr;
                    //rptCourseList.DataBind();

                    //rptCourseList2.DataSource = dr;
                    //rptCourseList2.DataBind();

                    dlCourses.DataSource = dr;
                    dlCourses.DataBind();
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

        private void GetCourseList2()
        {
            string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
            OdbcConnectionClass3 odbcConn = new OdbcConnectionClass3(connString);
            string sqlSelectCourse = @"SELECT CourseCode, CourseName, CourseDescription from Courses ORDER BY CourseCode";

            Exception ex = null;

            DataTable dt = odbcConn.ConnectToERP(sqlSelectCourse, ref ex);

            if(ex != null)
            {
                lblMessage.Text = ex.Message;
            }
            else if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No data to display";
            }
            else
            {
                rptCourseList.DataSource = dt;
                rptCourseList.DataBind();
            }
        }
    }
}