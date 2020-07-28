using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("XAxisDragModifier", typeof(IAxisDragModifierBase))]
    [InjectNativeSciChartObject]
    public interface IXAxisDragModifier : IAxisDragModifierBase
    {
        [NativePropertyConverterDeclaration("ClipModeTarget")]
        [BindablePropertyDefinition()]
        ClipModeTarget ClipModeTargetX { get; set; }

        [NativePropertyConverterDeclaration("ClipMode")]
        [BindablePropertyDefinition()]
        ClipMode ClipModeX { get; set; }
    }
}