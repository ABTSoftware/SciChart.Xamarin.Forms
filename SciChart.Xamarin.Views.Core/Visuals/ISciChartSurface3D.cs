using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Visuals.Axes3D;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface3D
    {
        IAxis3D XAxis { get; set; }
        IAxis3D YAxis { get; set; }
        IAxis3D ZAxis { get; set; }

        RenderableSeries3DCollection RenderableSeries { get; set; }
        ChartModifier3DCollection ChartModifiers { get; set; }
    }
}