using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [AbstractClassDefinition]
    [ClassDeclaration("AnnotationBase", typeof(IAnnotation))]
    public interface IAnchorPointAnnotation : IAnnotation
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("HorizontalAnchorPoint")]
        HorizontalAnchorPoint HorizontalAnchorPoint { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("VerticalAnchorPoint")]
        VerticalAnchorPoint VerticalAnchorPoint { get; set; }
    }
}