using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("AxisDragModifierBase", typeof(IChartModifier))]
    [AbstractClassDefinition]
    public interface IAxisDragModifierBase : IChartModifier
    {
        [NativePropertyConverterDeclaration("AxisDragMode")]
        [BindablePropertyDefinition()]
        AxisDragMode DragMode { get; set; }

        [BindablePropertyDefinition()]
        float MinTouchArea { get; set; }
    }
}