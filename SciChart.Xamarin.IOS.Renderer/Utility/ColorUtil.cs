using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Forms;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class ColorUtil
    {
        public static uint ColorFromXamarin(this Color xfColor)
        {
            var a = (byte)(xfColor.A * 255);
            var r = (byte)(xfColor.R * 255);
            var g = (byte)(xfColor.G * 255);
            var b = (byte)(xfColor.B * 255);

            return (uint) (a << 24 | r << 16| g << 8 | b);
        }

        public static Color ColorToXamarin(this uint color)
        {
            return Color.FromUint(color);
        }
    }
}