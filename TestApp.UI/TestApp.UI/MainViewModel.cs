using System;
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

            XRange = new DoubleRange(30, 50);

            X1 = 30;
            X2 = 50;
            Y1 = 0;
            Y2 = 0.7;
        }

        public IRange XRange { get; set; }

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

        public IComparable X1 { get; set; }
        public IComparable X2 { get; set; }
        public IComparable Y1 { get; set; }
        public IComparable Y2 { get; set; }
    }
}
