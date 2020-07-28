using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Visuals.Synchronization
{
    [ClassDeclaration("SciChartVerticalGroup", "SCIChartVerticalGroup", null)]
    [InjectNativeSciChartObject]
    public interface ISciChartVerticalGroup : INativeSciChartObjectWrapper
    {
        [MethodDeclaration]
        void AddSurfaceToGroup(ISciChartSurface surface);

        [MethodDeclaration]
        void RemoveSurfaceFromGroup(ISciChartSurface surface);
    }
}