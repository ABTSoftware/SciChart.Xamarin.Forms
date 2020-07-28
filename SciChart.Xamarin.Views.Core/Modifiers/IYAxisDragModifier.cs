using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("YAxisDragModifier", typeof(IAxisDragModifierBase))]
    [InjectNativeSciChartObject]
    public interface IYAxisDragModifier : IAxisDragModifierBase
    {
        
    }
}