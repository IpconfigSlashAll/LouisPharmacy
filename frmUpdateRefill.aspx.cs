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
    public partial class frmUpdateRefill : System.Web.UI.Page
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

                else if (Request.QueryString["type"].Trim().ToUpper() == "EDIT") // Edit mode
                {
                    //txtPatientID.Text = Decrypt(Request.QueryString["ID"].Trim());
                    try
                    {
                        txtRX.Text = Decrypt(Request.QueryString["ID"].Trim());
                        GetRefill(txtRX.Text.Trim(), Request.QueryString["type"].Trim().ToUpper());
                        txtRX.Enabled = false;
                        txtDate.Enabled = true;
                        ddlStatus.Enabled = true;
                    }
                    catch (Exception ex) 
                    {
                        //nothing
                    }
                }
            }
            lblMessage.Visible = false; 
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string RXNO = txtRX.Text.Trim();
                string Datee = txtDate.Text.Trim();
                string Status = ddlStatus.Text.Trim();
                var updateDoc = new Class();
                DateTime Date = DateTime.Parse(Datee);
                updateDoc.UpdateRefill(RXNO, Date, Status);
                lblMessage.Text = "Refill updated successfully!!!.";
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }

        public void GetRefill(string RX, string type)
        {
            // Retrieve the correct record
            Class RefillDT = new Class();
            DataSet ds = new DataSet();

            ds = RefillDT.RXByID(RX);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtRX.Text = ds.Tables[0].Rows[0]["RX_NO"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["RefillDate"].ToString();
                ddlStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "closeWindow", "window.close();", true);
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