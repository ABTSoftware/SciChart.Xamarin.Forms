using System;
using System.Linq;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.Synchronization;
using TestApp.UI.Data;
using Xamarin.Forms;

namespace TestApp.UI.Examples.MultiPaneStockCharts
{
    public class PricePaneViewModel : BaseChartPaneViewModel
    {
        public PricePaneViewModel(PriceSeries priceSeries, SciChartVerticalGroup verticalGroup, DoubleRange xRange) : base(verticalGroup, xRange, "$0.0000", true)
        {
            var stockPrices = new OhlcDataSeries<DateTime, double>(){SeriesName = "OHLC"};
            stockPrices.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            RenderableSeries.Add(new FastCandlestickRenderableSeries()
            {
                DataSeries = stockPrices
            });

            var maLow = new XyDataSeries<DateTime, double>(){SeriesName = "Low Line"};
            var maLowYData = priceSeries.CloseData.MovingAverage(50).ToList();
            maLow.Append(priceSeries.TimeData, maLowYData);

            RenderableSeries.Add(new FastLineRenderableSeries()
            {
                DataSeries = maLow,
                StrokeStyle = new SolidPenStyle(Color.FromRgb(0xFF, 0x33, 0x33), 1, false, null)
            });

            var maHigh = new XyDataSeries<DateTime, double>(){SeriesName = "High Line"};
            var maHighYData = priceSeries.CloseData.MovingAverage(200).ToList();
            maHigh.Append(priceSeries.TimeData, maHighYData);

            RenderableSeries.Add(new FastLineRenderableSeries()
            {
                DataSeries = maHigh,
                StrokeStyle = new SolidPenStyle(Color.FromRgb(0x33, 0xDD, 0x33), 1, false, null)
            });

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = priceSeries.CloseData.Last(),
                BackgroundColor = Color.FromRgb(0xFF, 0x33, 0x33),
            });

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = maLowYData.Last(),
                BackgroundColor = Color.FromRgb(0xFF, 0x33, 0x33),
            });

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = maHighYData.Last(),
                BackgroundColor = Color.FromRgb(0x33, 0xDD, 0x33),
            });
        }
    }
}