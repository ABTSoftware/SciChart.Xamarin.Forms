using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.PointMarkers3D
{
    [ClassDeclaration("BasePointMarker3D", "SCIBasePointMarker3D", typeof(View))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("BasePointMarker3D")]
    public interface IPointMarker3D : INativeSciChartObjectWrapper
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("Color", null, "Color", "FillColor")]
        Color Fill { get; set; }

        [BindablePropertyDefinition()]
        float Size { get; set; }
    }
}