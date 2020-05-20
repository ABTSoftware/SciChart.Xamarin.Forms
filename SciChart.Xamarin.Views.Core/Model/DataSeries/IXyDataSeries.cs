using System;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("XyDataSeries", "XyDataSeries", typeof(IDataSeries))]
    [GenericParamsDeclaration(new []{"TX", "TY"}, new Type[]{typeof(IComparable), typeof(IComparable)})]
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

//        /// <summary>
//        /// Gets the X Values of this series.
//        /// </summary>
//        IList<TX> XValues { get; }
//
//        /// <summary>
//        /// Gets the Y Values of this series.
//        /// </summary>
//        IList<TY> YValues { get; }

    }
}