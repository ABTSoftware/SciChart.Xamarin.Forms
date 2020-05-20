using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines the base interface to a Range (Min, Max), used throughout SciChart for visible, data and index range calculations
    /// </summary>
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("RangeBase")]
    public interface IRange : INativeSciChartObjectWrapper 
    {
        /// <summary>
        /// Gets the double representation of min value
        /// </summary>
        double MinAsDouble { get; }

        /// <summary>
        /// Gets the double representation of max value
        /// </summary>
        double MaxAsDouble { get; }
    }

    [ClassDeclaration("DoubleRange", "SCIDoubleRange", typeof(IRange))]
    public interface IDoubleRange : IRange
    {
        double Min { get; set; }
        double Max { get; set; }
    }
}