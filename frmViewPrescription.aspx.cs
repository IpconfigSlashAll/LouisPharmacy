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
    public partial class frmViewPrescription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js");

            //page
            dgvPresc.RowDataBound += new GridViewRowEventHandler(dgvPresc_RowDataBound);
            dgvPresc.PageIndexChanging += new GridViewPageEventHandler(dgvPatient_PageIndexChanging);
            dgvPresc.Sorting += new GridViewSortEventHandler(dgvPresc_Sorting);

            if (!IsPostBack)
            {
                //get data
                Cache.Remove("PatientData");
                //BindData();
                //////check if refresh
                if (Convert.ToString(Session["GRIDREFRESH"]) != "")
                {
                    Cache.Remove("PatientData");
                    BindData();
                }
            }
            else
            {
                if (Cache["PatientData"] != null)
                {
                    //do nothing
                }
            }
            lblMessage.Visible = false;
        }

        public void BindData()
        {
            Class aDataTier = new Class();

            string PatientID = Convert.ToString(Session["vPresc"]);

            txtPatient.Text = PatientID;

            DataSet aDataset = new DataSet();
            aDataset = aDataTier.LoadPatientInfo(PatientID);
            dgvPresc.DataSource = aDataset.Tables[0];

            if (Cache["PrescData"] == null)
            {
                Cache.Add("PrescData", new DataView(aDataset.Tables[0]), // save daset as cache
                    null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                    System.TimeSpan.FromMinutes(10), //cache for 10 minutes
                    System.Web.Caching.CacheItemPriority.Default, null);
            }

            dgvPresc.Visible = true;
            dgvPresc.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatient.Text.Trim() != "")
            {
                try
                {
                    Session["vPresc"] = txtPatient.Text.Trim();
                    BindData();
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                dgvPresc.DataSource = null;
                lblMessage.Text = "No data found Please enter a valid Prescription ID.";
                lblMessage.Visible = true;
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = new CheckBox();
                Label lbl = new Label();
                string PrescID = "";
                Class pat = new Class();
                if (dgvPresc.Rows.Count > 0) //only do if there is a row
                {
                    //for each item as gridview in grdcustomer.item
                    foreach (GridViewRow row in dgvPresc.Rows)
                    {
                        //get the selected checkbox
                        chk = (CheckBox)row.FindControl("chkPrescID");
                        if (chk.Checked)
                        {
                            lbl = (Label)row.Controls[0].FindControl("hidPrescID");
                            PrescID = lbl.Text.Trim();
                            //delete the record one at a time
                            pat.DeletePresc(PrescID);
                        }
                    }
                    //refresh datagrid
                    BindData();
                }
            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Edit_click(object sender, EventArgs e)
        {

        }

        public void lbtnEdit_Click(object sender, CommandEventArgs e)
        {
            string recordToBeEdited;
            Int64 myEditedRecord = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                Session["vPresc"] = txtPatient.Text.Trim();

                //Get the record
                recordToBeEdited = (e.CommandArgument.ToString().Trim());

                //this script will open a popup

                sb.Append("<script language='javascript'>");
                sb.Append("window.open('frmUpdatePrescription.aspx?ID=" + Encrypt(recordToBeEdited.ToString()) + "&type=Edit" + "' , 'DisplayEdit',");
                sb.Append("'width=900, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');<");
                sb.Append("/script>");

                //register with ClientScript
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PopupScript", sb.ToString());
            }
            catch (Exception ex)
            {
               // throw new Exception(ex.Message, ex.InnerException);
            }
        }
        protected void dgvPresc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void dgvPresc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("cbSelectAll")).Attributes.Add("onclick", "javascript:SelectAll('" +
                    ((CheckBox)e.Row.FindControl("cbSelectAll")).ClientID + "')");
            }
        }

        protected void dgvPatient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //for paging
            Int32 pageNum = 0;
            pageNum = e.NewPageIndex;
            Paging(pageNum);
        }

        private void Paging(Int32 page)
        {
            dgvPresc.PageIndex = page;
            BindData();
        }

        protected void dgvPresc_Sorting(Object sender, GridViewSortEventArgs e)
        {
            //sorting in ascending and descending order
            SortRecords(e.SortExpression);
        }

        private void SortRecords(string sortExpress)
        {
            string oldExpression = dgvPresc.SortExpression;
            String newExpression = sortExpress;
            String lastValue, theSortField;
            String sortExpression;
            DataView source;
            String theDirection;

            string oldSortExp, newSortExp;


            string wildChar;
            theDirection = " ";
            wildChar = " %";

            lastValue = (string)ViewState["sortValue"];
            sortExpression = sortExpress;


            oldSortExp = (string)ViewState["oldSortExpression"];

            //get the last sort field and the new sort field
            if (oldSortExp == sortExpression)   //check for new expression, that is DB field
            {
                if (this.sortDir == "desc")
                {
                    this.sortDir = "asc";
                }
                else if (this.sortDir == null)
                {
                    this.sortDir = "asc";
                }
                else if (this.sortDir == "asc")
                {
                    this.sortDir = "desc";
                }
                else       //sort in ascending order the first time, column may not change if already sorted that way
                {
                    this.sortDir = "asc";
                }

            }
            theSortField = (string)ViewState["sortField"];

            source = (DataView)Cache["PrescData"];      // use the cache

            source.Sort = (" " + sortExpression + " " + this.sortDir);

            ViewState["oldSortExpression"] = sortExpress;    // save the sort as old sort
            Session["SortedView"] = source;
            dgvPresc.DataSource = source;
            dgvPresc.DataBind();
        }

        public string sortDir
        {
            get => (string)ViewState["sortDir"];
            set => ViewState["sortDir"] = value;
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "hyddhrii%2moi43Hd5%%";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

    }
}