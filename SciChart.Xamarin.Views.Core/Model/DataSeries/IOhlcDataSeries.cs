using System;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("OhlcDataSeries", "OhlcDataSeries", typeof(IDataSeries))]
    [GenericParamsDeclaration(new[] { "TX", "TY" }, new Type[] { typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject]
    public interface IOhlcDataSeries<TX, TY> : IDataSeries
        where TX : IComparable
        where TY : IComparable
    {
        [MethodDeclaration]
        void Append(TX x, TY open, TY high, TY low, TY close);
    }
}