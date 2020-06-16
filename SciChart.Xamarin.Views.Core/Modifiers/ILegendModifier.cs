using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [InjectAndroidContext]
    [ClassDeclaration("LegendModifier", typeof(IChartModifier))]
    [InjectNativeSciChartObject]
    public interface ILegendModifier : IChartModifier
    {
        [MethodDeclaration()]
        void SetShowLegend(bool showLegend);

        [MethodDeclaration()]
        void SetShowCheckboxes(bool showCheckboxes);

        [MethodDeclaration()]
        void SetShowSeriesMarkers(bool showSeriesMarkers);

        [MethodDeclaration()]
        void SetSourceMode(SourceMode sourceMode);
    }
}