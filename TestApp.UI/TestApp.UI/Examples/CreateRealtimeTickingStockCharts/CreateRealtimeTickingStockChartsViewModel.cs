using System;
using System.Linq;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using TestApp.UI.Common;
using TestApp.UI.Data;
using Xamarin.Forms;

namespace TestApp.UI.Examples.CreateRealtimeTickingStockCharts
{
    public class CreateRealtimeTickingStockChartsViewModel : BaseViewModel
    {
        private const int DefaultPointCount = 150;

        private readonly Color _strokeUpColor = Color.FromUint(0xFF00AA00);
        private readonly Color _strokeDownColor = Color.FromUint(0xFFFF0000);

        // Create data service to populate the data
        private readonly IMarketDataService _marketDataService = new MarketDataService(new DateTime(2000, 08, 01, 12, 00, 00), 5, 50);
        private readonly MovingAverage _sma50 = new MovingAverage(50);
        private PriceBar _lastPrice;

        private double _closeValue;
        private Color _priceMarkerColor;
        private double _smaValue;

        public Color PriceMarkerColor
        {
            get => _priceMarkerColor;
            set
            {
                _priceMarkerColor = value;
                OnPropertyChanged();
            }
        }

        public double CloseValue
        {
            get => _closeValue;
            set
            {
                _closeValue = value;
                OnPropertyChanged();
            }
        }

        public double SmaValue
        {
            get => _smaValue;
            set
            {
                _smaValue = value;
                OnPropertyChanged();
            }
        }

        public DoubleRange XRange { get; } = new DoubleRange(0, DefaultPointCount);

        public double PointCount => OhlcDataSeries.Count;

        public OhlcDataSeries<DateTime, double> OhlcDataSeries { get; } = new OhlcDataSeries<DateTime, double> { SeriesName = "Price Series" };

        public XyDataSeries<DateTime, double> XyDataSeries { get; } = new XyDataSeries<DateTime, double> { SeriesName = "50-Period SMA" };

        public void OnStart()
        {
            InitData(_marketDataService);

            _marketDataService.SubscribePriceUpdate(OnNewPrice);
        }

        private void InitData(IMarketDataService marketDataService)
        {
            var prices = marketDataService.GetHistoricalData(DefaultPointCount).ToList();
            _lastPrice = prices.Last();

            // Populate data series with some data
            OhlcDataSeries.Append(prices.Select(x => x.DateTime),
                prices.Select(x => x.Open),
                prices.Select(x => x.High),
                prices.Select(x => x.Low),
                prices.Select(x => x.Close));
            XyDataSeries.Append(prices.Select(x => x.DateTime), prices.Select(y => _sma50.Push(y.Close).Current));
        }

        private void OnNewPrice(PriceBar price)
        {
            // Update the last price, or append? 
            double smaLastValue;
            if (_lastPrice.DateTime == price.DateTime)
            {
                OhlcDataSeries.Update(OhlcDataSeries.Count - 1, price.Open, price.High, price.Low, price.Close);

                smaLastValue = _sma50.Update(price.Close).Current;
                XyDataSeries.UpdateYAt(XyDataSeries.Count - 1, smaLastValue);
            }
            else
            {
                OhlcDataSeries.Append(price.DateTime, price.Open, price.High, price.Low, price.Close);

                smaLastValue = _sma50.Push(price.Close).Current;
                XyDataSeries.Append(price.DateTime, smaLastValue);

                // If the latest appending point is inside the viewport (i.e. not off the edge of the screen)
                // then scroll the viewport 1 bar, to keep the latest bar at the same place
                if (XRange.MaxAsDouble > OhlcDataSeries.Count)
                {
                    XRange.SetMinMaxDouble(XRange.MinAsDouble + 1, XRange.MaxAsDouble + 1);

                }

                OnPropertyChanged("PointCount");
            }


            PriceMarkerColor = price.Close >= price.Open ? _strokeUpColor : _strokeDownColor;
            CloseValue = price.Close;
            SmaValue = smaLastValue;

            _lastPrice = price;
        }

        public void OnStop()
        {
            _marketDataService.ClearSubscriptions();
        }
    }
}