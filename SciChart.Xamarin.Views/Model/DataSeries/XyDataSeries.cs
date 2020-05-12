using System;
using System.Collections.Generic;
using System.Text;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [GenericClassDeclaration(typeof(IXyDataSeries<IComparable,IComparable>), "XyDataSeries", "XyDataSeries", "TX", "TY")]
    public class XyDataSeries<TX,TY> : CrossPlatformDataSeriesBase, IXyDataSeries<TX,TY>  
        where TX:IComparable
        where TY:IComparable
    {
        public XyDataSeries(IDataSeries nativeDataSeries) : base(nativeDataSeries)
        {
        }

        public XyDataSeries() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewXyDataSeries<TX, TY>())
        {
        }

        public void Append(TX x, TY y)
        {
            ((IXyDataSeries<TX,TY>)InnerSeries).Append(x,y);
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
