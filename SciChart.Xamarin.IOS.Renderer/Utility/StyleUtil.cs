using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Drawing;

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


        public static SCIBrushStyle BrushStyleFromXamarin(this SciChart.Xamarin.Views.Drawing.IBrushStyle brushStyle)
        {
            return brushStyle.NativeSciChartObject as SCIBrushStyle;
        }

        public static SciChart.Xamarin.Views.Drawing.IBrushStyle BrushStyleToXamarin(this SCIBrushStyle brushStyle)
        {
            if (brushStyle is SolidBrushStyleiOS solidBrushStyle)
                return new SciChart.Xamarin.Views.Drawing.SolidBrushStyle(solidBrushStyle);

            if (brushStyle is LinearGradientBrushStyleiOS linearGradientBrushStyle)
                return new SciChart.Xamarin.Views.Drawing.LinearGradientBrushStyle(linearGradientBrushStyle);

            return null;
        }

        public static SCIFontStyle FontStyleFromXamarin(this SciChart.Xamarin.Views.Drawing.IFontStyle fontStyle)
        {
            return fontStyle.NativeSciChartObject as SCIFontStyle;
        }

        public static SciChart.Xamarin.Views.Drawing.IFontStyle FontStyleToXamarin(this SCIFontStyle fontStyle)
        {
            if(fontStyle is FontStyleiOS fontStyleiOS)
                return new FontStyle(fontStyleiOS);

            return null;
        }
    }
}