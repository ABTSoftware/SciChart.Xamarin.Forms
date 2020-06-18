using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("ColorMap", null)]
    [InjectNativeSciChartObject(new string[]{"colors", "stops"}, new []{typeof(Color[]), typeof(float[])} )]
    [InjectNativeSciChartObject(new string[]{"startColor", "endColor"}, new []{typeof(Color), typeof(Color)} )]
    public interface IColorMap : INativeSciChartObjectWrapper
    {
        
    }
}