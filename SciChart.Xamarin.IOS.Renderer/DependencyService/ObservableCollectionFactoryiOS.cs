using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;
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

        public INativeObservableCollection<IAnnotation> NewAnnotationCollection()
        {
            return new AnnotationsCollectionIOS();
        }

        public INativeObservableCollection<IChartModifier> NewChartModifierCollection()
        {
            return new ChartModifierCollectionIOS();
        }

        public INativeObservableCollection<IRenderableSeries3D> NewRenderableSeries3DCollection()
        {
            return new RenderableSeries3DCollectionIOS();
        }

        public INativeObservableCollection<IChartModifier3D> NewChartModifier3DCollection()
        {
            return new ChartModifier3DCollectionIOS();
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
            base.Insert(index, (SCINumericAxis)item.NativeSciChartObject);
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
            base[index] = item.NativeSciChartObject as IISCIAxis;
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
            base.Insert(index, item.NativeSciChartObject as IISCIRenderableSeries);
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
            base[index] = item.NativeSciChartObject as IISCIRenderableSeries;
        }
    }

    public class ChartModifierCollectionIOS : SCIChartModifierCollection, INativeObservableCollection<IChartModifier>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IChartModifier item)
        {
            base.Insert(index, item.NativeSciChartObject as IISCIChartModifier);
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

        public void SetItem(int index, IChartModifier item)
        {
            base[index] = item.NativeSciChartObject as IISCIChartModifier;
        }
    }

    public class AnnotationsCollectionIOS : SCIAnnotationCollection, INativeObservableCollection<IAnnotation>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IAnnotation item)
        {
            base.Insert(index, item.NativeSciChartObject as IISCIAnnotation);
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

        public void SetItem(int index, IAnnotation item)
        {
            base[index] = item.NativeSciChartObject as IISCIAnnotation;
        }
    }

    public class RenderableSeries3DCollectionIOS : SCIRenderableSeries3DCollection, INativeObservableCollection<IRenderableSeries3D>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IRenderableSeries3D item)
        {
            base.Insert(index, item.NativeSciChartObject as IISCIRenderableSeries3D);
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

        public void SetItem(int index, IRenderableSeries3D item)
        {
            base[index] = item.NativeSciChartObject as IISCIRenderableSeries3D;
        }
    }

    public class ChartModifier3DCollectionIOS : SCIChartModifier3DCollection, INativeObservableCollection<IChartModifier3D>
    {
        public void ClearItems()
        {
            base.Clear();
        }

        public void InsertItem(int index, IChartModifier3D item)
        {
            base.Insert(index, item.NativeSciChartObject as IISCIChartModifier3D);
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

        public void SetItem(int index, IChartModifier3D item)
        {
            base[index] = item.NativeSciChartObject as IISCIChartModifier3D;
        }
    }

    internal class ChartModifierCollectionWrapperIOS : INativeObservableCollection<IChartModifier>
    {
        private readonly SCIChartModifierCollection _nativeObservableCollection;
        public ChartModifierCollectionWrapperIOS(SCIChartModifierCollection nativeObservableCollection)
        {
            _nativeObservableCollection = nativeObservableCollection;
        }

        public void ClearItems()
        {
            _nativeObservableCollection.Clear();
        }

        public void InsertItem(int index, IChartModifier item)
        {
            _nativeObservableCollection.Insert(index, item.NativeSciChartObject as IISCIChartModifier);
        }

        public void MoveItem(int oldIndex, int newIndex)
        {
        }

        public void RemoveItem(int index)
        {
        }

        public void SetItem(int index, IChartModifier item)
        {
        }
    }

    internal class FormsChartModifierCollectionIOS : ChartModifierCollection
    {
        public FormsChartModifierCollectionIOS(SCIChartModifierCollection nativeChartModifierCollection) : base(new ChartModifierCollectionWrapperIOS(nativeChartModifierCollection))
        {

        }
    }
}