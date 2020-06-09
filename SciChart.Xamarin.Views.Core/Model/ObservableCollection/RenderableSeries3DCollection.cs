using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class RenderableSeries3DCollection : ObservableCollection<IRenderableSeries3D>
    {
        public RenderableSeries3DCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewRenderableSeries3DCollection())
        {
        }
    }
}