using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [AbstractClassDefinition]
    [ClassDeclaration("LineAnnotationBase", typeof(IAnnotation))]
    public interface ILineAnnotationBase : IAnnotation
    {
        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        [TypeConverterDeclaration("PenStyleConverter")]
        IPenStyle Stroke { get; set; }
    }
}