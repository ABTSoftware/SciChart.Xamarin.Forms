using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("BoxAnnotation", typeof(IAnnotation))]
    [InjectNativeSciChartObject]
    public interface IBoxAnnotation : IAnnotation 
    { 
        void SetBackgroundColor(Color backgroundColor);
    }
}