using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [AbstractClassDefinition]
    [ClassDeclaration("DataSeries", typeof(IDataSeriesCore))]
    public interface IDataSeries : IDataSeriesCore
    {
        /// <summary>
        /// Defines the value indicating whether this series accepts unsorted data. If it is false, the DataSeries will throw exception is unsorted data is appended. U
        /// To disable this check, set AcceptsUnsortedData = true. 
        /// </summary>        
        [PropertyDeclaration]
        bool AcceptsUnsortedData { get; set; }

        /// <summary>
        /// Gets whether the series behaves as a FIFO.
        /// </summary>
        [PropertyDeclaration]
        bool IsFifo { get; }

        /// <summary>
        /// Defines the size of the FIFO buffer. If null, then the series is unlimited. If a value is set, when the point count reaches this value, older points will be discarded.
        /// </summary>
        [PropertyDeclaration]
        [NativePropertyConverterDeclaration("FifoCapacity")]
        int? FifoCapacity { get; set; }
    }
}
