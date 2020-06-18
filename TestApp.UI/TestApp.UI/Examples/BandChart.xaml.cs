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
    [ExampleDefinition("Band Chart", description: "Create a simple Band Chart", icon: ExampleIcon.BandChart)]
    public partial class BandChart : ContentPage
    {
        public BandChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var data = DataManager.Instance.GetDampedSinewave(1.0, 0.01, 1000, 10);
            var moreData = DataManager.Instance.GetDampedSinewave(1.0, 0.005, 1000, 12);

            var dataSeries = new XyyDataSeries<double, double>();

            dataSeries.Append(data.XData, data.YData, moreData.YData);

            BandSeries.DataSeries = dataSeries;
        }
    }
}