using SciChart.Xamarin.Views.Core;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class AxisBase : AxisCore, IAxis
    {
        protected AxisBase(INativeAxis nativeAxis)
        {
            NativeAxis = nativeAxis;
        }

        public INativeAxis NativeAxis { get; }
    }
}