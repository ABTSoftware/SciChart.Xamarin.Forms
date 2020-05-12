using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [ClassDeclaration(typeof(INumericAxis), "NumericAxis", "SCINumericAxis")]
    public class NumericAxis : AxisBase, INumericAxis
    {
        public NumericAxis() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewNumericAxis())
        {

        }
    }
}