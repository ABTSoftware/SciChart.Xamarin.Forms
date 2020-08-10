using System;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public abstract partial class AxisCore
    {
        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged
        {
            add => NativeSciChartObject.CastSciChartObject<IAxisCore>().VisibleRangeChanged += value;
            remove => NativeSciChartObject.CastSciChartObject<IAxisCore>().VisibleRangeChanged -= value;
        }
    }
}