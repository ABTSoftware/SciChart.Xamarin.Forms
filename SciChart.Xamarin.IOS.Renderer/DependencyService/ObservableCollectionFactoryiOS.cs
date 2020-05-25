using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Annotations;
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

        public INativeObservableCollection<IAnnotation> NewAnnotationCollection()
        {
            return new AnnotationsCollectionIOS();
        }

        public INativeObservableCollection<IChartModifier> NewChartModifierCollection()
        {
            return new ChartModifierCollectionIOS();
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
}