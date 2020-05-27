using SciChart.iOS.Charting;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class StyleUtil
    {
        public static SCIPenStyle PenStyleFromXamarin(this SciChart.Xamarin.Views.Drawing.IPenStyle penStyle)
        {
            return penStyle.NativeSciChartObject as SCIPenStyle;
        }

        public static SciChart.Xamarin.Views.Drawing.IPenStyle PenStyleToXamarin(this SCIPenStyle penStyle)
        {
            if (penStyle is SolidPenStyleiOS solidPenStyle)
                return new SciChart.Xamarin.Views.Drawing.SolidPenStyle(solidPenStyle);

            return null;
        }
    }
}