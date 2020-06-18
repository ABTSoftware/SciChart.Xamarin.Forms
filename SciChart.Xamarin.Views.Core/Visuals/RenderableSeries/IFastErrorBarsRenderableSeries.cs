using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("FastErrorBarsRenderableSeries", typeof(IRenderableSeries))]
    [InjectNativeSciChartObject]
    public interface IFastErrorBarsRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle StrokeLowStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle StrokeHighStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("ErrorDirection")]
        ErrorDirection ErrorDirection { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("ErrorMode")]
        ErrorMode ErrorMode { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("ErrorType")]
        ErrorType ErrorType { get; set; }
    }
}