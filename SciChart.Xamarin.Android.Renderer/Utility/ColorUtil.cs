using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class ColorUtil
    {
        private const double OneOver255 = 1.0 / 255.0;

        public static Color ColorToXamarin(this int color)
        {
            var androidColor = new global::Android.Graphics.Color(color);
            return new Color(androidColor.R * OneOver255, androidColor.G * OneOver255, androidColor.B * OneOver255,
                androidColor.A * OneOver255);
        }

        public static int ColorFromXamarin(this Color color)
        {
            return color.ToAndroid().ToArgb();
        }
    }
}