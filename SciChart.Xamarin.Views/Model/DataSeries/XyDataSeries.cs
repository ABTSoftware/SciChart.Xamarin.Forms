using System;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    public partial class XyDataSeries<TX,TY> : CrossPlatformDataSeriesBase, IXyDataSeries<TX,TY>  
        where TX:IComparable
        where TY:IComparable
    {
        public XyDataSeries(IDataSeries nativeDataSeries) : base(nativeDataSeries)
        {
        }

        public XyDataSeries() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewXyDataSeries<TX, TY>())
        {
        }
//
//        public IList<TX> XValues
//        {
//            get => ((IXyDataSeries<TX, TY>)InnerSeries).XValues;
//        }
//
//        public IList<TY> YValues
//        {
//            get => ((IXyDataSeries<TX, TY>)InnerSeries).YValues;
//        }
    }
}
