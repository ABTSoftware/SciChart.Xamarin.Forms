using Java.Lang;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

[assembly: Dependency(typeof(ObservableCollectionFactoryAndroid))]
namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    public class ObservableCollectionFactoryAndroid : INativeObservableCollectionFactory
    {
        public INativeObservableCollection<IRenderableSeries> NewRenderableSeriesCollection()
        {
            return new RenderableSeriesCollectionAndroid();
        }

        public INativeObservableCollection<IAxis> NewAxisCollection()
        {
            return new AxisCollectionAndroid();
        }
    }

    public class AxisCollectionAndroid : Charting.Model.AxisCollection, INativeObservableCollection<IAxis>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IAxis item)
        {
            base.Insert(index, item.NativeAxis as Charting.Visuals.Axes.IAxis);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting.Visuals.Axes.IAxis)base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IAxis item)
        {
            base.Set(index, item.NativeAxis as Object);
        }
    }

    public class RenderableSeriesCollectionAndroid : Charting.Model.RenderableSeriesCollection, INativeObservableCollection<IRenderableSeries>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IRenderableSeries item)
        {
            base.Insert(index, item.NativeRenderableSeries as Charting.Visuals.RenderableSeries.IRenderableSeries);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting.Visuals.RenderableSeries.IRenderableSeries)base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IRenderableSeries item)
        {
            base.Set(index, item.NativeRenderableSeries as Object);
        }
    }
}