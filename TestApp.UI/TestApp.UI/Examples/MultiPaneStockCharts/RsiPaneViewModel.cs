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
    public class RsiPaneViewModel : BaseChartPaneViewModel
    {
        public RsiPaneViewModel(PriceSeries priceSeries, SciChartVerticalGroup verticalGroup, DoubleRange xRange) : base(verticalGroup, xRange, "0.0")
        {
            var rsiSeries = new XyDataSeries<DateTime, double>() {SeriesName = "RSI"};
            var rsiValues = priceSeries.Rsi(14).ToList();
            rsiSeries.Append(priceSeries.TimeData, rsiValues);

            RenderableSeries.Add(new FastLineRenderableSeries()
            {
                DataSeries = rsiSeries,
                StrokeStyle = new SolidPenStyle(Color.FromRgb(0xC6, 0xE6, 0xFF), 1f, true, null)
            });


            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = rsiValues.Last() 
            });
        }
    }
}