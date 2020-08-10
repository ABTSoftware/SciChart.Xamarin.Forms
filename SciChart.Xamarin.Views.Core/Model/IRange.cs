using System.ComponentModel;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines the base interface to a Range (Min, Max), used throughout SciChart for visible, data and index range calculations
    /// </summary>
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("RangeBase")]
    [ClassDeclaration("RangeBase", null)]
    [InjectInitMethod]
    public interface IRange : INativeSciChartObjectWrapper, INotifyPropertyChanged 
    {
        /// <summary>
        /// Gets the double representation of min value
        /// </summary>
        [PropertyDeclaration]
        double MinAsDouble { get; }

        /// <summary>
        /// Gets the double representation of max value
        /// </summary>
        [PropertyDeclaration]
        double MaxAsDouble { get; }

        [MethodDeclaration]
        void SetMinMaxDouble(double min, double max);
    }

    [ClassDeclaration("DoubleRange", typeof(IRange))]
    [InjectNativeSciChartObject]
    [InjectNativeSciChartObject(new []{"min", "max"}, new []{typeof(double), typeof(double)})]
    public interface IDoubleRange : IRange
    {
        double Min { get; set; }
        double Max { get; set; }
    }
}