using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Utility.Converters
{
    public class FontStyleConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            var items = value.Split(',');

            var color = string.IsNullOrEmpty(items[0]) ? Color.Black : items[0].ToColor();
            var textSize = string.IsNullOrEmpty(items[1]) ? 1f : float.Parse(items[1]);

            return new FontStyle(textSize, color);
        }
    }
}