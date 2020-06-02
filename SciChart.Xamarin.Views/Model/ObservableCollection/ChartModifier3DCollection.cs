using System.Collections.Generic;
using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class ChartModifier3DCollection : ObservableCollection<IChartModifier3D>
    {
        public ChartModifier3DCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifier3DCollection())
        {
        }

        public ChartModifier3DCollection(IEnumerable<IChartModifier3D> collection) : base(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifier3DCollection(), collection)
        {
        }
    }
}