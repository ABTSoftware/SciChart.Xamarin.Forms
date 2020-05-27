using SciChart.Drawing.Common;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class StyleUtil
    {
        public static SciChart.Drawing.Common.PenStyle PenStyleFromXamarin(this SciChart.Xamarin.Views.Drawing.IPenStyle penStyle)
        {
            return penStyle.NativeSciChartObject as PenStyle;
        }

        public static SciChart.Xamarin.Views.Drawing.IPenStyle PenStyleToXamarin(this SciChart.Drawing.Common.PenStyle penStyle)
        {
            if(penStyle is SolidPenStyleAndroid solidPenStyle)
                return new SciChart.Xamarin.Views.Drawing.SolidPenStyle(solidPenStyle);

            return null;
        }
    }
}