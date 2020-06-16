using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Modifiers;
using TestApp.UI.Application;
using TestApp.UI.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [ExampleDefinition("Chart Legends API", description: "Demonstrates the SciChart Legend API", icon: ExampleIcon.LineChart)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLegend : ContentPage
    {
        public AddLegend()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var ds1 = new XyDataSeries<double, double>() { SeriesName = "Curve A" };
            var ds2 = new XyDataSeries<double, double>() { SeriesName = "Curve B" };
            var ds3 = new XyDataSeries<double, double>() { SeriesName = "Curve C" };
            var ds4 = new XyDataSeries<double, double>() { SeriesName = "Curve D" };

            var ds1Points = DataManager.Instance.GetStraightLine(4000, 1.0, 10);
            var ds2Points = DataManager.Instance.GetStraightLine(3000, 1.0, 10);
            var ds3Points = DataManager.Instance.GetStraightLine(2000, 1.0, 10);
            var ds4Points = DataManager.Instance.GetStraightLine(1000, 1.0, 10);

            ds1.Append(ds1Points.XData, ds1Points.YData);
            ds2.Append(ds2Points.XData, ds2Points.YData);
            ds3.Append(ds3Points.XData, ds3Points.YData);
            ds4.Append(ds4Points.XData, ds4Points.YData);

            LineSeries1.DataSeries = ds1;
            LineSeries2.DataSeries = ds2;
            LineSeries3.DataSeries = ds3;
            LineSeries4.DataSeries = ds4;

            // TODO: investigate why without this call legend isn't visible ( UpdateLegend )
            LegendModifier.SetSourceMode(SourceMode.AllSeries);
        }
    }
}