using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("OhlcDataSeries", "OhlcDataSeries", typeof(IXDataSeries))]
    [GenericParamsDeclaration(new[] { "TX", "TY" }, new Type[] { typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject]
    public interface IOhlcDataSeries<TX, TY> : IXDataSeries
        where TX : IComparable
        where TY : IComparable
    {
        [MethodDeclaration]
        void Append(TX x, TY open, TY high, TY low, TY close);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        [MethodDeclaration]
        void Update(int index, TY open, TY high, TY low, TY close);

        [MethodDeclaration]
        void Update(int index, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);

        [MethodDeclaration]
        void Insert(int index, TX x, TY open, TY high, TY low, TY close);

        [MethodDeclaration]
        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> openValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues, IEnumerable<TY> closeValues);
    }
}