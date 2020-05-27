using System;
using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public abstract partial class CrossPlatformDataSeriesBase : IDataSeries
    {
        protected CrossPlatformDataSeriesBase(IDataSeries nativeDataSeries)
        {
            _nativeSciChartObject = nativeDataSeries.NativeSciChartObject;
            InnerSeries = nativeDataSeries;
        }

        public IDataSeries InnerSeries { get; }

        public void Clear()
        {
            InnerSeries.Clear();
        }
    }
}