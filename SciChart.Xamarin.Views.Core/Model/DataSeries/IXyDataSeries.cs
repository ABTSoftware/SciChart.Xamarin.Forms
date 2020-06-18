using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("XyDataSeries", "XyDataSeries", typeof(IXDataSeries))]
    [GenericParamsDeclaration(new []{"TX", "TY"}, new Type[]{typeof(IComparable), typeof(IComparable)})]
    [InjectNativeSciChartObject]
    public interface IXyDataSeries<TX,TY> : IXDataSeries 
        where TX:IComparable 
        where TY:IComparable
    {
        /// <summary>
        /// Appends an X, Y point to the series.
        /// </summary>
        /// <param name="x">The X Value.</param>
        /// <param name="y">The Y Value.</param>
        [MethodDeclaration]
        void Append(TX x, TY y);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues);

        [MethodDeclaration]
        void UpdateXyAt(int index, TX x, TY y);

        [MethodDeclaration]
        void UpdateXAt(int index, TX x);

        [MethodDeclaration]
        void UpdateYAt(int index, TY y);

        [MethodDeclaration]
        void UpdateRangeXyAt(int index, IEnumerable<TX> xValues, IEnumerable<TY> yValues);

        [MethodDeclaration]
        void UpdateRangeXAt(int index, IEnumerable<TX> xValues);

        [MethodDeclaration]
        void UpdateRangeYAt(int index, IEnumerable<TY> yValues);

        [MethodDeclaration]
        void Insert(int index, TX x, TY y);

        [MethodDeclaration]
        void InsertRange(int startIndex, IEnumerable<TX> xValues, IEnumerable<TY> yValues);
    }
}