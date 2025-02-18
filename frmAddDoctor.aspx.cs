using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Project
{
    public partial class frmAddDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            lblMessage.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhone.Text) && (txtPhone.Text.Length != 10 || !txtPhone.Text.All(char.IsDigit)))
            {
                lblMessage.Text = "Phone number must be 10 digits";
                lblMessage.Visible = true;
                return;
            }
            if (txtFname.Text.Length <= 0 && txtLName.Text.Length <= 0)
            {
                lblMessage.Text = "Please enter a First and last name.";
                lblMessage.Visible = true;
                return;
            }
            else
            {
                var AddDoc = new Class();
                try
                {
                    string Fname = txtFname.Text.Trim();
                    string LName = txtLName.Text.Trim();
                    string Email = txtEmail.Text.Trim();
                    string Phone = txtPhone.Text.ToString();
                    AddDoc.AddPhysician(Fname, LName, Email, Phone);
                    lblMessage.Text = "Doctor added successfully!!!.";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}