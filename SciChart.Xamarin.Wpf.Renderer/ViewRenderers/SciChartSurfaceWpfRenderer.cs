﻿using System.ComponentModel;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Data.Model;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Utility;
using Xamarin.Forms.Platform.WPF;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Wpf.Renderer.ViewRenderers
{
    public class SciChartSurfaceWpfRenderer : ViewRenderer<SciChartSurfaceX, SciChart.Charting.Visuals.SciChartSurface>
    {
        private static string _license;

        private PropertyMapper<SciChartSurfaceX, SciChartSurface> _propertyMapper;

        public SciChartSurfaceWpfRenderer()
        {
            // Apply license 
            if (_license == null)
            {
                _license = SciChartLicenseManager.GetLicense(SciChartPlatform.Wpf);
                if (_license != null)
                {
                    SciChartSurface.SetRuntimeLicenseKey(_license);
                }
            }            
        }                

        protected override void OnElementChanged(ElementChangedEventArgs<SciChart.Xamarin.Views.Visuals.SciChartSurface> e)
        {                        
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Create the native control 
                this.SetNativeControl(new SciChartSurface());

                // Setup property mapper 
                _propertyMapper = new SciChartSurfaceWpfPropertyMapper(e.NewElement, Control);                
            }
        }        
    }
}

