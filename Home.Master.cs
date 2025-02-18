using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Project
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            View.Visible = false;
            Add.Visible = false;
            Other.Visible = false;

            if (Session["Login"] != null)
            {
                View.Visible = true;
                Add.Visible = true;
                Other.Visible = true;
            }
            else
            {
                View.Visible = false;
                Add.Visible = false;
                Other.Visible = false;
            }
        }
    }
}