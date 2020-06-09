using SciChart.Xamarin.Views.Visuals.Annotations;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class AnnotationCollection : ObservableCollection<IAnnotation>
    {
        public AnnotationCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewAnnotationCollection())
        {
        }
    }
}