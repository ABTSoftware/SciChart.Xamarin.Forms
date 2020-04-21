using System;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class RenderableSeriesFactoryAndroid : IRenderableSeriesFactory
    {
        public INativeRenderableSeries NewLineSeries()
        {
            return new FastLineRenderableSeriesAndroid();
        }
    }
}