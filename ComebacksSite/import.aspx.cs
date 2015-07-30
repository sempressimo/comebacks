using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class import : System.Web.UI.Page
    {
        ComebackEntities db = new ComebackEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetDemoName(string Purpose)
        {
            List<string> lst = new List<string>();

            if (Purpose == "Car")
            {
                lst.Add("320i");
                lst.Add("520i");
                lst.Add("Series 7");
                lst.Add("Series X");
                lst.Add("335i");
                lst.Add("Series Z");
                lst.Add("Series M");
            }
            else if (Purpose == "Advisor")
            {
                lst.Add("Rodriguez");
                lst.Add("Rivera");
                lst.Add("Guzman");
                lst.Add("Arroyo");
                lst.Add("Martinez");
                lst.Add("Perez");
                lst.Add("Jimenez");
            }
            else
            {
                lst.Add("Smith");
                lst.Add("Johnson");
                lst.Add("Williams");
                lst.Add("Jones");
                lst.Add("Brown");
                lst.Add("Davis");
                lst.Add("Miller");
                lst.Add("Wilson");
                lst.Add("Moore");
                lst.Add("Taylor");
                lst.Add("Anderson");
                lst.Add("Thomas");
                lst.Add("Jackson");
                lst.Add("White");
                lst.Add("Harris");
                lst.Add("Chris");
            }

            Random r = new Random(DateTime.Now.Millisecond);
            
            int rn = r.Next(lst.Count);

            return lst[rn];
        }

        protected void DemoRecords()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i <= 11; i++)
            {
                Comeback C = new Comeback();

                C.RO_Number = r.Next(99999).ToString("00000");
                C.New_RO_Number = r.Next(99999).ToString("00000");
                C.CloseDate = DateTime.Today;
                C.CustomerName = this.GetDemoName("Cust");
                C.HomePhone = "787-123-1234";
                C.Model = this.GetDemoName("Car");
                C.OpenDate = DateTime.Today;
                C.VIN = "123456789" + r.Next(9);
                C.WorkPhone = "787-888-1209";
                C.Technitian_Name = this.GetDemoName("Cust");
                C.Advisor_Name = this.GetDemoName("Advisor");

                int rn = r.Next(9);

                C.CarYear = "201" + rn.ToString();

                this.db.Comebacks.Add(C);
                this.db.SaveChanges();
            }
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                this.DemoRecords();

                Response.Redirect("default.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}