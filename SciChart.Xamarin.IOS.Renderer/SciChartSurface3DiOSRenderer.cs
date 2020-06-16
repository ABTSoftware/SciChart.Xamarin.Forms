using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SciChartSurface3D), typeof(SciChartSurface3DiOSRenderer))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurface3DiOSRenderer : ViewRendererBase<SciChartSurface3D, SCIChartSurface3D>
    {

        public SciChartSurface3DiOSRenderer() : base(new SciChartSurface3DiOSPropertyMapper())
        {
        }

        protected override SCIChartSurface3D CreateNativeControl()
        {
            return new SCIChartSurface3D()
            {
                TranslatesAutoresizingMaskIntoConstraints = true
            };
        }
    }
}