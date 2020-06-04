using System.Collections.Generic;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.ObservableCollection
{
    public class AnnotationCollection : ObservableCollection<IAnnotation>
    {
        public AnnotationCollection() : base(DependencyService.Get<INativeObservableCollectionFactory>().NewAnnotationCollection())
        {
        }

        public AnnotationCollection(IEnumerable<IAnnotation> collection) : base(DependencyService.Get<INativeObservableCollectionFactory>().NewAnnotationCollection(), collection)
        {
        }
    }
}