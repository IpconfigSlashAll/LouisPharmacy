using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmAddPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            if (!IsPostBack)
            {
                ddlState.DataSource = StateManager.getStates();
                ddlState.DataTextField = "name";
                ddlState.DataValueField = "abbreviation";
                ddlState.DataBind();
                ddlState.SelectedValue = "PA";
            }
            lblMessage.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime DOBB = DateTime.Parse(txtDOB.Text);

            if (DOBB > DateTime.Today)
            {
                lblMessage.Text = "Dude, you haven't been born yet!";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtFName.Text) && (!txtFName.Text.All(char.IsLetter)))
            {
                lblMessage.Text = "First name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtLName.Text) && !txtLName.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                lblMessage.Text = "Last name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            txtDOB.Text = DateTime.Now.AddYears(-18).ToString("dd/MM/yyyy");

            if (txtDOB.Text.Trim().Length < 8)
            {
                lblMessage.Text = "Invalid date format for DOB.";
                lblMessage.Visible = true;
                return;
            }

            if (ddlGender.Text.Trim().Length <= 3)
            {
                lblMessage.Text = "Please select a gender.";
                lblMessage.Visible = true;
                return;
            }

            if ((txtMI.Text.Trim().Length >= 2) || (!txtMI.Text.Trim().All(char.IsLetter)))
            {
                lblMessage.Text = "Middle initial must be only 1 letter.";
                lblMessage.Visible = true;
                return;
            }

            if ((txtIns.Text.Trim() !="Yes") && (txtIns.Text != "No") && (txtIns.Text != "Y") && (txtIns.Text != "N"))
            {
                lblMessage.Text = "Please insert Yes, No, Y or N for Insurance.";
                lblMessage.Visible = true;
               return;
            }

            if (!string.IsNullOrEmpty(txtPhone.Text) && (txtPhone.Text.Length != 10 || !txtPhone.Text.All(char.IsDigit)))
            {
                lblMessage.Text = "Phone number must be exactly 10 digits.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtZip.Text) && (txtZip.Text.Length != 5 || !txtZip.Text.All(char.IsDigit)))
            {
                lblMessage.Text = "Zip code must be 5 digits.";
                lblMessage.Visible = true;
                return;
            }

            if (txtFName.Text.Trim().Length <= 0 || txtLName.Text.Trim().Length <= 0)
            {
                lblMessage.Text = "Enter a First and last name.";
                lblMessage.Visible = true;
                return;
            }

            if(ddlGender.Text.Trim().Length <= 0)
            {
                lblMessage.Text = "Please select a gender.";
                lblMessage.Visible = true;
                return;
            }

            else
            {
                var AddPatient = new Class();
                try
                {
                    string Fname = txtFName.Text.Trim();
                    string M_I = txtMI.Text.Trim();
                    string LName = txtLName.Text.Trim();
                    string DOB = DOBB.ToString();
                    string Gender = ddlGender.Text.ToString();
                    string Phone = txtPhone.Text.ToString();
                    string STREET = txtAddress.Text.Trim();
                    string CITY = txtCity.Text.Trim();
                    string stateAdd = ddlState.Text.ToString();
                    string ZIP = txtZip.Text.ToString();
                    string Insurance = txtIns.Text.ToString();
                    string COUNTRY = ddlCountry.Text.ToString();
                    AddPatient.AddPatient(Fname, M_I, LName, DOB, Gender, Phone, STREET, CITY, stateAdd, ZIP, Insurance, COUNTRY);
                    lblMessage.Text = "Patient added succesfully!!!.";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFName.Text = string.Empty;
            txtMI.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtDOB.Text = string.Empty;
            txtZip.Text = string.Empty;
            txtIns.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPhone.Text = string.Empty;
            ddlGender.SelectedValue = "";
            ddlState.SelectedValue = "PA";
        }
    }
}