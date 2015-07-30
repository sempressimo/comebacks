using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class comeback_detail : System.Web.UI.Page
    {
        ComebackEntities db = new ComebackEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.LoadLists();

                    ViewState["id"] = Request.QueryString["id"];

                    if (ViewState["id"] != null)
                    {
                        this.LoadRecord();

                        this.LoadPreviousVisits();
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadPreviousVisits()
        {
            IQueryable<Comeback> R = null;

            R = this.db.Comebacks.Where(p => p.VIN == this.txtSerial.Value).OrderBy(p => p.OpenDate);

            this.gvRelatedRecords.DataSource = R.ToList();
            this.gvRelatedRecords.DataBind();
        }

        protected void LoadLists()
        {
            var R = this.db.ComebackReasons.OrderBy(p => p.ReasonDescription);

            this.cmbReason.DataSource = R.ToList();
            this.cmbReason.DataValueField = "ComebackReason_ID";
            this.cmbReason.DataTextField = "ReasonDescription";
            this.cmbReason.DataBind();

            this.cmbReason.Items.Insert(0, new ListItem("- Please Select -", "-1"));

            var SR = this.db.ComebackSubReasons.OrderBy(p => p.SubReasonDescription);

            this.cmbSubReason.DataSource = SR.ToList();
            this.cmbSubReason.DataValueField = "Comeback_SubReason_ID";
            this.cmbSubReason.DataTextField = "SubReasonDescription";
            this.cmbSubReason.DataBind();

            this.cmbSubReason.Items.Insert(0, new ListItem("- Please Select -", "-1"));
        }

        protected void LoadRecord()
        {
            int id = Convert.ToInt32(ViewState["id"]);

            Comeback C = this.db.Comebacks.Single(p => p.Comeback_ID == id);

            if (C.CloseDate != null) this.txtClosedDate.Value = C.CloseDate.Value.ToShortDateString();
            this.txtCustomerName.Value = C.CustomerName;
            this.txtMainPhone.Value = C.HomePhone;
            this.txtModel.Value = C.CarYear.ToString() + " / " + C.Model;
            this.txtNotes.Value = C.Notes;
            this.txtOpenDate.Value = C.OpenDate.Value.ToShortDateString();
            this.txtRONumber.Value = C.RO_Number;
            this.txtNewRONumber.Value = C.New_RO_Number;
            this.txtSerial.Value = C.VIN;
            this.txtWorkPhone.Value = C.WorkPhone;
            this.txtTechnician.Value = C.Technitian_Name;
            this.txtAdvisor.Value = C.Advisor_Name;

            if (this.cmbStatus.Items.FindByValue(C.ComebackStatus.ToString()) != null)
            {
                this.cmbStatus.Items.FindByValue(C.ComebackStatus.ToString()).Selected = true;
            }

            if (this.cmbStatus.SelectedValue == "3")
            {
                // Show parts note field
                this.div_parts_note.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ViewState["id"]);

                Comeback C = this.db.Comebacks.Single(p => p.Comeback_ID == id);

                C.Notes = this.txtNotes.InnerText;

                C.ComebackStatus = Convert.ToInt32(this.cmbStatus.SelectedValue);

                this.db.SaveChanges();

                Response.Redirect("default.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbStatus.SelectedIndex == 1)
                {
                    this.div_reason.Visible = true;
                }
                else if (this.cmbStatus.SelectedIndex == 3)
                {
                    this.div_parts_note.Visible = true;
                    this.div_reason.Visible = this.div_sub_reason.Visible = false;
                }
                else
                {
                    this.div_reason.Visible = this.div_sub_reason.Visible = false;
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void cmbReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.div_sub_reason.Visible = this.div_reason.Visible;
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvRecords_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvRecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}