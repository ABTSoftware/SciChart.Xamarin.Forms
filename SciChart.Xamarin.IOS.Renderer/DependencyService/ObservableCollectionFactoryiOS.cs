using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

[assembly: Dependency(typeof(ObservableCollectionFactoryiOS))]
namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class ObservableCollectionFactoryiOS : INativeObservableCollectionFactory
    {
        public INativeObservableCollection<IRenderableSeries> NewRenderableSeriesCollection()
        {
            return new RenderableSeriesCollectionIOS();
        }

        public INativeObservableCollection<IAxis> NewAxisCollection()
        {
            return new AxisCollectionIOS();
        }
    }

    public class AxisCollectionIOS : SCIAxisCollection, INativeObservableCollection<IAxis>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IAxis item)
        {
            base.Insert(index, (SCINumericAxis)item.NativeAxis);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            var item = base[oldIndex];
            base.RemoveAt(oldIndex);
            base.Insert(newIndex, item);
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IAxis item)
        {
            base[index] = item.NativeAxis as IISCIAxis;
        }
    }

    public class RenderableSeriesCollectionIOS : SCIRenderableSeriesCollection, INativeObservableCollection<IRenderableSeries>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IRenderableSeries item)
        {
            base.Insert(index, item.NativeRenderableSeries as IISCIRenderableSeries);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            var item = base[oldIndex];
            base.RemoveAt(oldIndex);
            base.Insert(newIndex, item);
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IRenderableSeries item)
        {
            base[index] = item.NativeRenderableSeries as IISCIRenderableSeries;
        }
    }
}