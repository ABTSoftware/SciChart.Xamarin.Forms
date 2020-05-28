using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("FastCandlestickRenderableSeries", typeof(IOhlcRenderableSeriesBase))]
    [InjectNativeSciChartObject]
    public interface IFastCandlestickRenderableSeries : IOhlcRenderableSeriesBase
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        IBrushStyle FillDownBrushStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        IBrushStyle FillUpBrushStyle { get; set; }
    }
}