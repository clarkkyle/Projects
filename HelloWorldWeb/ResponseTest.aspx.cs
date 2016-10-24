using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWeb
{
    public partial class ResponseTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("CourseList.aspx");

            string test = "nothing";

            if(Request.Params["test"] != null)
                    test = Request.Params["test"];

            Response.Write(@"
<!DOCTYPE html>
<body>
Hello there " + test + @"
</body>
</html>
");
            Response.Flush();
            Response.Close();
        }
    }
}