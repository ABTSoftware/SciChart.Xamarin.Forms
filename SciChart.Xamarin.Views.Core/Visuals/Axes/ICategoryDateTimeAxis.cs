using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [ClassDeclaration("CategoryDateAxis", typeof(IAxis))]
    [InjectNativeSciChartObject]
    public interface ICategoryDateTimeAxis : IAxis
    {
        // TODO implement setter in iOS
        // [BindablePropertyDefinition()]
        // double BarTimeFrame { get; set; } 
    }
}