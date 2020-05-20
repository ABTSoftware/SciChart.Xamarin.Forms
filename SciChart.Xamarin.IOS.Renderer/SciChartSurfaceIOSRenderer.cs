using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

[assembly: ExportRenderer(typeof(SciChartSurfaceX), typeof(SciChartSurfaceIosRenderer))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceIosRenderer : ViewRenderer<SciChartSurfaceX, SCIChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SCIChartSurface> _propertyMapper;

        // Note Crashes before any breakpoints hit 
        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {
            if (Control == null)
            {
                // Create the native control
                this.SetNativeControl(new SCIChartSurface());

                Control.TranslatesAutoresizingMaskIntoConstraints = true;

                // Set property mapper
                _propertyMapper = new SciChartSurfaceiOSPropertyMapper(e.NewElement, Control);                                
            }

            base.OnElementChanged(e);
        }        
    }
}
