using System.Linq;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms.Platform.iOS;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class RenderableSeriesHelpers
    {
        public static IColorMap ColorMapToXamarin(this SCIColorMap colorMap)
        {
            return colorMap != null
                ? new Views.Visuals.RenderableSeries.ColorMap(colorMap.Colors.Select(x => x.ToColor()).ToArray(), colorMap.Stops.Select(x => x.FloatValue).ToArray())
                : null;
        }

        public static SCIColorMap ColorMapFromXamarin(this IColorMap colorMap)
        {
            return colorMap?.NativeSciChartObject as SCIColorMap;
        }
    }
}