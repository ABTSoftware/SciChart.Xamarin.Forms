using System;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration(typeof(IFastLineRenderableSeries), "FastLineRenderableSeries", "SCIFastLineRenderableSeries")]
    public class FastLineRenderableSeries : CrossPlatformRenderableSeriesBase, IFastLineRenderableSeries
    {                
        public FastLineRenderableSeries() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewFastLineRenderableSeries())
        {

        }               
    }
}