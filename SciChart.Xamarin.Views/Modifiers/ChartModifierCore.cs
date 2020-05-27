using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Modifiers
{
    public partial class ChartModifierCore : IBindingContextProvider
    {
        protected ChartModifierCore(IChartModifierCore nativeChartModifier)
        {
            _nativeSciChartObject = nativeChartModifier.NativeSciChartObject;
        }
    }
}