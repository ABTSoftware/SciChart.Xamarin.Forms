using System.ComponentModel;
using System.Runtime.CompilerServices;
using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Model
{
    public abstract partial class RangeBase : IRange
    {
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => NativeSciChartObject.CastSciChartObject<IRange>().PropertyChanged += value;
            remove => NativeSciChartObject.CastSciChartObject<IRange>().PropertyChanged -= value;
        }
    }
}