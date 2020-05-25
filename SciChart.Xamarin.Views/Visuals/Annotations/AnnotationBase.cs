using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    public partial class AnnotationBase : IBindingContextProvider
    {
        protected AnnotationBase(IAnnotation nativeAnnotation)
        {
            NativeSciChartObject = nativeAnnotation.NativeSciChartObject;
        }

        public INativeSciChartObject NativeSciChartObject { get; }
    }
}