using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("HorizontalLineAnnotation", typeof(ILineAnnotationWithLabelsBase))]
    [InjectNativeSciChartObject]
    public interface IHorizontalLineAnnotation : ILineAnnotationWithLabelsBase
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("HorizontalAlignment", "HorizontalGravity", "HorizontalAlignment", "HorizontalAlignment")]
        HorizontalAlignment VerticalAlignment { get; set; }
    }
}