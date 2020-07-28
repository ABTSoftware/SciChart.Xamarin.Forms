using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("PinchZoomModifier", typeof(IChartModifier))]
    [InjectNativeSciChartObject]
    public interface IPinchZoomModifier : IChartModifier
    {
        [NativePropertyConverterDeclaration("Direction2D")]
        [BindablePropertyDefinition()]
        Direction2D Direction{ get; set; }

        [BindablePropertyDefinition()]
        float ScaleFactor { get; set; }
        
        [BindablePropertyDefinition()]
        bool IsUniformZoom { get; set; }
    }
}