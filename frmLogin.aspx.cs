using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;
            if (Session["Login"] != null)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
                lblMessage.Text = "You are currently Logged in.";
                lblMessage.Visible = true;
                btnLogin.Text = "Logout";
            }
            else
            {
                txtPassword.Visible = true;
                txtUsername.Visible = true;
                btnLogin.Text = "Login";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (btnLogin.Text.Trim().ToUpper() == "LOGIN")
            {
                if (!String.IsNullOrEmpty(txtUsername.Text) && (!string.IsNullOrEmpty(txtPassword.Text)))
                 {
                    var acess = new Class();
                    try
                    {
                        string Username = txtUsername.Text.Trim();
                        string Password = txtPassword.Text.Trim();
                        var accessGranted = acess.VerifyUser(Username, Password);

                        if (accessGranted)
                        {
                            Session["Login"] = true;
                            lblMessage.Text = "Login susscesfull";
                            Response.Redirect("Main.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Incorrect Username or Password!!!";
                            lblMessage.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {

                        lblMessage.Text = "Error";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "Enter a Username and Password!!!";
                    lblMessage.Visible = true;
                }
            }
            if (btnLogin.Text.Trim().ToUpper() == "LOGOUT")
            {
                //clear sessioon
                Session.Abandon(); //abandon session
                Session["Login"] = string.Empty; //clear session variable
                Session.Clear(); //clear all session

                Response.Redirect("Main.aspx");
            }
        }
    }
}