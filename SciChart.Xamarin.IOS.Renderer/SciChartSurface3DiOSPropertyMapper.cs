using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using SciChart.Xamarin.Views.Visuals.Axes3D;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurface3DiOSPropertyMapper : PropertyMapper<SciChartSurface3D, SCIChartSurface3D>
    {
        public SciChartSurface3DiOSPropertyMapper(SciChartSurface3D sourceControl, SCIChartSurface3D targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurface3D.XAxisProperty.PropertyName, OnXAxisChanged);
            this.Add(SciChartSurface3D.YAxisProperty.PropertyName, OnYAxisChanged);
            this.Add(SciChartSurface3D.ZAxisProperty.PropertyName, OnZAxisChanged);
            this.Init();
        }

        private void OnXAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.XAxis = source.XAxis.NativeSciChartObject as IISCIAxis3D;
        }

        private void OnYAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.YAxis = source.YAxis.NativeSciChartObject as IISCIAxis3D;
        }

        private void OnZAxisChanged(SciChartSurface3D source, SCIChartSurface3D target)
        {
            target.ZAxis = source.ZAxis.NativeSciChartObject as IISCIAxis3D;
        }
    }
}