using System;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public abstract partial class AxisCore : View, IAxisCore, IBindingContextProvider
    {

        protected AxisCore(IAxisCore nativeAxis)
        {
            _nativeSciChartObject = nativeAxis.NativeSciChartObject;
        }

        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }
}