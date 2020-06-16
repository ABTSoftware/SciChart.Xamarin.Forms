using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Utility.Converters
{
    public class PenStyleConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            var items = value.Split(',');

            var color = string.IsNullOrEmpty(items[0]) ? Color.Black : items[0].ToColor();
            var thickness = string.IsNullOrEmpty(items[1]) ? 1f : float.Parse(items[1]);

            return new SolidPenStyle(color, thickness, false, null);
        }
    }
}