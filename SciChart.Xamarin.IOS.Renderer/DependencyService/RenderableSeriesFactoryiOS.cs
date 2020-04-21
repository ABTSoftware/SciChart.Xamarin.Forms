using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class RenderableSeriesFactoryiOS : IRenderableSeriesFactory
    {
        public INativeRenderableSeries NewLineSeries()
        {
            return new FastLineRenderableSeriesiOS();
        }
    }
}