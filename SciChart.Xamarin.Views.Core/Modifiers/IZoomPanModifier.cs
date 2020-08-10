using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ZoomPanModifier", typeof(IChartModifier))]
    [InjectNativeSciChartObject]
    public interface IZoomPanModifier : IChartModifier
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("Direction2D")]
        Direction2D Direction { get; set; }

        [NativePropertyConverterDeclaration("ClipModeTarget")]
        [BindablePropertyDefinition()]
        ClipModeTarget ClipModeTargetX { get; set; }

        [NativePropertyConverterDeclaration("ClipMode")]
        [BindablePropertyDefinition()]
        ClipMode ClipModeX { get; set; }
/*
        TODO Implement these properties in iOS
        [NativePropertyConverterDeclaration("ClipModeTarget")]
        [BindablePropertyDefinition()]
        ClipModeTarget ClipModeTargetY { get; set; }

        [NativePropertyConverterDeclaration("ClipMode")]
        [BindablePropertyDefinition()]
        ClipMode ClipModeY { get; set; }
*/

        [BindablePropertyDefinition()]
        bool ZoomExtentsY { get; set; }
    }
}