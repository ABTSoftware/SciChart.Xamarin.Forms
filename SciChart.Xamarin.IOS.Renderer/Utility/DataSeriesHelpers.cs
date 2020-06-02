using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Model.DataSeries3D;
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

        public static SciChart.iOS.Charting.IISCIDataSeries3D DataSeriesFromXamarin(this IDataSeries3D dataSeries)
        {
            return dataSeries.NativeSciChartObject as SciChart.iOS.Charting.IISCIDataSeries3D;
        }

        public static IDataSeries3D DataSeriesToXamarin(this IISCIDataSeries3D dataSeries)
        {
            switch (dataSeries)
            {
                case XyzDataSeries3DiOS<double, double, double> xyzDataSeries3D:
                    return new Views.Model.DataSeries3D.XyzDataSeries3D<double, double, double>(xyzDataSeries3D);

                default:
                    return null;
            }
        }
    }
}