using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
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
            try
            {
                LoadComebacksByModel();

                LoadComebacksByMonth();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadComebacksByModel()
        {
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart");

            Title cTitle = new Title();
            cTitle.Text = "Comebacks por Modelo";

            chart.SetTitle(cTitle);

            var models = new List<object[]>();
              models.Add(new object[] { "M3", 35.0 });
              models.Add(new object[] { "Series 3", 25 });
              models.Add(new object[] { "Z4", 20 });
              models.Add(new object[] { "X3", 15 });
              models.Add(new object[] { "Series 5", 5 });

            chart.SetSeries(new Series
                 {
                    Type = ChartTypes.Pie,
                    Name = "BMW Models",
                    Data = new Data(models.ToArray())
                 });

            this.ltPieChart.Text = chart.ToHtmlString();
        }

        protected void LoadComebacksByMonth()
        {
            /*
            Series seriesRainfall2011 = new Series();
            seriesRainfall2011.Data = new Data(new object[]
                        {
                            41.1, 33.3, 38.5, 29.7, 81.9, 76.7, 96.1, 87.4, 68.0, 37.1,
                            36.7, 32.2
                        });

            seriesRainfall2011.Name = "2011";
            seriesRainfall2011.Type = ChartTypes.Column;
            */

            Series seriesRainfall2012 = new Series();
            seriesRainfall2012.Data = new Data(new object[]
                        {
                            10, 12, 4, 6, 8, 11, 11, 15, 12, 10,
                            11, 9
                        });

            seriesRainfall2012.Name = "2012";
            seriesRainfall2012.Type = ChartTypes.Column;


            //Series[] series = new Series[] { seriesRainfall2011, seriesRainfall2012 };
            Series[] series = new Series[] { seriesRainfall2012 };

            Highcharts chart = new Highcharts("bar")
                .SetTitle(new Title
                {
                    Text = "Comebacks for Mes"
                })
                .SetSubtitle(new Subtitle
                {
                    Text = "2015"
                })
                .SetXAxis(new XAxis
                {
                    Categories =
                        new[]
                            {
                                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
                            }
                })

                .SetSeries(series);

            ltChart.Text = chart.ToHtmlString();
        }
    }
}