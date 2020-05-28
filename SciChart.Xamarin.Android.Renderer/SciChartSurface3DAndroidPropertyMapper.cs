using SciChart.Charting3D.Visuals.Axes;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurface3DAndroidPropertyMapper : PropertyMapper<SciChartSurface3D, Charting3D.Visuals.SciChartSurface3D>
    {
        public SciChartSurface3DAndroidPropertyMapper(SciChartSurface3D sourceControl, Charting3D.Visuals.SciChartSurface3D targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurface3D.XAxisProperty.PropertyName, OnXAxisChanged);
            this.Add(SciChartSurface3D.YAxisProperty.PropertyName, OnYAxisChanged);
            this.Add(SciChartSurface3D.ZAxisProperty.PropertyName, OnZAxisChanged);
            this.Init();
        }

        private void OnXAxisChanged(SciChartSurface3D source, Charting3D.Visuals.SciChartSurface3D target)
        {
            target.XAxis = source.XAxis.NativeSciChartObject as IAxis3D;
        }

        private void OnYAxisChanged(SciChartSurface3D source, Charting3D.Visuals.SciChartSurface3D target)
        {
            target.YAxis = source.YAxis.NativeSciChartObject as IAxis3D;
        }

        private void OnZAxisChanged(SciChartSurface3D source, Charting3D.Visuals.SciChartSurface3D target)
        {
            target.ZAxis = source.ZAxis.NativeSciChartObject as IAxis3D;
        }
    }
}