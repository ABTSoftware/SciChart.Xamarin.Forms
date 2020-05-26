using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ModifierGroup", typeof(IChartModifier))]
    [InjectNativeSciChartObject]
    public interface IModifierGroup : IChartModifier
    {
        
    }
}