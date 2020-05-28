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

        public static SciChart.Drawing.Common.BrushStyle BrushStyleFromXamarin(this SciChart.Xamarin.Views.Drawing.IBrushStyle brushStyle)
        {
            return brushStyle.NativeSciChartObject as BrushStyle;
        }

        public static SciChart.Xamarin.Views.Drawing.IBrushStyle BrushStyleToXamarin(this SciChart.Drawing.Common.BrushStyle brushStyle)
        {
            if (brushStyle is SolidBrushStyleAndroid solidBrushStyle)
                return new SciChart.Xamarin.Views.Drawing.SolidBrushStyle(solidBrushStyle);

            if (brushStyle is LinearGradientBrushStyleAndroid linearGradientBrushStyle)
                return new SciChart.Xamarin.Views.Drawing.LinearGradientBrushStyle(linearGradientBrushStyle);

            return null;
        }
    }
}