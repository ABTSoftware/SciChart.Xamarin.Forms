using SciChart.Core.Utility;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class ComparableUtil
    {
        public static System.IComparable ComparableToXamarin(this Java.Lang.IComparable comparable)
        {
            return comparable.ToComparable();
        }

        public static Java.Lang.IComparable ComparableFromXamarin(this System.IComparable comparable)
        {
            return comparable.FromComparable();
        }

        public static uint UIntToXamarin(this int value)
        {
            return (uint) value;
        }

        public static int UIntFromXamarin(this uint value)
        {
            return (int) value;
        }
    }
}