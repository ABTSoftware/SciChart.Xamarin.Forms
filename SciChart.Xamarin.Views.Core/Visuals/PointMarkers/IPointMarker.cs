using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.PointMarkers
{
    [ClassDeclaration("BasePointMarker", "SCIBasePointMarker", typeof(View))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("BasePointMarker")]
    public interface IPointMarker : INativeSciChartObjectWrapper
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        IPenStyle StrokeStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("BrushStyle")]
        IBrushStyle FillStyle { get; set; }

        [BindablePropertyDefinition()]
        int Width { get; set; }

        [BindablePropertyDefinition()]
        int Height { get; set; }
    }
}