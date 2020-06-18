using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("BaseMountainRenderableSeries", typeof(IRenderableSeries))]
    [AbstractClassDefinition]
    public interface IBaseMountainRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        [TypeConverterDeclaration("BrushStyleConverter")]
        IBrushStyle AreaStyle { get; set; }

        [BindablePropertyDefinition()]
        bool IsDigitalLine { get; set; }
    }
}