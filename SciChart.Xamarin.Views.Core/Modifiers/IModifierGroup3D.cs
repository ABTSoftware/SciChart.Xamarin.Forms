using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model.ObservableCollection;

namespace SciChart.Xamarin.Views.Modifiers
{
    [ClassDeclaration("ModifierGroup3D", typeof(IChartModifier3D))]
    [InjectNativeSciChartObject]
    public interface IModifierGroup3D : IChartModifier3D
    {
        ChartModifier3DCollection ChildModifiers { get; }
    }
}