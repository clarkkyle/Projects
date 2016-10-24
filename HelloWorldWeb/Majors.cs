using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace HelloWorldWeb
{
    public class Majors
    {
        public static OdbcDataReader GetMajors()
        {
            OdbcCommand cmd = null;
            OdbcConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["HelloWorldConnect"].ConnectionString;
                conn = new OdbcConnection(connString);

                string sqlSelectMajors = "SELECT MajorCode, MajorName from Majors order by MajorName";


                cmd = new OdbcCommand(sqlSelectMajors, conn);

                conn.Open();

                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }
    }
}