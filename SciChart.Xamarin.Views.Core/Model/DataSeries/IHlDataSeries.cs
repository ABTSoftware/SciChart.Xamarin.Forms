using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("HlDataSeries", "HlDataSeries", typeof(IXDataSeries))]
    [GenericParamsDeclaration(new[] { "TX", "TY" }, new Type[] { typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject]
    public interface IHlDataSeries<TX, TY> : IXDataSeries
        where TX : IComparable
        where TY : IComparable
    {
        [MethodDeclaration]
        void Append(TX x, TY y, TY high, TY low);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        [MethodDeclaration]
        void Update(int index, TY y, TY high, TY low);

        [MethodDeclaration]
        void Update(int index, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);

        [MethodDeclaration]
        void Insert(int index, TX x, TY y, TY high, TY low);

        [MethodDeclaration]
        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> highValues, IEnumerable<TY> lowValues);
    }
}