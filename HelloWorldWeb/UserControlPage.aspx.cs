using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorldWeb
{
    public partial class UserControlPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            lblMessage.Text = UserControl.CurrentNumber.ToString();
            base.OnLoadComplete(e);
        }
    }
}