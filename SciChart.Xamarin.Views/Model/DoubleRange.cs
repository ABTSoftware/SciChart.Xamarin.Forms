using System;
using System.Collections.Generic;
using System.Text;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model
{
    public interface IDoubleRange : IRange
    {
        double Min { get; set; }
        double Max { get; set; }
    }

    /// <summary>
    /// Defines a range of type <see cref="System.Double"/>
    /// </summary>
    [ClassDeclaration(typeof(IDoubleRange), "DoubleRange", "SCIDoubleRange")]
    public class DoubleRange : RangeBase, IDoubleRange
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

        public IDoubleRange AsDoubleRange()
        {
            return this;
        }
    }
}
