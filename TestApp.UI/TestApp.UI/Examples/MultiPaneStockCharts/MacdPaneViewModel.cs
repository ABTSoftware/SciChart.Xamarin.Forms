using System;
using System.Linq;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.Synchronization;
using TestApp.UI.Data;

namespace TestApp.UI.Examples.MultiPaneStockCharts
{
    public class MacdPaneViewModel : BaseChartPaneViewModel
    {
        public MacdPaneViewModel(PriceSeries priceSeries, SciChartVerticalGroup verticalGroup, DoubleRange xRange) : base(verticalGroup, xRange, "0.00")
        {
            var macdPoints = priceSeries.CloseData.Macd(12, 26, 9).ToList();
            var divergenceValues = macdPoints.Select(x => x.Divergence).ToList();
            var macdValues = macdPoints.Select(x => x.Macd).ToList();

            var histogramDataSeries = new XyDataSeries<DateTime, double>() {SeriesName = "Histogram"};
            histogramDataSeries.Append(priceSeries.TimeData, divergenceValues);

            RenderableSeries.Add(new FastColumnRenderableSeries()
            {
                DataSeries = histogramDataSeries
            });

            var macdDataSeries = new XyyDataSeries<DateTime, double>(){SeriesName = "MACD"};
            macdDataSeries.Append(priceSeries.TimeData, macdValues, macdPoints.Select(x => x.Signal));

            RenderableSeries.Add(new FastBandRenderableSeries(){DataSeries = macdDataSeries});

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = divergenceValues.Last()
            });

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = macdValues.Last()
            });
        }
    }
}