using System;
using SciChart.Xamarin.Views.Model;
using IRange = SciChart.Data.Model.IRange;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class RangeHelpers
    {
        public static IRange RangeFromXamarin(this Views.Model.IRange range)
        {
            return range.NativeSciChartObject as IRange;
        }

        public static Views.Model.IRange RangeToXamarin(this IRange range)
        {
            switch (range)
            {
                case DoubleRangeAndroid doubleRange:
                    return new DoubleRange(doubleRange);


                default:
                    return null;
            }
        }
    }
}