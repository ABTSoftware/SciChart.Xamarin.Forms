using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model;
using Xamarin.Forms;
using static System.Double;

namespace SciChart.Xamarin.Views.Utility.Converters
{
    public class DoubleRangeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            var split = value.Split(',');

            if (split.Length == 2 && TryParse(split[0], out var min) && TryParse(split[1], out var max))
            {
                return new DoubleRange(min, max);
            }

            return null;
        }
    }
}