using SciChart.iOS.Charting;
using UIKit;
using Xamarin.Forms;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class ColorUtil
    {
        public static UIColor ColorFromXamarin(this Color xfColor)
        {
            UIKit.UIColor uiColor = UIColor.FromRGBA(
                (byte)(xfColor.R * 255),
                (byte)(xfColor.G * 255),
                (byte)(xfColor.B * 255),
                (byte)(xfColor.A * 255));

            return uiColor;
        }

        private static Color ColorToXamarin(this UIColor color)
        {
            System.nfloat r, g, b, a;
            color.GetRGBA(out r, out g, out b, out a);
            return new Color(r, g, b, a);
        }

        public static uint ColorFromXamarin(this System.Drawing.Color color)
        {
            return (uint) color.ToArgb();
        }

        private static System.Drawing.Color ColorToXamarin(this uint color)
        {
            return System.Drawing.Color.FromArgb((int) color);
        }

        public static Color BrushStyleToXamarin(this SCIBrushStyle sciBrush)
        {
            return ColorToXamarin(sciBrush.Color);
        }        

        public static SCIBrushStyle BrushStyleFromXamarin(this Color value)
        {
            return new SCISolidBrushStyle(ColorFromXamarin(value));
        }
    }
}