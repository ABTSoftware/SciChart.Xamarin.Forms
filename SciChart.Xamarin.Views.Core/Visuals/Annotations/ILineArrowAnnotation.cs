using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("LineArrowAnnotation", typeof(ILineAnnotationBase))]
    [InjectNativeSciChartObject]
    public interface ILineArrowAnnotation : ILineAnnotationBase
    {
        [BindablePropertyDefinition()]
        float HeadWidth { get; set; }

        [BindablePropertyDefinition()]
        float HeadLength { get; set; }
    }
}