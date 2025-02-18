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
    public partial class frmUpdateDoctor : System.Web.UI.Page
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
                    GetDoctor(Request.QueryString["ID"].Trim(), Request.QueryString["type"].Trim().ToUpper());
                    txtDoctor.Enabled = false;
                    txtFName.Enabled = false;
                    txtLName.Enabled = false;
                    txtPhone.Enabled = false;
                    txtEmail.Enabled = false;

                    btnUpdate.Visible = false;
                }

                else if (Request.QueryString["type"].Trim().ToUpper() == "EDIT") // Edit mode
                {
                    //txtPatientID.Text = Decrypt(Request.QueryString["ID"].Trim());
                    try
                    {
                        txtDoctor.Text = Decrypt(Request.QueryString["ID"].Trim());
                        GetDoctor(txtDoctor.Text.Trim(), Request.QueryString["type"].Trim().ToUpper());
                        txtDoctor.Enabled = false;
                        txtFName.Enabled = true;
                        txtLName.Enabled = true;
                        txtPhone.Enabled = true;
                        txtEmail.Enabled = true;
                    }
                    catch (Exception ex) { }
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
            if (!string.IsNullOrEmpty(txtFName.Text.Trim()) && (!txtFName.Text.Trim().All(char.IsLetter)))
            {
                lblMessage.Text = "First name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtLName.Text) && (!txtLName.Text.All(char.IsLetter)))
            {
                lblMessage.Text = "First name must be letter.";
                lblMessage.Visible = true;
                return;
            }

            if (!string.IsNullOrEmpty(txtPhone.Text) && (txtPhone.Text.Length != 10 || !txtPhone.Text.All(char.IsDigit)))
            {
                lblMessage.Text = "Phone number must be exactly 10 digits.";
                lblMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(txtDoctor.Text))
            {
                lblMessage.Text = "Patient ID required.";
                lblMessage.Visible = true;
                return;
            }
                txtFName.Enabled = true;
                txtLName.Enabled = true;
                txtEmail.Enabled = true;
                txtPhone.Enabled = true;
                try
                {
                    string DoctorID = txtDoctor.Text.Trim();
                    string Fname = txtFName.Text.Trim();
                    string LName = txtLName.Text.Trim();
                    string Email = txtEmail.Text.Trim();
                    string Phone = txtPhone.Text.ToString();
                    var updateDoc = new Class();
                    updateDoc.UpdateDoctor(DoctorID, Fname, LName, Email, Phone);
                lblMessage.Text = "Doctor updated successfully.";
                lblMessage.Visible = true;

                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                }
        }

        public void GetDoctor(string DOCTORID, string type)
        {
            // Retrieve the correct record
            Class PatDT = new Class();
            DataSet ds = new DataSet();

            ds = PatDT.GetDoctorByID(DOCTORID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtDoctor.Text = ds.Tables[0].Rows[0]["PhysicianID"].ToString();
                txtFName.Text = ds.Tables[0].Rows[0]["FNAME"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["LNAME"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["PHONE"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["EMAIL"].ToString();
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