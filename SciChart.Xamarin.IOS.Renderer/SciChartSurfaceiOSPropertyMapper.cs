using System.Collections.Generic;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceiOSPropertyMapper : PropertyMapper<SciChartSurfaceX, SCIChartSurface>
    {
        public SciChartSurfaceiOSPropertyMapper()
        {
            AddMapping(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            AddMapping(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            AddMapping(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            AddMapping(SciChartSurfaceX.AnnotationsProperty.PropertyName, OnAnnotationsChanged);
            AddMapping(SciChartSurfaceX.ChartModifiersProperty.PropertyName, OnChartModifiersChanged);
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.RenderableSeries = (SCIRenderableSeriesCollection) source.RenderableSeries.NativeObservableCollection;
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            if (source.XAxes != null) target.XAxes = (SCIAxisCollection)source.XAxes?.NativeObservableCollection;
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.YAxes = (SCIAxisCollection) source.YAxes?.NativeObservableCollection;
        }

        private void OnChartModifiersChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.ChartModifiers = source.ChartModifiers?.NativeObservableCollection as SCIChartModifierCollection;
        }

        private void OnAnnotationsChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.Annotations = source.Annotations?.NativeObservableCollection as SCIAnnotationCollection;
        }

    }
}