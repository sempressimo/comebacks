using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtUsername.Focus();
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            //DEBUG:
            //FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);
            //Response.Redirect("sub_reasons_list.aspx");

            ComebackEntities db = new ComebackEntities();

            var U = db.Users.SingleOrDefault(p => p.Username == this.txtUsername.Text && p.UserPassword == this.txtPassword.Value);

            if (U != null)
            {
                Session["Username"] = U.Username;
                Session["Role"] = U.Role;

                FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);

                Response.Redirect("default.aspx?mode=pending");
            }
            else
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = "Incorrect username or password.";
            }
        }
    }
}