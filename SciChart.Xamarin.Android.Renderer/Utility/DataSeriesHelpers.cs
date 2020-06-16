using System;
using Java.Lang;
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
            if (dataSeries == null) return null;

            // since we don't provide default data series for renderable series so there will be no need in reverse conversion
            throw new NotImplementedException();
        }

        public static IDataSeries3D DataSeriesFromXamarin(this Views.Model.DataSeries3D.IDataSeries3D dataSeries)
        {
            return dataSeries.NativeSciChartObject as IDataSeries3D;
        }

        public static Views.Model.DataSeries3D.IDataSeries3D DataSeriesToXamarin(this IDataSeries3D dataSeries)
        {
            if (dataSeries == null) return null;

            // since we don't provide default data series for renderable series so there will be no need in reverse conversion
            throw new NotImplementedException();
        }
    }
}