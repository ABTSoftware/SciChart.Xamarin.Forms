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

        public DoubleRange() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewDoubleRange())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleRange"/> class.
        /// </summary>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <remarks></remarks>
        public DoubleRange(double min, double max) : base(DependencyService.Get<INativeSciChartObjectFactory>().NewDoubleRange(min, max)) 
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
