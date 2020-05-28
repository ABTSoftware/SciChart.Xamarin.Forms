using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.Views.Utility;
using SciChart.Xamarin.Views.Visuals;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SciChartSurface3D), typeof(SciChartSurface3DiOSRenderer))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurface3DiOSRenderer : ViewRenderer<SciChartSurface3D, SCIChartSurface3D>
    {
        private PropertyMapper<SciChartSurface3D, SCIChartSurface3D> _propertyMapper;

        // Note Crashes before any breakpoints hit 
        protected override void OnElementChanged(ElementChangedEventArgs<SciChartSurface3D> e)
        {
            if (Control == null)
            {
                // Create the native control
                this.SetNativeControl(new SCIChartSurface3D());

                Control.TranslatesAutoresizingMaskIntoConstraints = true;

                // Set property mapper
                _propertyMapper = new SciChartSurface3DiOSPropertyMapper(e.NewElement, Control);
            }

            base.OnElementChanged(e);
        }
    }
}