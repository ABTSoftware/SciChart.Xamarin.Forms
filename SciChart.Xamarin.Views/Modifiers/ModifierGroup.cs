using SciChart.Xamarin.Views.Model.ObservableCollection;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ContentProperty("ChildModifiers")]
    public partial class ModifierGroup
    {
        public ChartModifierCollection ChildModifiers => NativeSciChartObject.Cast<IModifierGroup>().ChildModifiers;
    }
}