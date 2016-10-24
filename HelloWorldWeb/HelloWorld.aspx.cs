using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWeb
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblDisplayText.Text = "Hello World!";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblDisplayText.Text += txtAddText.Text + "<br />";
            txtAddText.Text = "";
            txtAddText.Focus();
        }
    }
}