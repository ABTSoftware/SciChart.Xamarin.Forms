using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [AbstractClassDefinition]
    [ClassDeclaration("DataSeries", typeof(IDataSeriesCore))]
    public interface IDataSeries : IDataSeriesCore
    {
        /// <summary>
        /// New to v3.3: when AcceptsUnsortedData is false, the DataSeries with throw an InvalidOperationException if unsorted data is appended. Unintentional unsorted data can result in much slower performance. 
        /// To disable this check, set AcceptsUnsortedData = true. 
        /// </summary>        
        [PropertyDeclaration]
        bool AcceptsUnsortedData { get; set; }
    }
}
