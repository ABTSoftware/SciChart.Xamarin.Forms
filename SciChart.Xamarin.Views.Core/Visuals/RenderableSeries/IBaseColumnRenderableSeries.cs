using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("BaseColumnRenderableSeries", typeof(IRenderableSeries))]
    [AbstractClassDefinition]
    public interface IBaseColumnRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        [TypeConverterDeclaration("BrushStyleConverter")]
        IBrushStyle FillBrushStyle { get; set; }

        [BindablePropertyDefinition()]
        double DataPointWidth { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("TextureMappingMode")]
        TextureMappingMode FillBrushMappingMode { get; set; }
    }
}