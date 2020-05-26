using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("BoxAnnotation", typeof(IAnnotation))]
    [InjectNativeSciChartObject]
    public interface IBoxAnnotation : IAnnotation { 
    }
}