using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ChartModifierBase", typeof(IChartModifierCore))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("ChartModifierBase")]
    public interface IChartModifier : IChartModifierCore
    {
        
    }
}