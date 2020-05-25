using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    public partial class BoxAnnotation
    {
        public BoxAnnotation() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewBoxAnnotation())
        {
        }
    }
}