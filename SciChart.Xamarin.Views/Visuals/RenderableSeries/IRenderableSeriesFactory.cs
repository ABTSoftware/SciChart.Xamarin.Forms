using SciChart.Xamarin.Views.Core;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public interface IRenderableSeriesFactory
    {
        INativeRenderableSeries NewLineSeries();
    }
}