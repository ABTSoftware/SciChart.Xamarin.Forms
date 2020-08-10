using System;
using System.Globalization;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Utility.Converters
{
    public class StringToAnnotationCoordinateConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            double doubleResult;
            if (double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out doubleResult))
            {
                return doubleResult;
            }

            DateTime dateTimeResult;
            if (DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTimeResult))
            {
                return dateTimeResult;
            }

            return null;
        }
    }
}