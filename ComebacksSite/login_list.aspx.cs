using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class login_list : System.Web.UI.Page
    {
        ComebackEntities db = new ComebackEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.LoadRecords();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecords()
        {
            var R = this.db.Users.Where(p => p.Username.Contains(this.txtSearch.Value) || string.IsNullOrEmpty(this.txtSearch.Value)).OrderBy(p => p.Username);

            this.gvRecords.DataSource = R.ToList();
            this.gvRecords.DataBind();

            this.gvRecords.Caption = "Accounts found: " + R.Count().ToString();
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Open")
                {
                    int rid = Convert.ToInt32(e.CommandArgument);

                    string id = this.gvRecords.DataKeys[rid].Value.ToString();

                    Response.Redirect("login_detail.aspx?id=" + id);
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_detail.aspx");
        }

        protected void gvRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rid = Convert.ToInt32(e.RowIndex);

                string id = this.gvRecords.DataKeys[rid].Value.ToString();

                var U = this.db.Users.Single(p => p.Username == id);

                this.db.Users.Remove(U);
                this.db.SaveChanges();

                this.LoadRecords();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void cmdSearch_ServerClick(object sender, EventArgs e)
        {
            try
            {
                this.LoadRecords();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}