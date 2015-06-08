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
                    //this.LoadLists();

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

            Comeback C = this.db.Comebacks.Single(p => p.Comeback_ID == id);

            this.txtClosedDate.Value = C.CloseDate.Value.ToShortDateString();
            this.txtCustomerName.Value = C.CustomerName;
            this.txtMainPhone.Value = C.HomePhone;
            this.txtModel.Value = C.Model;
            this.txtNotes.Value = C.Notes;
            this.txtOpenDate.Value = C.OpenDate.Value.ToShortDateString();
            this.txtRONumber.Value = C.RO_Number;
            this.txtSerial.Value = C.VIN;
            this.txtWorkPhone.Value = C.WorkPhone;

            if (this.cmbStatus.Items.FindByValue(C.ComebackStatus.ToString()) != null)
            {
                this.cmbStatus.Items.FindByValue(C.ComebackStatus.ToString()).Selected = true;
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
    }
}