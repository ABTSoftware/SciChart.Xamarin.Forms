using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [ClassDeclaration("DateAxis", typeof(IAxis))]
    [InjectNativeSciChartObject]
    public interface IDateTimeAxis : IAxis
    {
        [BindablePropertyDefinition()]
        string SubDayTextFormatting { get; set; }
    }
}