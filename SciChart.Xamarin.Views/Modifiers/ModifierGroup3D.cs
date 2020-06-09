using SciChart.Xamarin.Views.Model.ObservableCollection;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ContentProperty("ChildModifiers")]
    public partial class ModifierGroup3D
    {
        public ChartModifier3DCollection ChildModifiers => NativeSciChartObject.Cast<IModifierGroup3D>().ChildModifiers;
    }
}