using System;
using SciChart.Xamarin.Views.Model.DataSeries;
using TestApp.UI.Application;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Line Chart", description: "Create a simple Line Chart", icon: ExampleIcon.LineChart)]
    public partial class LineChart : ContentPage
    {
        public LineChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataSeries = new XyDataSeries<double, double>();

            for (int i = 0; i < 100; i++)
            {
                var y = Math.Sin(i * 0.05);
                dataSeries.Append(i, y);
            }

            LineSeries.DataSeries = dataSeries;
        }
    }
}