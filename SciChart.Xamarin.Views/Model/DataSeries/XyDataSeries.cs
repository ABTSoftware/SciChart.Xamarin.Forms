using System;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public partial class XyDataSeries<TX,TY> : CrossPlatformDataSeriesBase, IXyDataSeries<TX,TY>  
        where TX:IComparable
        where TY:IComparable
    {
        public XyDataSeries(IXyDataSeries<TX, TY> nativeDataSeries) : base(nativeDataSeries)
        {
        }
    }
}
