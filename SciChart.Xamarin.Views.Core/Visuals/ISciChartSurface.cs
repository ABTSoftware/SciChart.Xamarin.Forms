using SciChart.Xamarin.Views.Model.ObservableCollection;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface : INativeViewProvider
    {
        AxisCollection XAxes { get; set; }
        AxisCollection YAxes { get; set; }
        RenderableSeriesCollection RenderableSeries { get; set; }
        AnnotationCollection Annotations { get; set; }
        ChartModifierCollection ChartModifiers { get; set; }
    }
}