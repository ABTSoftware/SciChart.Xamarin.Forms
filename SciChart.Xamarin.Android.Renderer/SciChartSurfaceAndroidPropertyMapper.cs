using SciChart.Charting.Model;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceAndroidPropertyMapper()
        {
            AddMapping(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            AddMapping(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            AddMapping(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            AddMapping(SciChartSurfaceX.AnnotationsProperty.PropertyName, OnAnnotationsChanged);
            AddMapping(SciChartSurfaceX.ChartModifiersProperty.PropertyName, OnChartModifiersChanged);
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.RenderableSeries = source.RenderableSeries?.NativeObservableCollection as RenderableSeriesCollection;
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.XAxes = source.XAxes?.NativeObservableCollection as AxisCollection;
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.YAxes = source.YAxes?.NativeObservableCollection as AxisCollection;
        }

        private void OnChartModifiersChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.ChartModifiers = source.ChartModifiers?.NativeObservableCollection as ChartModifierCollection;
        }

        private void OnAnnotationsChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.Annotations = source.Annotations?.NativeObservableCollection as AnnotationCollection;
        }

    }
}