using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Model;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class RangeHelpers
    {
        public static IISCIRange RangeFromXamarin(this IRange range)
        {
            return range.NativeSciChartObject as IISCIRange;
        }

        public static IRange RangeToXamarin(this IISCIRange range)
        {
            switch (range)
            {
                case DoubleRangeiOS doubleRange:
                    return new DoubleRange(doubleRange);


                default:
                    return null;
            }
        }
    }
}