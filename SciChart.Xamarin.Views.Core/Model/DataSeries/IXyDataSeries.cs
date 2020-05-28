using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("XyDataSeries", "XyDataSeries", typeof(IDataSeries))]
    [GenericParamsDeclaration(new []{"TX", "TY"}, new Type[]{typeof(IComparable), typeof(IComparable)})]
    [InjectNativeSciChartObject]
    public interface IXyDataSeries<TX,TY> : IDataSeries 
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
    }
}