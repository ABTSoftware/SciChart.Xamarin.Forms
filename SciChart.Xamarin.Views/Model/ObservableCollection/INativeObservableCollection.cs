using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public interface INativeObservableCollection<T>
    {
        void ClearItems();

        void InsertItem(int index, T item);

        void MoveItem(int oldIndex, int newIndex);


        void RemoveItem(int index);

        void SetItem(int index, T item);
    }

    public interface INativeObservableCollectionFactory
    {
        INativeObservableCollection<IRenderableSeries> NewRenderableSeriesCollection();

        INativeObservableCollection<IAxis> NewAxisCollection();
    }
}