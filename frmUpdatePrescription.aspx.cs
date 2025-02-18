using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmUpdatePrescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            if (!IsPostBack)
            {
                // Retrieve the query string
                if (String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    // Not the right entry point
                    Response.Redirect("Main.aspx");
                }

                else if (Request.QueryString["type"].Trim().ToUpper() == "VIEW") // Display mode
                {
                    GetPresc(Request.QueryString["ID"].Trim(), Request.QueryString["type"].Trim().ToUpper());
                    txtPresc.Enabled = false;
                    txtPatient.Enabled = false;
                    txtDoctor.Enabled = false;
                    txtMed.Enabled = false;
                    txtInt.Enabled = false;
                    txtDosage.Enabled = false;
                    txtRefill.Enabled = false;

                    btnUpdate.Visible = false;
                }

                else if (Request.QueryString["type"].Trim().ToUpper() == "EDIT") // Edit mode
                {
                    //txtPatientID.Text = Decrypt(Request.QueryString["ID"].Trim());
                    try
                    {
                        txtPresc.Text = Decrypt(Request.QueryString["ID"].Trim());
                        GetPresc(txtPresc.Text.Trim(), Request.QueryString["type"].Trim().ToUpper());
                        txtPresc.Enabled = false;
                        txtPatient.Enabled = true;
                        txtDoctor.Enabled = true;
                        txtMed.Enabled = true;
                        txtInt.Enabled = true;
                        txtDoctor.Enabled = true;
                        txtRefill.Enabled = true;
                    }
                    catch (Exception ex) 
                    { 
                        //nothing
                    }
                }
            }
            lblMessage.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Main.aspx");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "closeWindow", "window.close();", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                try
                {
                    string PrescriptionID = txtPresc.Text.Trim();
                    string patientID = txtPatient.Text.Trim();
                    string DoctorID = txtDoctor.Text.Trim();
                    string medName = txtMed.Text.Trim();
                    string Dosage = txtDosage.Text.Trim();
                    string intMethod = txtMed.Text.ToString();
                    string Refillleft = txtRefill.Text;
                    int refillsLeft = int.Parse(txtRefill.Text);
                    var updateDoc = new Class();
                    updateDoc.UpdatePrescription(PrescriptionID, patientID, DoctorID, medName, Dosage, intMethod, refillsLeft);
                lblMessage.Text = "Prescription updated successfully!!!.";
                lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
        }

        public void GetPresc(string PRESCID, string type)
        {
            // Retrieve the correct record
            Class PatDT = new Class();
            DataSet ds = new DataSet();
            string gender;

            ds = PatDT.GetPrescByID(PRESCID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPresc.Text = ds.Tables[0].Rows[0]["PrescriptionID"].ToString();
                txtPatient.Text = ds.Tables[0].Rows[0]["PatientID"].ToString();
                txtDoctor.Text = ds.Tables[0].Rows[0]["PHYSICIANID"].ToString();
                txtMed.Text = ds.Tables[0].Rows[0]["MedName"].ToString();
                txtInt.Text = ds.Tables[0].Rows[0]["Dosage"].ToString();
                txtDosage.Text = ds.Tables[0].Rows[0]["IntMethod"].ToString();
                txtRefill.Text = ds.Tables[0].Rows[0]["RefillsLeft"].ToString();
            }
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "hyddhrii%2moi43Hd5%%";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}