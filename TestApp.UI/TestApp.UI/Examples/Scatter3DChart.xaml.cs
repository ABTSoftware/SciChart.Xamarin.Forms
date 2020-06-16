using SciChart.Xamarin.Views.Model.DataSeries3D;
using SciChart.Xamarin.Views.Visuals.PointMarkers3D;
using TestApp.UI.Application;
using TestApp.UI.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Scatter3D Chart", description: "Create a simple Scatter3D Chart", icon: ExampleIcon.Scatter3D)]
    public partial class Scatter3DChart : ContentPage
    {
        public Scatter3DChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataManager = DataManager.Instance;

            var dataSeries3D = new XyzDataSeries3D<double, double, double>();

            for (int i = 0; i < 100; i++)
            {
                double x = dataManager.GetGaussianRandomNumber(5, 1.5);
                double y = dataManager.GetGaussianRandomNumber(5, 1.5);
                double z = dataManager.GetGaussianRandomNumber(5, 1.5);

                dataSeries3D.Append(x, y, z);
            }

            ScatterRenderableSeries3D.DataSeries = dataSeries3D;

            // need to set point marker after creation of SciChartSurface3D because otherwise it crashes
            ScatterRenderableSeries3D.PointMarker = new EllipsePointMarker3D()
            {
                Fill = Color.Green,
                Size = 5
            };
        }
    }
}