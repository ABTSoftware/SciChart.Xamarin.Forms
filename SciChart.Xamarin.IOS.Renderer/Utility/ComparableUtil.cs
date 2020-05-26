using SciChart.iOS.Charting;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class ComparableUtil
    {
        public static System.IComparable ComparableToXamarin(this SciChart.iOS.Charting.IISCIComparable comparable)
        {
            return comparable.ToComparable();
        }

        public static SciChart.iOS.Charting.IISCIComparable ComparableFromXamarin(this System.IComparable comparable)
        {
            return comparable.FromComparable();
        }

        public static uint UIntToXamarin(this uint value)
        {
            return value;
        }

        public static uint UIntFromXamarin(this uint value)
        {
            return value;
        }
    }
}