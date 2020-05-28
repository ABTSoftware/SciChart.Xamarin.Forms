using System;
using SciChart.iOS.Charting;
using IDataSeries = SciChart.Xamarin.Views.Model.DataSeries.IDataSeries;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class DataSeriesHelpers
    {
        public static SciChart.iOS.Charting.IDataSeries DataSeriesFromXamarin(this IDataSeries dataSeries)
        {
            return dataSeries.NativeSciChartObject as SciChart.iOS.Charting.IDataSeries;
        }

        public static IDataSeries DataSeriesToXamarin(this IISCIDataSeries dataSeries)
        {
            switch (dataSeries)
            {
                case XyDataSeriesiOS<double, double> xyDataSeries:
                    return new Views.Model.DataSeries.XyDataSeries<double, double>(xyDataSeries);

                case OhlcDataSeriesiOS<double, double> ohlcDataSeries:
                    return new Views.Model.DataSeries.OhlcDataSeries<double, double>(ohlcDataSeries);
                default:
                    return null;
            }
        }
    }
}