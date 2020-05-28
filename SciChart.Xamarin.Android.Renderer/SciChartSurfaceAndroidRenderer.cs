using Android.Content;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceAndroidRenderer))]

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidRenderer : ViewRenderer<SciChartSurfaceX, SciChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SciChartSurface> _propertyMapper;

        public SciChartSurfaceAndroidRenderer(Context context) : base(context) 
        {

        }        

        protected override void OnElementChanged(ElementChangedEventArgs<Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control 
                this.SetNativeControl(new SciChartSurface(Context));

                // Setup the property mapper 
                _propertyMapper = new SciChartSurfaceAndroidPropertyMapper(e.NewElement, Control);                                        
            }

            base.OnElementChanged(e);
        }        
    }
}
