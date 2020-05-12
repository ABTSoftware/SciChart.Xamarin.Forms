using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Core;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public abstract class AxisBase : AxisCore, IAxis
    {
        protected AxisBase(IAxis nativeAxis) : base(nativeAxis)
        {
        }
    }
}