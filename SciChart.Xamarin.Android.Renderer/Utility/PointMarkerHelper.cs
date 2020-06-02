using SciChart.Charting.Visuals.PointMarkers;
using SciChart.Xamarin.Views.Visuals.PointMarkers3D;
using BasePointMarker3D = SciChart.Charting3D.Visuals.PointMarkers.BasePointMarker3D;


namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class PointMarkerHelper
    {
        public static IPointMarker3D PointMarker3DToXamarin(this BasePointMarker3D pointMarker)
        {
            return null;
        }

        public static BasePointMarker3D PointMarker3DFromXamarin(this IPointMarker3D pointMarker)
        {
            return pointMarker.NativeSciChartObject as BasePointMarker3D;
        }

        public static SciChart.Xamarin.Views.Visuals.PointMarkers.IPointMarker PointMarkerToXamarin(this IPointMarker pointMarker)
        {
            return null;
        }

        public static IPointMarker PointMarkerFromXamarin(this SciChart.Xamarin.Views.Visuals.PointMarkers.IPointMarker pointMarker)
        {
            return pointMarker.NativeSciChartObject as IPointMarker;
        }
    }
}