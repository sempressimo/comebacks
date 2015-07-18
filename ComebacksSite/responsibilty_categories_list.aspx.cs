﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class responsibilty_categories_list : System.Web.UI.Page
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
                this.CustomValidator1.ErrorMessage = ((E.InnerException != null) ? E.InnerException.Message : E.Message);
            }
        }

        protected void LoadRecords()
        {
            var R = this.db.ProblemResponsibleCategories.Where(p => p.ProblemResponsibilityCategory_Description.Contains(this.txtSearch.Value) || string.IsNullOrEmpty(this.txtSearch.Value)).OrderBy(p => p.ProblemResponsibilityCategory_Description);

            this.gvRecords.DataSource = R.ToList();
            this.gvRecords.DataBind();

            this.gvRecords.Caption = "Records found: " + R.Count().ToString();
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Open")
                {
                    int rid = Convert.ToInt32(e.CommandArgument);

                    string id = this.gvRecords.DataKeys[rid].Value.ToString();

                    Response.Redirect("responsibility_categories_detail.aspx?id=" + id);
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = ((E.InnerException != null) ? E.InnerException.Message : E.Message);
            }
        }

        protected void lbNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("responsibility_categories_detail.aspx");
        }

        protected void gvRecords_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rid = Convert.ToInt32(e.RowIndex);

                int id = Convert.ToInt32(this.gvRecords.DataKeys[rid].Value);

                var U = this.db.ProblemResponsibleCategories.Single(p => p.ProblemResponsibilityCategory_ID == id);

                this.db.ProblemResponsibleCategories.Remove(U);
                this.db.SaveChanges();

                this.LoadRecords();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = ((E.InnerException != null) ? E.InnerException.Message : E.Message);
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