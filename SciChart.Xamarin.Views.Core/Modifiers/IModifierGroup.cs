using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model.ObservableCollection;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ModifierGroup", typeof(IChartModifier))]
    [InjectNativeSciChartObject]
    public interface IModifierGroup : IChartModifier
    {
        ChartModifierCollection ChildModifiers { get; } 
    }
}