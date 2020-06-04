using System.Collections.Generic;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class AxisCollection : ObservableCollection<IAxis>
    {
        public AxisCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewAxisCollection())
        {
        }

        public AxisCollection(IEnumerable<IAxis> collection) : base(DependencyService.Get<INativeObservableCollectionFactory>().NewAxisCollection(), collection)
        {
        }
    }
}