using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class responsibility_categories_detail : System.Web.UI.Page
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

            var R = this.db.ProblemResponsibleCategories.Single(p => p.ProblemResponsibilityCategory_ID == id);

            this.cbIsActive.Checked = R.IsActive.Value;

            this.txtDescription.Value = R.ProblemResponsibilityCategory_Description;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["id"] == null)
                {
                    ProblemResponsibleCategory R = new ProblemResponsibleCategory();

                    R.ProblemResponsibilityCategory_Description = this.txtDescription.Value;
                    R.IsActive = this.cbIsActive.Checked;

                    this.db.ProblemResponsibleCategories.Add(R);
                    this.db.SaveChanges();
                }
                else
                {
                    int id = Convert.ToInt32(ViewState["id"]);

                    var R = this.db.ProblemResponsibleCategories.Single(p => p.ProblemResponsibilityCategory_ID == id);

                    R.ProblemResponsibilityCategory_Description = this.txtDescription.Value;
                    R.IsActive = this.cbIsActive.Checked;

                    this.db.SaveChanges();
                }

                Response.Redirect("responsibilty_categories_list.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("responsibilty_categories_list.aspx");
        }
    }
}