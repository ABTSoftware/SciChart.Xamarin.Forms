using Android.Content;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer;
using Xamarin.Forms;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidRenderer : ViewRendererBase<SciChartSurfaceX, SciChartSurface>
    {
        public SciChartSurfaceAndroidRenderer(Context context) : base(context, new SciChartSurfaceAndroidPropertyMapper()) 
        {

        }

        protected override SciChartSurface CreateNativeControl()
        {
            return new SciChartSurface(Context);
        }
    }
}
