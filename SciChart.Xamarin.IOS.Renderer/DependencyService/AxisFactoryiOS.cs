using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Visuals.Axes;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    public class AxisFactoryiOS : IAxisFactory
    {
        public INativeAxis NewNumericAxis()
        {
            return new NumericAxisiOS();
        }
    }
}