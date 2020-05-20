using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Core.Modifiers
{
    [ClassDeclaration("ChartModifierBase", "SCIChartModifierBase", typeof(IChartModifierCore))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("ChartModifierBase")]
    public interface IChartModifier : IChartModifierCore
    {
        
    }
}