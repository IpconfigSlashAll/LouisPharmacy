using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class frmUpdatePatient : System.Web.UI.Page
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
                    GetPat(Request.QueryString["ID"].Trim(), Request.QueryString["type"].Trim().ToUpper());
                    txtPatient.Enabled = false;
                    txtFName.Enabled = false;
                    txtMI.Enabled = false;
                    txtLName.Enabled = false;
                    txtDOB.Enabled = false;
                    txtGender.Enabled = false;
                    txtPhone.Enabled = false;
                    txtAddress.Enabled = false;
                    txtCity.Enabled = false;
                    ddlState.Enabled = false;
                    txtZip.Enabled = false;
                    ddlCountry.Enabled = false;
                    txtIns.Enabled = false;

                    btnUpdate.Visible = false;
                }

                else if (Request.QueryString["type"].Trim().ToUpper() == "EDIT") // Edit mode
                {
                    //txtPatientID.Text = Decrypt(Request.QueryString["ID"].Trim());
                    try
                    {
                        txtPatient.Text = Decrypt(Request.QueryString["ID"].Trim());
                        GetPat(txtPatient.Text.Trim(), Request.QueryString["type"].Trim().ToUpper());
                        txtPatient.Enabled = false;
                        txtFName.Enabled = true;
                        txtMI.Enabled = true;
                        txtLName.Enabled = true;
                        txtDOB.Enabled = true;
                        txtGender.Enabled = true;
                        txtPhone.Enabled = true;
                        txtAddress.Enabled = true;
                        txtCity.Enabled = true;
                        ddlState.Enabled = true;
                        txtZip.Enabled = true;
                        ddlCountry.Enabled = true;
                        txtIns.Enabled = true;
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
            if (!string.IsNullOrEmpty(txtFName.Text) && (!txtFName.Text.All(char.IsLetter)))
            {
                lblMessage.Text = "'First name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtLName.Text) && (!txtLName.Text.All(char.IsLetter)))
            {
                lblMessage.Text = "'Last name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtPhone.Text) && (txtPhone.Text.Length < 10))
            {
                lblMessage.Text = "Phone number must be exactly 10 digits.";
                lblMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(txtPatient.Text))
            {
                lblMessage.Text = "Patient ID required.";
                lblMessage.Visible = true;
                return;
            }

                try
                {
                    string patientId = txtPatient.Text.Trim();
                    string Fname = txtFName.Text.Trim();
                    string M_I = txtMI.Text.Trim();
                    string LName = txtLName.Text.Trim();
                    string DOB = txtDOB.Text.Trim();
                    string Gender = txtGender.Text.Trim();
                    string Phone = txtPhone.Text.ToString();
                    string STREET = txtAddress.Text.Trim();
                    string CITY = txtCity.Text.Trim();
                    string state = ddlState.Text.ToString();
                    string ZIP = txtZip.Text.ToString();
                    string COUNTRY = ddlCountry.Text.ToString();
                    string Insurance = txtIns.Text.ToString();
                    var updatePatientInstance = new Class();
                    updatePatientInstance.UpdatePatient(patientId, Fname, M_I, LName, DOB, Gender, Phone, STREET, CITY, state, ZIP, COUNTRY, Insurance);
                lblMessage.Text = "Patient updated successfully!!!.";
                lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
        }

        public void GetPat(string PATIENTID, string type)
        {
            // Retrieve the correct record
            Class PatDT = new Class();
            DataSet ds = new DataSet();
            string gender;

            ds = PatDT.GetPatientByID(PATIENTID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPatient.Text = ds.Tables[0].Rows[0]["PATIENTID"].ToString();
                txtFName.Text = ds.Tables[0].Rows[0]["FNAME"].ToString();
                txtMI.Text = ds.Tables[0].Rows[0]["M_I"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["LNAME"].ToString();
                txtDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
                txtGender.Text = ds.Tables[0].Rows[0]["GENDER"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["PHONE"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["STREET"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["CITY"].ToString();
                txtZip.Text = ds.Tables[0].Rows[0]["ZIP"].ToString();
                ddlCountry.Text = ds.Tables[0].Rows[0]["COUNTRY"].ToString();
                txtIns.Text = ds.Tables[0].Rows[0]["INSURANCE"].ToString();

                gender = ds.Tables[0].Rows[0]["GENDER"].ToString().Trim();
                if (gender.ToUpper() == "F")
                {
                    txtGender.Text = "FEMALE";
                }
                else
                {
                    txtGender.Text = "MALE";
                }
                txtGender.Enabled = false;
            }

            // Salary Field
            //Decimal mysalary = Decimal.Parse(ds.Tables[0].Rows[0]["ACCT_BAL"].ToString());
            //txt.Text = mysalary.ToString("C");

            // State Dropdown
            ddlState.DataSource = StateManager.getStates();
            ddlState.DataTextField = "FullAndAbbrev";
            ddlState.DataValueField = "abbreviation";
            ddlState.SelectedValue = "PA";
            ddlState.DataBind();

            ddlState.SelectedValue = ds.Tables[0].Rows[0]["STATE_ADD"].ToString(); // FIX IT
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