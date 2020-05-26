using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    internal static class AxisHelper
    {
        internal static AxisAlignment AlignmentToXamarin(this SCIAxisAlignment iosAxisAlignment)
        {
            if (iosAxisAlignment == SCIAxisAlignment.Left) return AxisAlignment.Left;
            if (iosAxisAlignment == SCIAxisAlignment.Bottom) return AxisAlignment.Bottom;
            if (iosAxisAlignment == SCIAxisAlignment.Right) return AxisAlignment.Right;
            if (iosAxisAlignment == SCIAxisAlignment.Top) return AxisAlignment.Top;
            if (iosAxisAlignment == SCIAxisAlignment.Auto) return AxisAlignment.Default;

            throw new NotImplementedException("The AxisAlignment " + iosAxisAlignment.ToString() +
                                              " has not been handled");
        }

        internal static SCIAxisAlignment AlignmentFromXamarin(this AxisAlignment xfAxisAlignment)
        {
            switch (xfAxisAlignment)
            {
                case AxisAlignment.Left: return SCIAxisAlignment.Left;
                case AxisAlignment.Bottom: return SCIAxisAlignment.Bottom;
                case AxisAlignment.Right: return SCIAxisAlignment.Right;
                case AxisAlignment.Top: return SCIAxisAlignment.Top;
                case AxisAlignment.Default: return SCIAxisAlignment.Auto;
                default:
                    throw new NotImplementedException("The AxisAlignment " + xfAxisAlignment.ToString() +
                                                      " has not been handled");
            }
        }

        public static AutoRange AutoRangeToXamarin(this SCIAutoRange autoRange)
        {
            switch (autoRange)
            {
                case SCIAutoRange.Once: return AutoRange.Once;
                case SCIAutoRange.Always: return AutoRange.Always;
                case SCIAutoRange.Never: return AutoRange.Never;
                default: throw new NotImplementedException("The AutoRange value " + autoRange.ToString() + " has not been handled");
            }
        }

        public static SCIAutoRange AutoRangeFromXamarin(this AutoRange autoRange)
        {
            switch (autoRange)
            {
                case AutoRange.Always: return SCIAutoRange.Always;
                case AutoRange.Once: return SCIAutoRange.Once;
                case AutoRange.Never: return SCIAutoRange.Never;
                default:
                    throw new NotImplementedException("The AutoRange value " + autoRange.ToString() + " has not been handled");
            }
        }

        public static SciChart.Xamarin.Views.Model.RangeClipMode RangeClipModeToXamarin(this SCIRangeClipMode rangeClipMode)
        {
            switch (rangeClipMode)
            {
                case SCIRangeClipMode.MinMax: return Views.Model.RangeClipMode.MinMax;
                case SCIRangeClipMode.Max: return Views.Model.RangeClipMode.Max;
                case SCIRangeClipMode.Min: return Views.Model.RangeClipMode.Min;
                default:
                    throw new NotImplementedException("The RangeClipMode value " + rangeClipMode.ToString() + " has not been handled");
            }
        }

        public static SCIRangeClipMode RangeClipModeFromXamarin(this SciChart.Xamarin.Views.Model.RangeClipMode rangeClipMode)
        {
            switch (rangeClipMode)
            {
                case SciChart.Xamarin.Views.Model.RangeClipMode.MinMax: return SCIRangeClipMode.MinMax;
                case SciChart.Xamarin.Views.Model.RangeClipMode.Min: return SCIRangeClipMode.Min;
                case SciChart.Xamarin.Views.Model.RangeClipMode.Max: return SCIRangeClipMode.Max;
                default:
                    throw new NotImplementedException("The RangeClipMode value " + rangeClipMode.ToString() + " has not been handled");
            }
        }
    }
}