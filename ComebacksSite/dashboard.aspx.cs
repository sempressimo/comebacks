using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComebacksSite
{
	public partial class dashboard : System.Web.UI.Page
	{
		ComebackEntities db = new ComebackEntities();


		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					this.txtFrom.Value = "1/1/" + DateTime.Now.Year.ToString();
					this.txtTo.Value = DateTime.Today.ToShortDateString();

					this.RefreshDashboard();
				}
			}
			catch (Exception E)
			{
				this.CustomValidator1.IsValid = false;
				this.CustomValidator1.ErrorMessage = E.Message;
			}
		}

		protected void RefreshDashboard()
		{
			this.LoadComebacksByTech();

			this.LoadComebacksByAdvisor();

			this.LoadComebacksByMonth();
		}

		protected string GetCS()
		{
			string CS = ConfigurationManager.ConnectionStrings["ComebackEntities"].ConnectionString;

			CS = CS.Replace("metadata=res://*/ComebacksModel.csdl|res://*/ComebacksModel.ssdl|res://*/ComebacksModel.msl;provider=System.Data.SqlClient;provider connection string=\"", "");
			CS = CS.Replace("App=EntityFramework\"", "");

			return CS;
		}

		protected DataSet GetAdvisorComebacks(string DateFrom, string DateTo)
		{
			SqlConnection cn = null;

			try
			{
				cn = new SqlConnection(this.GetCS());
				cn.Open();

				DataSet ds = new DataSet();

				string Sql = "SELECT [Advisor_Name], COUNT([Advisor_Name]) AS [Comebacks] FROM Comebacks " +
								"WHERE [ComebackStatus] = 1 AND [OpenDate] BETWEEN '" + DateFrom + "' AND '" + DateTo + "' " +
									"GROUP BY [Advisor_Name]";

				SqlDataAdapter da = new SqlDataAdapter(Sql, cn);
				da.Fill(ds);


				return ds;

			}
			catch
			{
				throw;
			}
			finally
			{
				if (cn != null) cn.Close();
			}
		}

		protected DataSet GetTecnitianComebacks(string DateFrom, string DateTo)
		{
			SqlConnection cn = null;

			try
			{
				cn = new SqlConnection(this.GetCS());
				cn.Open();

				DataSet ds = new DataSet();

				string Sql = "SELECT [Technitian_Name], COUNT([Technitian_Name]) AS [Comebacks] FROM Comebacks " +
								"WHERE [ComebackStatus] = 1 AND [OpenDate] BETWEEN '" + DateFrom + "' AND '" + DateTo + "' " +
									"GROUP BY [Technitian_Name]";

				SqlDataAdapter da = new SqlDataAdapter(Sql, cn);
				da.Fill(ds);

				
				return ds;

			}
			catch
			{
				throw;
			}
			finally
			{
				if (cn != null) cn.Close();
			}
		}

		protected void LoadComebacksByTech()
		{
			DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart_by_tech");

			Title cTitle = new Title();
			cTitle.Text = "Comebacks por Tecnico";

			chart.SetTitle(cTitle);

			DataSet ds = this.GetTecnitianComebacks(this.txtFrom.Value, this.txtTo.Value);

			var models = new List<object[]>();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				string Name = r["Technitian_Name"].ToString();
				string Count = r["Comebacks"].ToString();

				models.Add(new object[] { Name + " - " + Count, Count });
			}

			PlotOptionsPie pop = new PlotOptionsPie();
			pop.Shadow = true;
			pop.InnerSize = new PercentageOrPixel(50, true);

			PlotOptionsPieDataLabels dataLabels = new PlotOptionsPieDataLabels();
			dataLabels.Style = "fontSize:'15px'";

			pop.DataLabels = dataLabels;

			Series s = new Series();
			s.Type = ChartTypes.Pie;
			s.Name = "Technitians";
			s.Data = new Data(models.ToArray());
			s.PlotOptionsPie = pop;

			chart.SetSeries(s);

			this.ltPieChartByTech.Text = chart.ToHtmlString();
		}

		protected void LoadComebacksByAdvisor()
		{
			DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart_by_advisor");

			Title cTitle = new Title();
			cTitle.Text = "Comebacks por Asesor";

			chart.SetTitle(cTitle);

			DataSet ds = this.GetAdvisorComebacks(this.txtFrom.Value, this.txtTo.Value);

			var models = new List<object[]>();

			foreach (DataRow r in ds.Tables[0].Rows)
			{
				string Name = r["Advisor_Name"].ToString();
				string Count = r["Comebacks"].ToString();

				models.Add(new object[] { Name + " - " + Count, Count });
			}

			PlotOptionsPie pop = new PlotOptionsPie();
			pop.Shadow = true;
			pop.InnerSize = new PercentageOrPixel(50, true);

			PlotOptionsPieDataLabels dataLabels = new PlotOptionsPieDataLabels();
			dataLabels.Style = "fontSize:'15px'";

			pop.DataLabels = dataLabels;

			Series s = new Series();
			s.Type = ChartTypes.Pie;
			s.Name = "Advisor";
			s.Data = new Data(models.ToArray());
			s.PlotOptionsPie = pop;

			chart.SetSeries(s);

			this.ltPieChartModel.Text = chart.ToHtmlString();
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

		protected void cmdSearch_ServerClick(object sender, EventArgs e)
		{
			try
			{
				this.RefreshDashboard();
			}
			catch (Exception E)
			{
				this.CustomValidator1.IsValid = false;
				this.CustomValidator1.ErrorMessage = E.Message;
			}
		}
	}
}