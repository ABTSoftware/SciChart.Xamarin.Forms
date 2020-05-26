using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{

    [XamarinFormsWrapperDefinition("CrossPlatformDataSeriesBase")]
    [AbstractClassDefinition]
    [ClassDeclaration("DataSeries", null)]
    public interface IDataSeries : INativeSciChartObjectWrapper
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
        /// New to v3.3: when AcceptsUnsortedData is false, the DataSeries with throw an InvalidOperationException if unsorted data is appended. Unintentional unsorted data can result in much slower performance. 
        /// To disable this check, set AcceptsUnsortedData = true. 
        /// </summary>        
        [PropertyDeclaration]
        bool AcceptsUnsortedData { get; set; }

        /// <summary>
        /// Clears the series, resetting internal lists to zero size.
        /// </summary>
        void Clear();
    }
}
