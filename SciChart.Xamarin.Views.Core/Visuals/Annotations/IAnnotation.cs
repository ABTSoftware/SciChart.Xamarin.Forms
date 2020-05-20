using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [InjectAndroidContext]
    [AbstractClassDefinition]
    [ClassDeclaration("AnnotationBase", "SCIAnnotationBase", typeof(View))]
    [XamarinFormsWrapperDefinition("AnnotationBase")]
    public interface IAnnotation
    {        
    }
}