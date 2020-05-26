using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model
{


    /// <summary>
    /// Defines a range of type <see cref="System.Double"/>
    /// </summary>
    public partial class DoubleRange : RangeBase, IDoubleRange
    {
        public DoubleRange(IRange nativeRange) : base(nativeRange)
        {
        }

        public double Min
        {
            get => ((IDoubleRange)NativeRange).Min;
            set => ((IDoubleRange)NativeRange).Min = value;
        }

        public double Max
        {
            get => ((IDoubleRange)NativeRange).Max;
            set => ((IDoubleRange)NativeRange).Max = value;
        }
    }
}
