using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public partial class NumericAxis : AxisBase
    {
        public NumericAxis() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewNumericAxis())
        {

        }

        private static object Test(BindableObject bindable)
        {
            return bindable.CastBindableWrapper<INumericAxis>().AutoRange;
        }
    }
}