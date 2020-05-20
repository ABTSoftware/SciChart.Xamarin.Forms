using System;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public partial class FastLineRenderableSeries : CrossPlatformRenderableSeriesBase, IFastLineRenderableSeries
    {                
        public FastLineRenderableSeries() : base(DependencyService.Get<INativeSciChartObjectFactory>().NewFastLineRenderableSeries())
        {

        }               
    }
}