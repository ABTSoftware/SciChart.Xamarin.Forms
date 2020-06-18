using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("XyzDataSeries", "XyzDataSeries", typeof(IXDataSeries))]
    [GenericParamsDeclaration(new[] {"TX", "TY", "TZ"}, new Type[] {typeof(IComparable), typeof(IComparable), typeof(IComparable)})]
    [InjectNativeSciChartObject]
    public interface IXyzDataSeries<TX, TY, TZ> : IXDataSeries
        where TX : IComparable
        where TY : IComparable
        where TZ : IComparable
    {
        [MethodDeclaration]
        void Append(TX x, TY y, TZ z);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);

        [MethodDeclaration]
        void Insert(int index, TX x, TY y, TZ z);

        [MethodDeclaration]
        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);

        [MethodDeclaration]
        void UpdateXyzAt(int index, TX x, TY y, TZ z);

        [MethodDeclaration]
        void UpdateXAt(int index, TX x);

        [MethodDeclaration]
        void UpdateYAt(int index, TY y);

        [MethodDeclaration]
        void UpdateZAt(int index, TZ z);

        [MethodDeclaration]
        void UpdateRangeXyzAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);

        [MethodDeclaration]
        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        [MethodDeclaration]
        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        [MethodDeclaration]
        void UpdateRangeZAt(int index, IEnumerable<TZ> zValues);
    }
}