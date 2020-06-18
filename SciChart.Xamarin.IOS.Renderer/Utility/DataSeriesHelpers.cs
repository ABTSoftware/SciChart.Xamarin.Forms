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
            if (dataSeries == null) return null;

            // since we don't provide default data series for renderable series so there will be no need in reverse conversion
            throw new NotImplementedException();
        }

        public static SciChart.iOS.Charting.IISCIDataSeries3D DataSeriesFromXamarin(this IDataSeries3D dataSeries)
        {
            return dataSeries.NativeSciChartObject as SciChart.iOS.Charting.IISCIDataSeries3D;
        }

        public static IDataSeries3D DataSeriesToXamarin(this IISCIDataSeries3D dataSeries)
        {
            if (dataSeries == null) return null;

            // since we don't provide default data series for renderable series so there will be no need in reverse conversion
            throw new NotImplementedException();
        }

        public static int? FifoCapacityToXamarin(this int fifoCapacity)
        {
            if (fifoCapacity == 0)
                return null;

            return fifoCapacity;
        }

        public static int FifoCapacityFromXamarin(this int? fifoCapacity)
        {
            return fifoCapacity ?? 0;
        }
    }
}