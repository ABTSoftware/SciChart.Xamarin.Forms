using System.Collections.Generic;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class RenderableSeriesCollection : ObservableCollection<IRenderableSeries>
    {
        public RenderableSeriesCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewRenderableSeriesCollection())
        {
        }
    }
}