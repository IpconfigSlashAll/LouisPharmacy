using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmAddRefill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            lblMessage.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtPresc.Text.Trim().Length < 1)
            {
                lblMessage.Text = "Please enter a prescription number.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtPresc.Text) && (txtPresc.Text.Length < 0 || !txtPresc.Text.All(char.IsDigit)))
            {
                lblMessage.Text = "Please enter a valid prescription number.";
                lblMessage.Visible = true;
                return;
            }
            if (txtRefill.Text.Length <= 0 && txtRefill.Text.Length <= 0)
            {
                lblMessage.Text = "Please enter a refill amount.";
                lblMessage.Visible = true;
                return;
            }
            else
            {
                var AddDoc = new Class();
                try
                {
                    string Presc = txtPresc.Text.Trim();
                    string Refill = txtRefill.Text.Trim();
                    AddDoc.AddRefill(Presc, Refill);
                    lblMessage.Text = "Refill added succesfully!!!.";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
            }
        }
    }
}