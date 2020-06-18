using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("FastBandRenderableSeries", typeof(IBaseBandRenderableSeries))]
    [InjectNativeSciChartObject]
    public interface IFastBandRenderableSeries : IBaseBandRenderableSeries
    {
        [BindablePropertyDefinition()]
        bool IsDigitalLine { get; set; }
    }
}