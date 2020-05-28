using System;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public partial class OhlcDataSeries<TX, TY> : CrossPlatformDataSeriesBase, IOhlcDataSeries<TX, TY>
        where TX : IComparable
        where TY : IComparable
    {
        public OhlcDataSeries(IOhlcDataSeries<TX, TY> nativeDataSeries) : base(nativeDataSeries)
        {
        }
    }
}