using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Visuals.PointMarkers;
using SciChart.Xamarin.Views.Visuals.PointMarkers3D;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class PointMarkerHelper
    {
        public static IPointMarker3D PointMarker3DToXamarin(this SCIBasePointMarker3D pointMarker)
        {
            return null;
        }

        public static SCIBasePointMarker3D PointMarker3DFromXamarin(this IPointMarker3D pointMarker)
        {
            return pointMarker.NativeSciChartObject as SCIBasePointMarker3D;
        }

        public static IPointMarker PointMarkerToXamarin(this IISCIPointMarker pointMarker)
        {
            return null;
        }

        public static IISCIPointMarker PointMarkerFromXamarin(this IPointMarker pointMarker)
        {
            return pointMarker.NativeSciChartObject as IISCIPointMarker;
        }
    }
}