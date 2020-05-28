using System;
using SciChart.Drawing.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class ColorUtil
    {
        private const double OneOver255 = 1.0 / 255.0;

        private static Color ColorToXamarin(int color)
        {
            var androidColor = new global::Android.Graphics.Color(color);
            return new Color(androidColor.R * OneOver255, androidColor.G * OneOver255, androidColor.B * OneOver255,
                androidColor.A * OneOver255);
        }        

        public static global::Android.Graphics.Color ColorFromXamarin(Color xfColor)
        {
            return new global::Android.Graphics.Color((byte) (xfColor.R * 255),
                (byte) (xfColor.G * 255),
                (byte) (xfColor.B * 255),
                (byte) (xfColor.A * 255));
        }
    }
}