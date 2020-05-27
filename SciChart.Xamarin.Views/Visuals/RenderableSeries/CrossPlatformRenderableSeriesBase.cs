using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public abstract partial class CrossPlatformRenderableSeriesBase : View, IRenderableSeries, IBindingContextProvider
    {
        protected CrossPlatformRenderableSeriesBase(IRenderableSeries nativeRenderableSeries)
        {
            _nativeSciChartObject = nativeRenderableSeries.NativeSciChartObject;
        }
    }
}