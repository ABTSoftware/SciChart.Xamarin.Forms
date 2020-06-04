using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ChartModifierCore", typeof(View))]
    [AbstractClassDefinition]
    public interface IChartModifierCore : INativeSciChartObjectWrapper
    {
        [BindablePropertyDefinition()]
        bool IsEnabled { get; set; }

        [BindablePropertyDefinition()]
        bool ReceiveHandledEvents { get; set; }
    }
}