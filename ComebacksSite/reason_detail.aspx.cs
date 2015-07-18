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

                    this.LoadResponsibleCategories();

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

        protected void LoadResponsibleCategories()
        {
            var C = this.db.ProblemResponsibleCategories.OrderBy(p => p.ProblemResponsibilityCategory_Description);

            this.cmbResponsible.DataSource = C.ToList();
            this.cmbResponsible.DataValueField = "ProblemResponsibilityCategory_ID";
            this.cmbResponsible.DataTextField = "ProblemResponsibilityCategory_Description";
            this.cmbResponsible.DataBind();
        }

        protected void LoadRecord()
        {
            int id = Convert.ToInt32(ViewState["id"]);

            var R = this.db.ComebackReasons.Single(p => p.ComebackReason_ID == id);

            if (this.cmbResponsible.Items.FindByValue(R.ProblemResponsibilityCategory_ID.ToString()) != null)
            {
                this.cmbResponsible.Items.FindByValue(R.ProblemResponsibilityCategory_ID.ToString()).Selected = true;
            }

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

                    R.ProblemResponsibilityCategory_ID = Convert.ToInt32(this.cmbResponsible.SelectedValue);
                    R.ReasonDescription = this.txtReasonDescription.Value;
                    R.IsActive = this.cbIsActive.Checked;

                    this.db.ComebackReasons.Add(R);
                    this.db.SaveChanges();
                }
                else
                {
                    int id = Convert.ToInt32(ViewState["id"]);

                    var R = this.db.ComebackReasons.Single(p => p.ComebackReason_ID == id);

                    R.ProblemResponsibilityCategory_ID = Convert.ToInt32(this.cmbResponsible.SelectedValue);
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