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
    public class VolumePaneViewModel : BaseChartPaneViewModel
    {
        public VolumePaneViewModel(PriceSeries priceSeries, SciChartVerticalGroup verticalGroup, DoubleRange xRange) : base(verticalGroup, xRange, "###E+0")
        {
            var volumePrices = new XyDataSeries<DateTime, double>() {SeriesName = "Volume"};
            var volumeValues = priceSeries.VolumeData.Select(x => (double) x).ToList();
            volumePrices.Append(priceSeries.TimeData, volumeValues);

            RenderableSeries.Add(new FastColumnRenderableSeries()
            {
                DataSeries = volumePrices
            });

            Annotations.Add(new AxisMarkerAnnotation()
            {
                Y1 = volumeValues.Last()
            });
        }
    }
}