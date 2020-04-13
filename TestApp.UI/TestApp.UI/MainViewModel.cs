using System;
using System.Collections.Generic;
using System.Text;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using Xamarin.Forms;

namespace TestApp.UI
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            var dataSeries = new XyDataSeries<double, double>();

            for (int i = 0; i < 100; i++)
            {
                dataSeries.Append(i, Math.Sin(i * 0.05));
            }

            LineSeries = dataSeries;

            ChartTitle = "Hello World!";
            LineStroke = Color.FromHex("#FFFF6600");
            StrokeThickness = 1;
        }

        public IXyDataSeries<double, double> LineSeries
        {
            get;
            set;
        }

        public Color LineStroke
        {
            get;
            set;
        }

        public int StrokeThickness
        {
            get;
            set;
        }

        public string ChartTitle
        {
            get;
            set;
        }
    }
}
