using Android.Content;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SciChartSurface3D), typeof(SciChartSurface3DAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurface3DAndroidRenderer : ViewRendererBase<SciChartSurface3D, Charting3D.Visuals.SciChartSurface3D>
    {
        public SciChartSurface3DAndroidRenderer(Context context) : base(context, new SciChartSurface3DAndroidPropertyMapper())
        {

        }

        protected override Charting3D.Visuals.SciChartSurface3D CreateNativeControl()
        {
            return new Charting3D.Visuals.SciChartSurface3D(Context);
        }
    }
}