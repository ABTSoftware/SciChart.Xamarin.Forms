using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("OhlcRenderableSeriesBase", typeof(IRenderableSeries))]
    [AbstractClassDefinition]
    public interface IOhlcRenderableSeriesBase : IRenderableSeries
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle StrokeDownStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle StrokeUpStyle { get; set; }

        [BindablePropertyDefinition()]
        double DataPointWidth { get; set; }
    }
}