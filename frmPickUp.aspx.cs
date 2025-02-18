using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmPickUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            lblMessage.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPresc.Text.Trim() != "")
            {
                try
                {
                    int prescriptionId = int.Parse(txtPresc.Text.Trim());
                    string status = ddlstatus.Text.Trim();
                    Class refilltrigger = new Class();
                    refilltrigger.TriggerRefillProcedure(prescriptionId, status);
                    lblMessage.Text = "Pick Up Completed!!!.";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "No data found.";
                lblMessage.Visible = true; 
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}