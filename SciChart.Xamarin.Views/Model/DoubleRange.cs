namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines a range of type <see cref="System.Double"/>
    /// </summary>
    public partial class DoubleRange : RangeBase, IDoubleRange
    {
        public double Min
        {
            get => ((IDoubleRange)NativeSciChartObject).Min;
            set => ((IDoubleRange)NativeSciChartObject).Min = value;
        }

        public double Max
        {
            get => ((IDoubleRange)NativeSciChartObject).Max;
            set => ((IDoubleRange)NativeSciChartObject).Max = value;
        }
    }
}
