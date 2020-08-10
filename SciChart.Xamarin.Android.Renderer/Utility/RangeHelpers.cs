using System;
using SciChart.Xamarin.Views.Model;
using IRange = SciChart.Data.Model.IRange;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class RangeHelpers
    {
        /// <summary>
        /// Property used by IRange
        /// </summary>
        public const int Max = 1;
        public const int Min = 2;
        public const int MinMax = Min & Max;

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