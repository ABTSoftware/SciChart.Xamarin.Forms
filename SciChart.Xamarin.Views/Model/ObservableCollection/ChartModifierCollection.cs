using System.Collections.Generic;
using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class ChartModifierCollection : ObservableCollection<IChartModifier>
    {
        public ChartModifierCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifierCollection())
        {
        }

        public ChartModifierCollection(IEnumerable<IChartModifier> collection) : base(DependencyService.Get<INativeObservableCollectionFactory>().NewChartModifierCollection(), collection)
        {
        }
    }
}