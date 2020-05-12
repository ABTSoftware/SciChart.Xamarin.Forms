using System;
using SciChart.Xamarin.Views.Model.DataSeries;
using IDataSeries = SciChart.Charting.Model.DataSeries.IDataSeries;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class DataSeriesHelpers
    {
        public static IDataSeries DataSeriesFromXamarin(this Views.Model.DataSeries.IDataSeries dataSeries)
        {
            return dataSeries.NativeSciChartObject as IDataSeries;
        }

        public static Views.Model.DataSeries.IDataSeries DataSeriesToXamarin(this IDataSeries dataSeries)
        {
            switch (dataSeries)
            {
                case XyDataSeriesAndroid<double, double> xyDataSeries:
                    return new XyDataSeries<double, double>(xyDataSeries);

                default:
                    throw new InvalidOperationException("Unsupported type of data series");
            }
        }
    }
}