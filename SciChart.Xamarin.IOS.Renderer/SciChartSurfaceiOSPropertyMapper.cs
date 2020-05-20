using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceiOSPropertyMapper : PropertyMapper<SciChartSurfaceX, SCIChartSurface>
    {
        public SciChartSurfaceiOSPropertyMapper(SciChartSurfaceX sourceControl, SCIChartSurface targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Init();
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.RenderableSeries = (SCIRenderableSeriesCollection) source.RenderableSeries.NativeObservableCollection;
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.XAxes = (SCIAxisCollection) source.XAxes.NativeObservableCollection;
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SCIChartSurface target)
        {
            target.YAxes = (SCIAxisCollection) source.YAxes.NativeObservableCollection;
        }
    }
}