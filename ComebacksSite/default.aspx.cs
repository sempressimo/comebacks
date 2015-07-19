using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class _default : System.Web.UI.Page
    {
        ComebackEntities db = new ComebackEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadRecords(Request.QueryString["mode"]);
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected int PossibleComebacks(bool OnlyTodays)
        {
            return 1;
        }

        protected void LoadRecords(string Filter)
        {
            IQueryable<Comeback> R = null;

            R = this.db.Comebacks.Where(p => p.ComebackStatus == null || p.ComebackStatus == 3).OrderBy(p => p.OpenDate);

            this.lblPending.Text = R.Where(p => p.ComebackStatus == null).Count().ToString();

            this.lblParts.Text = R.Where(p => p.ComebackStatus == 3).Count().ToString();

            if (Filter == "parts")
            {
                R = this.db.Comebacks.Where(p => p.ComebackStatus == 3).OrderBy(p => p.OpenDate);

                this.gvRecords.DataSource = R.ToList();
            }
            else
            {
                this.gvRecords.DataSource = R.ToList();
            }

            this.gvRecords.DataBind();
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row_id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Open")
                {
                    Response.Redirect("comeback_detail.aspx?id=" + this.gvRecords.DataKeys[row_id].Value.ToString());
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.gvRecords.PageIndex = e.NewPageIndex;

                //this.LoadRecords();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvRecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.Cells[3].Text.Length > 7)
                    {
                        e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 7);
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}