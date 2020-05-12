using System;
using SciChart.Xamarin.Views.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model
{
    public abstract class RangeBase : IRange
    {
        protected RangeBase(IRange nativeRange)
        {
            NativeRange = nativeRange;
        }

        public IRange NativeRange { get; protected set; }
        public double MinAsDouble => NativeRange.MinAsDouble;
        public double MaxAsDouble => NativeRange.MaxAsDouble;
        public INativeSciChartObject NativeSciChartObject => NativeRange.NativeSciChartObject;
    }
}