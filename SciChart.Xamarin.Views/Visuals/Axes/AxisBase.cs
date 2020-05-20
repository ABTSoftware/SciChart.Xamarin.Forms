namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public abstract partial class AxisBase : AxisCore, IAxis
    {
        protected AxisBase(IAxis nativeAxis) : base(nativeAxis)
        {
        }
    }
}