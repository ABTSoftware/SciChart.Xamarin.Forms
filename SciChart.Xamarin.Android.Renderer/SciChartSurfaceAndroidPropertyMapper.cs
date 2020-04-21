using SciChart.Charting.Model;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceAndroidPropertyMapper(SciChartSurfaceX sourceControl, Charting.Visuals.SciChartSurface targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            this.Init();
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.RenderableSeries = source.RenderableSeries.NativeObservableCollection as RenderableSeriesCollection;
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.XAxes = source.XAxes.NativeObservableCollection as AxisCollection;
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            target.YAxes = source.YAxes.NativeObservableCollection as AxisCollection;
        }
    }
}