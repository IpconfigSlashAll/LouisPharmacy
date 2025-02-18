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
    public partial class frmViewRefill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["Login"] == null) && (string.IsNullOrEmpty(Session["Login"] as string)))
            {
                Response.Redirect("frmLogin.aspx");
            }
            Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js");

            //page
            dgvRefill.RowDataBound += new GridViewRowEventHandler(dgvRefill_RowDataBound);
            dgvRefill.PageIndexChanging += new GridViewPageEventHandler(dgvPatient_PageIndexChanging);
            dgvRefill.Sorting += new GridViewSortEventHandler(dgvRefill_Sorting);

            if (!IsPostBack)
            {
                //get data
                Cache.Remove("RData");
                //BindData();
                //////check if refresh
                if (Convert.ToString(Session["GRIDREFRESH"]) != "")
                {
                    Cache.Remove("RData");
                    BindData();
                }
            }
            else
            {
                if (Cache["RData"] != null)
                {
                    //do nothing
                }
            }
            lblMessage.Visible = false;
        }

        public void BindData()
        {
            Class aDataTier = new Class();

            string prescriptionId = Convert.ToString(Session["vRefill"]);

            txtPresc.Text = prescriptionId;

            DataSet aDataset = new DataSet();
            aDataset = aDataTier.LoadRefills(prescriptionId);
            dgvRefill.DataSource = aDataset.Tables[0];

            if (Cache["RData"] == null)
            {
                Cache.Add("RData", new DataView(aDataset.Tables[0]), // save daset as cache
                    null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                    System.TimeSpan.FromMinutes(10), //cache for 10 minutes
                    System.Web.Caching.CacheItemPriority.Default, null);
            }

            dgvRefill.Visible = true;
            dgvRefill.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPresc.Text.Trim() != "")
            {
                try
                {
                    Session["vRefill"] = txtPresc.Text.Trim();
                    BindData();
                }
                catch (Exception ex)
                {
                   // throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                dgvRefill.DataSource = null;
                lblMessage.Text = "No data found";
                lblMessage.Visible = true;
            }
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                CheckBox chk = new CheckBox();
                Label lbl = new Label();
                Label lblt = new Label();
                //string RXNO = "";
                Class pat = new Class();
                if (dgvRefill.Rows.Count > 0) //only do if there is a row
                {
                    //for each item as gridview in grdcustomer.item
                    foreach (GridViewRow row in dgvRefill.Rows)
                    {
                        //get the selected checkbox
                        chk = (CheckBox)row.FindControl("chkRXID");
                        if (chk.Checked)
                        {
                            lbl = (Label)row.Controls[0].FindControl("hidRXID");
                            lblt = (Label)row.Controls[0].FindControl("hidPrescID");
                            string RXNO = lbl.Text.Trim();
                            string PrescID = lblt.Text.Trim();
                            //delete the record one at a time
                            pat.DeletRefill(RXNO, PrescID);
                        }
                    }
                    //refresh datagrid
                    BindData();
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void Edit_click(object sender, CommandEventArgs e)
        {

        }

        public void lbtnEdit_Click(object sender, CommandEventArgs e)
        {
            string recordToBeEdited;
            Int64 myEditedRecord = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                Session["vRefill"] = txtPresc.Text.Trim();

                //Get the record
                recordToBeEdited = (e.CommandArgument.ToString().Trim());

                //this script will open a popup

                sb.Append("<script language='javascript'>");
                sb.Append("window.open('frmUpdateRefill.aspx?ID=" + Encrypt(recordToBeEdited.ToString()) + "&type=Edit" + "' , 'DisplayEdit',");
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
        protected void dgvRefill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvRefill_RowDataBound(object sender, GridViewRowEventArgs e)
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
            dgvRefill.PageIndex = page;
            BindData();
        }

        protected void dgvRefill_Sorting(Object sender, GridViewSortEventArgs e)
        {
            //sorting in ascending and descending order
            SortRecords(e.SortExpression);
        }

        private void SortRecords(string sortExpress)
        {
            string oldExpression = dgvRefill.SortExpression;
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

            source = (DataView)Cache["RData"];      // use the cache

            source.Sort = (" " + sortExpression + " " + this.sortDir);

            ViewState["oldSortExpression"] = sortExpress;    // save the sort as old sort
            Session["SortedView"] = source;
            dgvRefill.DataSource = source;
            dgvRefill.DataBind();
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