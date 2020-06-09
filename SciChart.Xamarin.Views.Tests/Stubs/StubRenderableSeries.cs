using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.PointMarkers;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Tests.Stubs
{
    class StubRenderableSeries : IRenderableSeries
    {
        public IDataSeries DataSeries { get; set; }
        public string YAxisId { get; set; }
        public string XAxisId { get; set; }
        public IPenStyle StrokeStyle { get; set; }
        public IPointMarker PointMarker { get; set; }
        public object BindingContext { get; set; }
        public INativeSciChartObject NativeSciChartObject { get; set; }
    }
}
