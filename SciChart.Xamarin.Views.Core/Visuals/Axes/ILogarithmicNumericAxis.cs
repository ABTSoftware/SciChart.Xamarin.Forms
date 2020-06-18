using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [ClassDeclaration("LogarithmicNumericAxis", typeof(INumericAxis))]
    [InjectNativeSciChartObject]
    public interface ILogarithmicNumericAxis : INumericAxis
    {
        [BindablePropertyDefinition()]
        double LogarithmicBase { get; set; }
    }
}