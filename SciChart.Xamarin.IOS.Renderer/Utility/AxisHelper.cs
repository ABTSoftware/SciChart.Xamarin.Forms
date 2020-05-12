using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Model;
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
            throw new NotImplementedException();
        }

        public static SCIAutoRange AutoRangeFromXamarin(this AutoRange value)
        {
            throw new NotImplementedException();
        }
    }
}