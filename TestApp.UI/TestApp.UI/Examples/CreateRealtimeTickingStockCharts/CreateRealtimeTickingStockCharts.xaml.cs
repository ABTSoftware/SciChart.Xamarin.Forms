using System;
using System.Linq;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using TestApp.UI.Application;
using TestApp.UI.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples.CreateRealtimeTickingStockCharts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Realtime Ticking Stock Charts", description: "Creates a realtime stock chart which ticks and updates, simulating live a market", icon: ExampleIcon.RealTime)]
    public partial class CreateRealtimeTickingStockCharts : ContentPage
    {
        private readonly CreateRealtimeTickingStockChartsViewModel _viewModel = new CreateRealtimeTickingStockChartsViewModel();
   

        public CreateRealtimeTickingStockCharts()
        {
            InitializeComponent();

            LegendModifier.SetLegendPosition(HorizontalAlignment.Center, VerticalAlignment.Bottom, 10, 10, 10, 10);
            LegendModifier.SetLegendOrientation(Orientation.Horizontal);

            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnStart();
        }

        protected override void OnDisappearing()
        {
            _viewModel.OnStop();

            base.OnDisappearing();
        }
    }
}