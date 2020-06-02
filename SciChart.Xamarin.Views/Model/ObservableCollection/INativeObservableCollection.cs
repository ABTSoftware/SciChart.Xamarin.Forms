using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;

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

        INativeObservableCollection<IAnnotation> NewAnnotationCollection();
        INativeObservableCollection<IChartModifier> NewChartModifierCollection();

        INativeObservableCollection<IRenderableSeries3D> NewRenderableSeries3DCollection();
        INativeObservableCollection<IChartModifier3D> NewChartModifier3DCollection();
    }
}