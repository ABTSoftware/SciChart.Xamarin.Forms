using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Tests.Stubs
{
    class StubRenderableSeries : IRenderableSeries
    {
        public Color Stroke { get; set; }
        public float StrokeThickness { get; set; }
        public IDataSeries DataSeries { get; set; }
        public string YAxisId { get; set; }
        public string XAxisId { get; set; }
        public object BindingContext { get; set; }
        public INativeSciChartObject NativeSciChartObject { get; set; }
    }
}
