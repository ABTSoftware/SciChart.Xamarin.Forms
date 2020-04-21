using SciChart.Xamarin.Views.Core;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    public interface IAxisFactory
    {
        INativeAxis NewNumericAxis();
    }
}