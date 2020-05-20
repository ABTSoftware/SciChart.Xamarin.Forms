using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Model
{
    public abstract partial class RangeBase : IRange
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