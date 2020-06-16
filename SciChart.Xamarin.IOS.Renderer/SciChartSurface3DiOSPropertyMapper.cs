using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurface3DiOSPropertyMapper : PropertyMapper<SciChartSurface3D, SCIChartSurface3D>
    {
        public SciChartSurface3DiOSPropertyMapper()
        {
            AddMapping(SciChartSurface3D.XAxisProperty.PropertyName, OnXAxisChanged);
            AddMapping(SciChartSurface3D.YAxisProperty.PropertyName, OnYAxisChanged);
            AddMapping(SciChartSurface3D.ZAxisProperty.PropertyName, OnZAxisChanged);
            AddMapping(SciChartSurface3D.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            AddMapping(SciChartSurface3D.ChartModifiersProperty.PropertyName, OnChartModifiersChanged);
        }

        private void OnXAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.XAxis = source.XAxis?.NativeSciChartObject as IISCIAxis3D;
        }

        private void OnYAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.YAxis = source.YAxis?.NativeSciChartObject as IISCIAxis3D;
        }

        private void OnZAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.ZAxis = source.ZAxis?.NativeSciChartObject as IISCIAxis3D;
        }

        private void OnRenderableSeriesChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.RenderableSeries = (SCIRenderableSeries3DCollection)source.RenderableSeries?.NativeObservableCollection;
        }

        private void OnChartModifiersChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.ChartModifiers = source.ChartModifiers?.NativeObservableCollection as SCIChartModifier3DCollection;
        }
    }
}