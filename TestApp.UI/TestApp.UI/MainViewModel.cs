using System;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Model.DataSeries3D;
using Xamarin.Forms;

namespace TestApp.UI
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            CandlestickSeries = new OhlcDataSeries<double, double>();
            LineSeries = new XyDataSeries<double, double>();
            Scatter3DSeries = new XyzDataSeries3D<double, double, double>();

            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                var y = Math.Sin(i * 0.05);
                LineSeries.Append(i, y);
                CandlestickSeries.Append(i, y, y + random.NextDouble(), y - random.NextDouble(), y + random.NextDouble() - 0.5);
            }

            LineStyle = new SolidPenStyle(Color.Red, 1f, true, null);
            StrokeUpStyle = new SolidPenStyle(Color.GreenYellow, 1f, true, null);
            StrokeDownStyle = new SolidPenStyle(Color.Olive, 1f, true, null);
            FillUpStyle = new SolidBrushStyle(Color.GreenYellow);
            FillDownStyle = new SolidBrushStyle(Color.Olive);

            for (int i = 0; i < 1000; i++)
            {
                Scatter3DSeries.Append(random.NextDouble(), random.NextDouble(), random.NextDouble());
            }

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

        public IOhlcDataSeries<double, double> CandlestickSeries { get; set; }

        public IXyzDataSeries3D<double, double, double> Scatter3DSeries { get; set; }

        public IPenStyle LineStyle { get; set; }

        public IPenStyle StrokeUpStyle { get; set; }
        public IPenStyle StrokeDownStyle { get; set; }
        public IBrushStyle FillUpStyle { get; set; }
        public IBrushStyle FillDownStyle { get; set; }

        public IComparable X1 { get; set; }
        public IComparable X2 { get; set; }
        public IComparable Y1 { get; set; }
        public IComparable Y2 { get; set; }


    }
}
