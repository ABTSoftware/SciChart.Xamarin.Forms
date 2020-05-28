using Android.Content;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SciChartSurface3D), typeof(SciChartSurface3DAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurface3DAndroidRenderer : ViewRenderer<SciChartSurface3D, Charting3D.Visuals.SciChartSurface3D>
    {
        private PropertyMapper<SciChartSurface3D, Charting3D.Visuals.SciChartSurface3D> _propertyMapper;

        public SciChartSurface3DAndroidRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface3D> e)
        {
            if (Control == null)
            {
                // Create the native control 
                this.SetNativeControl(new Charting3D.Visuals.SciChartSurface3D(Context));

                // Setup the property mapper 
                _propertyMapper = new SciChartSurface3DAndroidPropertyMapper(e.NewElement, Control);
            }

            base.OnElementChanged(e);
        }
    }
}