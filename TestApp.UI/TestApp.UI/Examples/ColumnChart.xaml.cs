using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciChart.Xamarin.Views.Model.DataSeries;
using TestApp.UI.Application;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ExampleDefinition("Column Chart", description: "Create a simple Column Chart", icon: ExampleIcon.ColumnChart)]
    public partial class ColumnChart : ContentPage
    {
        public ColumnChart()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var dataSeries = new XyDataSeries<double, double>();

            int[] yValues = { 50, 35, 61, 58, 50, 50, 40, 53, 55, 23, 45, 12, 59, 60 };

            for (int i = 0; i < yValues.Length; i++)
            {
                dataSeries.Append(i, yValues[i]);
            }

            ColumnSeries.DataSeries = dataSeries;
        }
    }
}