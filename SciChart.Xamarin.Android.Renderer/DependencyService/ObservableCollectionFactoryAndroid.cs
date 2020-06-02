using Java.Lang;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;
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

        public INativeObservableCollection<IAnnotation> NewAnnotationCollection()
        {
            return new AnnotationsCollectionAndroid();
        }

        public INativeObservableCollection<IChartModifier> NewChartModifierCollection()
        {
            return new ChartModifierCollectionAndroid();
        }

        public INativeObservableCollection<IRenderableSeries3D> NewRenderableSeries3DCollection()
        {
            return new RenderableSeriesCollection3DAndroid();
        }

        public INativeObservableCollection<IChartModifier3D> NewChartModifier3DCollection()
        {
            return new ChartModifier3DCollectionAndroid();
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
            base.Insert(index, item.NativeSciChartObject as Charting.Visuals.Axes.IAxis);
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
            base.Set(index, item.NativeSciChartObject as Object);
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
            base.Insert(index, item.NativeSciChartObject as Charting.Visuals.RenderableSeries.IRenderableSeries);
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
            base.Set(index, item.NativeSciChartObject as Object);
        }
    }

    public class ChartModifierCollectionAndroid : Charting.Model.ChartModifierCollection, INativeObservableCollection<IChartModifier>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IChartModifier item)
        {
            base.Insert(index, item.NativeSciChartObject as Charting.Modifiers.IChartModifier);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting.Modifiers.IChartModifier)base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IChartModifier item)
        {
            base.Set(index, item.NativeSciChartObject as Object);
        }
    }

    public class AnnotationsCollectionAndroid : Charting.Model.AnnotationCollection, INativeObservableCollection<IAnnotation>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IAnnotation item)
        {
            base.Insert(index, item.NativeSciChartObject as Charting.Visuals.Annotations.IAnnotation);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting.Visuals.Annotations.IAnnotation) base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IAnnotation item)
        {
            base.Set(index, item.NativeSciChartObject as Object);
        }
    }

    public class RenderableSeriesCollection3DAndroid : Charting3D.Model.RenderableSeries3DCollection, INativeObservableCollection<IRenderableSeries3D>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IRenderableSeries3D item)
        {
            base.Insert(index, item.NativeSciChartObject as Charting3D.Visuals.RenderableSeries.IRenderableSeries3D);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting3D.Visuals.RenderableSeries.IRenderableSeries3D)base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IRenderableSeries3D item)
        {
            base.Set(index, item.NativeSciChartObject as Object);
        }
    }

    public class ChartModifier3DCollectionAndroid : Charting3D.Model.ChartModifier3DCollection, INativeObservableCollection<IChartModifier3D>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IChartModifier3D item)
        {
            base.Insert(index, item.NativeSciChartObject as Charting3D.Modifiers.IChartModifier3D);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
            base.Insert(newIndex, (Charting3D.Modifiers.IChartModifier3D)base.Remove(oldIndex));
        }

        public void RemoveItem(int index)
        {
            base.RemoveAt(index);
        }

        public void SetItem(int index, IChartModifier3D item)
        {
            base.Set(index, item.NativeSciChartObject as Object);
        }
    }
}