using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using Xamarin.Forms;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceIosRenderer))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceIosRenderer : ViewRendererBase<SciChartSurfaceX, SCIChartSurface>
    {

        public SciChartSurfaceIosRenderer() : base(new SciChartSurfaceiOSPropertyMapper())
        {
        }

        protected override SCIChartSurface CreateNativeControl()
        {
            return new SCIChartSurface()
            {
                TranslatesAutoresizingMaskIntoConstraints = true
            }; 
        }
    }
}
