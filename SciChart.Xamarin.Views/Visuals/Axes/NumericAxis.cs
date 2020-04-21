using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public class NumericAxis : AxisBase, INumericAxis
    {
        public NumericAxis() : base(DependencyService.Get<IAxisFactory>().NewNumericAxis())
        {

        }
    }
}