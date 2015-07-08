using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class login_detail : System.Web.UI.Page
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
            string id = ViewState["id"].ToString();

            var R = this.db.Users.Single(p => p.Username == id);

            this.txtUsername.Value = R.Username;
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPassword.Value != this.txtPassword2.Value)
                {
                    throw new Exception("Passwords do not match.");
                }

                if (this.txtPassword.Value.Trim() == "")
                {
                    throw new Exception("Password can not be blank.");
                }

                if (ViewState["id"] == null)
                {
                    User U = new User();

                    U.Username = this.txtUsername.Value;
                    U.UserPassword = this.txtPassword.Value;
                    U.Role = this.cmbRole.SelectedValue;

                    this.db.Users.Add(U);
                    this.db.SaveChanges();
                }
                else
                {
                    string id = ViewState["id"].ToString();

                    var R = this.db.Users.Single(p => p.Username == id);

                    R.Username = this.txtUsername.Value;
                    R.UserPassword = this.txtPassword.Value;
                    R.Role = this.cmbRole.SelectedValue;
                    
                    this.db.SaveChanges();
                }

                Response.Redirect("login_list.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_list.aspx");
        }
    }
}