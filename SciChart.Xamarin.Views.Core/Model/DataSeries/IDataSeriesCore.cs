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
        /// Gets whether the DataSeries has values(is not empty).
        /// </summary>
        [PropertyDeclaration]
        bool HasValues { get; }
        
        /// <summary>
        /// Clears the series, resetting internal lists to zero size.
        /// </summary>
        [MethodDeclaration]
        void Clear();

        /// <summary>
        /// Clears the series, resetting internal lists to zero size.
        /// </summary>
        /// <param name="retainCapacity"></param>
        [MethodDeclaration]
        [NativeMethodConverterDeclaration(null, null, null, "ClearWithRetainCapacity")]
        void Clear(bool retainCapacity);
    }
}