using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views
{
    internal static class Extensions
    {
        internal static void ForEachDo<T>(this IEnumerable<T> list, Action<T> operation)
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    operation(item);
                }
            }
        }

        internal static T Cast<T>(this object target) where T : class
        {
            if (target is T tTarget)
            {
                return tTarget;
            }

            throw new InvalidCastException($"Target of type {target.GetType()} can't be cast to {typeof(T)}");
        }
    }

   
}
