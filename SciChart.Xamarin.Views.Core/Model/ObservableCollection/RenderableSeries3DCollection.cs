using System.Collections.Generic;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class RenderableSeries3DCollection : ObservableCollection<IRenderableSeries3D>
    {
        public RenderableSeries3DCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewRenderableSeries3DCollection())
        {
        }

        public RenderableSeries3DCollection(IEnumerable<IRenderableSeries3D> collection) : base(DependencyService.Get<INativeObservableCollectionFactory>().NewRenderableSeries3DCollection(), collection)
        {
        }
    }
}