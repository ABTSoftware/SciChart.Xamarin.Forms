using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("FastUniformHeatmapRenderableSeries", typeof(IRenderableSeries))]
    [InjectNativeSciChartObject]
    public interface IFastUniformHeatmapRenderableSeries : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        double Minimum { get; set; }

        [BindablePropertyDefinition()]
        double Maximum { get; set; }

        [BindablePropertyDefinition()]
        bool DrawTextInCell { get; set; }

        // TODO implement in iOS
        // [BindablePropertyDefinition()]
        // [NativePropertyConverterDeclaration("FontStyle")]
        // [TypeConverterDeclaration("FontStyleConverter")]
        // IFontStyle CellTextStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("ColorMap")]
        IColorMap ColorMap { get; set; }
    }
}