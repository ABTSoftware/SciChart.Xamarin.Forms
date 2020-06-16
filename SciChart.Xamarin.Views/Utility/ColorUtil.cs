using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Utility
{
    public static class ColorUtil
    {
        internal static Color ToColor(this string value)
        {
            // hex color
            if (value.StartsWith("#"))
            {
                return Color.FromHex(value);
            }

            return System.Drawing.Color.FromName(value);
        }
    }
}