using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("BaseBandRenderableSeries",typeof(IRenderableSeries))]
    [AbstractClassDefinition]
    public interface IBaseBandRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle StrokeY1Style { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        [TypeConverterDeclaration("BrushStyleConverter")]
        IBrushStyle FillBrushStyle { get; set; }
    
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        [TypeConverterDeclaration("BrushStyleConverter")]
        IBrushStyle FillY1BrushStyle { get; set; }
    }
}