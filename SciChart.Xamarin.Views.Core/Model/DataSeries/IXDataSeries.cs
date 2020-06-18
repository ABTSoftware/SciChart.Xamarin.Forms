using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [AbstractClassDefinition]
    [ClassDeclaration("XDataSeries", typeof(IDataSeries))]
    public interface IXDataSeries : IDataSeries
    {
        [MethodDeclaration]
        void RemoveAt(int index);

        [MethodDeclaration]
        [NativeMethodConverterDeclaration(null, null, null, "RemoveRangeAt")]
        void RemoveRange(int startIndex, int count);
    }
}