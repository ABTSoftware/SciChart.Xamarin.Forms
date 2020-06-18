using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("XyyDataSeries", "XyyDataSeries", typeof(IXDataSeries))]
    [GenericParamsDeclaration(new[] { "TX", "TY" }, new Type[] { typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject]
    public interface IXyyDataSeries<TX, TY> : IXDataSeries
        where TX : IComparable
        where TY : IComparable
    {
        [MethodDeclaration]
        void Append(TX x, TY y, TY y1);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        [MethodDeclaration]
        void UpdateXyy1At(int index, TX x, TY y, TY y1);

        [MethodDeclaration]
        void UpdateXAt(int index, TX x);

        [MethodDeclaration]
        void UpdateYAt(int index, TY y);

        [MethodDeclaration]
        void UpdateY1At(int index, TY y1);

        [MethodDeclaration]
        void UpdateRangeXyy1At(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);

        [MethodDeclaration]
        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        [MethodDeclaration]
        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        [MethodDeclaration]
        void UpdateRangeY1At(int index, IEnumerable<TY> y1Values);

        [MethodDeclaration]
        void Insert(int index, TX x, TY y, TY y1);

        [MethodDeclaration]
        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TY> y1Values);
    }
}