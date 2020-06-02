using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model.DataSeries;

namespace SciChart.Xamarin.Views.Model.DataSeries3D
{
    [ClassDeclaration("XyzDataSeries3D", "XyzDataSeries3D", typeof(IDataSeries3D))]
    [GenericParamsDeclaration(new[] { "TX", "TY", "TZ" }, new Type[] { typeof(IComparable), typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject]
    public interface IXyzDataSeries3D<TX, TY, TZ> : IDataSeries3D where TX : IComparable where TY : IComparable where TZ : IComparable
    {

        [MethodDeclaration]
        void Append(TX x, TY y, TZ z);

        [MethodDeclaration]
        void Append(IEnumerable<TX> xValues, IEnumerable<TY> yValues, IEnumerable<TZ> zValues);
    }
}