using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmAddPrescription : System.Web.UI.Page
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
            try
            {
                string patientID = txtPatient.Text.Trim();
                string physicianID = txtDoctor.Text.Trim();
                string medName = txtMed.Text.Trim();
                string dosage = txtDosage.Text.Trim();
                string intMethod = txtInt.Text.Trim();
                int refillsLeft = int.Parse(txtRefill.Text.Trim());

                var AddPre = new Class();
                AddPre.AddPrescription(patientID, physicianID, medName, dosage, intMethod, refillsLeft);
                lblMessage.Text = "Prescription added succesfully!!!.";
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }
    }
}