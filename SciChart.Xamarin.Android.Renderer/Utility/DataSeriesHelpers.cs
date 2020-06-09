using System;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Model.DataSeries3D;
using IDataSeries = SciChart.Charting.Model.DataSeries.IDataSeries;
using IDataSeries3D = SciChart.Charting3D.Model.DataSeries.IDataSeries3D;

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

                case OhlcDataSeriesAndroid<double, double> ohlcDataSeries:
                    return new OhlcDataSeries<double, double>(ohlcDataSeries);

                case OhlcDataSeriesAndroid<DateTime, double> ohlcDataSeries:
                    return new OhlcDataSeries<DateTime, double>(ohlcDataSeries);

                default:
                    return null;
            }
        }

        public static IDataSeries3D DataSeriesFromXamarin(this Views.Model.DataSeries3D.IDataSeries3D dataSeries)
        {
            return dataSeries.NativeSciChartObject as IDataSeries3D;
        }

        public static Views.Model.DataSeries3D.IDataSeries3D DataSeriesToXamarin(this IDataSeries3D dataSeries)
        {
            switch (dataSeries)
            {
                case XyzDataSeries3DAndroid<double, double, double> xyzDataSeries3D:
                    return new XyzDataSeries3D<double, double, double>(xyzDataSeries3D);

                default:
                    return null;
            }
        }
    }
}