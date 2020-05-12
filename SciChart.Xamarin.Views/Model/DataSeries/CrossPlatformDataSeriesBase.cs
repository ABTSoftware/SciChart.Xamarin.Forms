using System;
using SciChart.Xamarin.Views.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public abstract class CrossPlatformDataSeriesBase : IDataSeries
    {
        protected CrossPlatformDataSeriesBase(IDataSeries nativeDataSeries)
        {
            InnerSeries = nativeDataSeries;
        }

        public IDataSeries InnerSeries { get; }
        public string SeriesName
        {
            get { return InnerSeries.SeriesName;}
            set { InnerSeries.SeriesName = value; }
        }

        public int Count => InnerSeries.Count;

        public bool AcceptsUnsortedData
        {
            get { return InnerSeries.AcceptsUnsortedData; }
            set { InnerSeries.AcceptsUnsortedData = value; }
        }

        public void Clear()
        {
            InnerSeries.Clear();
        }

        public INativeSciChartObject NativeSciChartObject => InnerSeries.NativeSciChartObject;
    }
}