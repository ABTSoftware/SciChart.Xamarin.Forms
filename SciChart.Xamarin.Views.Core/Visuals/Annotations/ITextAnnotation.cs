using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("TextAnnotation", typeof(IAnchorPointAnnotation))]
    [InjectNativeSciChartObject]
    public interface ITextAnnotation : IAnchorPointAnnotation
    {
        [BindablePropertyDefinition()]
        string Text { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("FontStyle")]
        IFontStyle FontStyle { get; set; }

        [BindablePropertyDefinition()]
        bool CanEditText { get; set; }

        [BindablePropertyDefinition()]
        float RotationAngle { get; set; }
    }
}