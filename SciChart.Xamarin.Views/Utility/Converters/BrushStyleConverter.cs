using System.Linq;
using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Utility.Converters
{
    public class BrushStyleConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            return new SolidBrushStyle(value.ToColor());
        }
    }
}