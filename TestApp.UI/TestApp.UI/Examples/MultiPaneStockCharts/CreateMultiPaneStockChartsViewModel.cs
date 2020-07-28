using System.Collections.ObjectModel;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Synchronization;
using TestApp.UI.Common;
using TestApp.UI.Data;

namespace TestApp.UI.Examples.MultiPaneStockCharts
{
    public class CreateMultiPaneStockChartsViewModel : BaseViewModel
    {
        public CreateMultiPaneStockChartsViewModel()
        {
            var priceSeries = DataManager.Instance.GetPriceDataEurUsd();

            var verticalGroup = new SciChartVerticalGroup();
            var sharedXRange = new DoubleRange();

            PricesViewModel = new PricePaneViewModel(priceSeries, verticalGroup, sharedXRange);
            MacdViewModel = new MacdPaneViewModel(priceSeries, verticalGroup, sharedXRange);
            RsiViewModel = new RsiPaneViewModel(priceSeries, verticalGroup, sharedXRange);
            VolumeViewModel = new VolumePaneViewModel(priceSeries, verticalGroup, sharedXRange);
        }

        public PricePaneViewModel PricesViewModel { get; private set; }
        public MacdPaneViewModel MacdViewModel { get; private set; }
        public RsiPaneViewModel RsiViewModel { get; private set; }
        public VolumePaneViewModel VolumeViewModel { get; private set; }
    }
}