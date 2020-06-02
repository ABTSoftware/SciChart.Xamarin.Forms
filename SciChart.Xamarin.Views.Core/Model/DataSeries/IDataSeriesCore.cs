using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [AbstractClassDefinition]
    [ClassDeclaration("DataSeriesCore", null)]
    public interface IDataSeriesCore : INativeSciChartObjectWrapper
    {
        /// <summary>
        /// Gets or sets the name of this series.
        /// </summary>
        [PropertyDeclaration]
        string SeriesName { get; set; }

        /// <summary>
        /// Gets the number of points in this dataseries.
        /// </summary>
        [PropertyDeclaration]
        int Count { get; }


        /// <summary>
        /// Clears the series, resetting internal lists to zero size.
        /// </summary>
        [MethodDeclaration]
        void Clear();
    }
}