﻿using System.ComponentModel;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.iOS.Renderer
{
    public class SciChartSurfaceIosRenderer : ViewRenderer<SciChartSurfaceX, SCIChartSurface>
    {
        private PropertyMapper<SciChartSurfaceX, SCIChartSurface> _propertyMapper;
        private readonly string _license;

        public SciChartSurfaceIosRenderer()
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.iOS);
                if (_license != null)
                {
                    SCIChartSurface.SetRuntimeLicenseKey(_license);
                }
            }
        }

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
