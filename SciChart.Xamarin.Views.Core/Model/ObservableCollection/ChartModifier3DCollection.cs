using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class ChartModifier3DCollection : ObservableCollection<IChartModifier3D>
    {
        public ChartModifier3DCollection() : this(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifier3DCollection())
        {
        }

        public ChartModifier3DCollection(INativeObservableCollection<IChartModifier3D> nativeObservableCollection) : base(nativeObservableCollection)
        {
        }
    }
}