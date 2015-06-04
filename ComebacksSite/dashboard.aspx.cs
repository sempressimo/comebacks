using Highchart.Core;
using Highchart.Core.Data.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hcVendas.YAxis.Add(new YAxisItem { title = new Title("Faturamento") });
            hcVendas.XAxis.Add(new XAxisItem { categories = new[] { "1994", "1995", "1996", "1997", "1998", "1999", "2000", "2001", "2002" } });

            //New data collection
            var series = new Collection<Serie>();
            series.Add(new Serie { data = new object[] { 400, 435, 446, 479, 554, 634, 687, 750, 831 } });

            //bind 
            hcVendas.DataSource = series;
            hcVendas.DataBind();
        }
    }
}