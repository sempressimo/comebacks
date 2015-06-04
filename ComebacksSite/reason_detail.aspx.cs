using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class reason_detail : System.Web.UI.Page
    {
        ComebackEntities db = new ComebackEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ViewState["id"] = Request.QueryString["id"];

                    if (ViewState["id"] != null)
                    {
                        this.LoadRecord();
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecord()
        {
            int id = Convert.ToInt32(ViewState["id"]);

            var R = this.db.ComebackReasons.Single(p => p.ComebackReason_ID == id);
            this.cbIsActive.Checked = R.IsActive;

            this.txtReasonDescription.Value = R.ReasonDescription;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["id"] == null)
                {
                    ComebackReason R = new ComebackReason();

                    R.ReasonDescription = this.txtReasonDescription.Value;
                    R.IsActive = this.cbIsActive.Checked;

                    this.db.ComebackReasons.Add(R);
                    this.db.SaveChanges();
                }
                else
                {
                    int id = Convert.ToInt32(ViewState["id"]);

                    var R = this.db.ComebackReasons.Single(p => p.ComebackReason_ID == id);

                    R.ReasonDescription = this.txtReasonDescription.Value;
                    R.IsActive = this.cbIsActive.Checked;

                    this.db.SaveChanges();
                }

                Response.Redirect("reasons_list.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("reasons_list.aspx");
        }
    }
}