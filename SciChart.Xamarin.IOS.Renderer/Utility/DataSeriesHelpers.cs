using System;
using SciChart.iOS.Charting;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class DataSeriesHelpers
    {
        public static SciChart.iOS.Charting.IDataSeries DataSeriesFromXamarin(this Views.Model.DataSeries.IDataSeries dataSeries)
        {
            return dataSeries.NativeSciChartObject as SciChart.iOS.Charting.IDataSeries;
        }

        public static Views.Model.DataSeries.IDataSeries DataSeriesToXamarin(this IISCIDataSeries dataSeries)
        {
            switch (dataSeries)
            {
                case XyDataSeriesiOS<double, double> xyDataSeries:
                    return new Views.Model.DataSeries.XyDataSeries<double, double>(xyDataSeries);

                default:
                    throw new InvalidOperationException("Unsupported type of data series");
            }
        }
    }
}