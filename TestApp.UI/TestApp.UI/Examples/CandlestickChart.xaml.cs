using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model.DataSeries;
using TestApp.UI.Application;
using TestApp.UI.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Candlestick Chart", description: "Create a simple Candlestick Chart", icon: ExampleIcon.CandlestickChart)]
    public partial class CandlestickChart : ContentPage
    {
        public CandlestickChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var priceSeries = DataManager.Instance.GetPriceDataIndu();

            var dataSeries = new OhlcDataSeries<DateTime, double>();
            dataSeries.Append(priceSeries.TimeData, priceSeries.OpenData, priceSeries.HighData, priceSeries.LowData, priceSeries.CloseData);

            CandlestickSeries.DataSeries = dataSeries;

            CandlestickSeries.FillDownBrushStyle = new SolidBrushStyle(Color.Red);
            CandlestickSeries.FillUpBrushStyle = new SolidBrushStyle(Color.Green);
        }
    }
}