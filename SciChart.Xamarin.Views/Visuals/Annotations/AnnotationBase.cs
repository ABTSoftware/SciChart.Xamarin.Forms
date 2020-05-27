using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    public partial class AnnotationBase : IBindingContextProvider
    {
        protected AnnotationBase(IAnnotation nativeAnnotation)
        {
            _nativeSciChartObject = nativeAnnotation.NativeSciChartObject;
        }
    }
}