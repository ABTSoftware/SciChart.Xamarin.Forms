using TestApp.UI.Application;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI.Examples.MultiPaneStockCharts
{
    [ExampleDefinition("Multi-Pane Stock Chart", description: "Creates Multi-Pane Stock Chart", icon: ExampleIcon.CandlestickChart)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMultiPaneStockCharts : ContentPage
    {
        public CreateMultiPaneStockCharts()
        {
            InitializeComponent();
        }
    }
}