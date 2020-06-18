using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("FastBubbleRenderableSeries", typeof(IRenderableSeries))]
    [InjectNativeSciChartObject]
    public interface IFastBubbleRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()] 
        bool AutoZRange { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        [TypeConverterDeclaration("BrushStyleConverter")]
        IBrushStyle BubbleBrushStyle { get; set; }

        [BindablePropertyDefinition()] 
        double ZScaleFactor { get; set; }
    }
}