using System.Linq;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using ColorMap = SciChart.Charting.Visuals.RenderableSeries.ColorMap;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class RenderableSeriesHelpers
    {
        public static IColorMap ColorMapToXamarin(this ColorMap colorMap)
        {
            return colorMap != null
                ? new Views.Visuals.RenderableSeries.ColorMap(colorMap.Colors.Select(x => x.ColorToXamarin()).ToArray(), colorMap.Stops.ToArray())
                : null;
        }

        public static ColorMap ColorMapFromXamarin(this IColorMap colorMap)
        {
            return colorMap?.NativeSciChartObject as ColorMap;
        }
    }
}