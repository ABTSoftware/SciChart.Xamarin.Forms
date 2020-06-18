using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Xamarin.Views.Model.DataSeries;
using TestApp.UI.Application;
using TestApp.UI.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Mountain Chart", description: "Create a simple Mountain Chart", icon: ExampleIcon.MountainChart)]
    public partial class MountainChart : ContentPage
    {
        public MountainChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataSeries = new XyDataSeries<DateTime, double>();

            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            dataSeries.Append(priceSeries.TimeData, priceSeries.CloseData);

            MountainSeries.DataSeries = dataSeries;
        }
    }
}