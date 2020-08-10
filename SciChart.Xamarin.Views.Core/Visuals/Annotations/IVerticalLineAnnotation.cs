using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("VerticalLineAnnotation", typeof(ILineAnnotationWithLabelsBase))]
    [InjectNativeSciChartObject]
    public interface IVerticalLineAnnotation : ILineAnnotationWithLabelsBase
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("VerticalAlignment", "VerticalGravity", "VerticalAlignment", "VerticalAlignment")]
        VerticalAlignment VerticalAlignment { get; set; }
    }
}