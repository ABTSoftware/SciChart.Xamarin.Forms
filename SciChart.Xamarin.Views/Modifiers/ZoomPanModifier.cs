using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Modifiers
{
    public partial class ZoomPanModifier
    {
        public ZoomPanModifier() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewZoomPanModifier())
        {
        }
    }
}