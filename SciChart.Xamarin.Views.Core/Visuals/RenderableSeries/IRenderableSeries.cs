using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model.DataSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("BaseRenderableSeries", "SCIRenderableSeriesBase", typeof(View))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("CrossPlatformRenderableSeriesBase")]
    public interface IRenderableSeries : INativeSciChartObjectWrapper
    {
/*
        /// <summary>
        /// Gets or sets the Stroke. 
        /// </summary>
        /// <remarks>This is used by each series type in different ways. For instance:
        /// <list type="bullet">
        ///     <item><see cref="FastLineRenderableSeries"/> and <see cref="FastImpulseRenderableSeries"/> uses the Stroke to draw the line series</item>
        ///     <item><see cref="FastMountainRenderableSeries"/> uses the Stroke to draw the line over the filled area</item>
        ///     <item><see cref="FastBandRenderableSeries"/> uses the Stroke to draw the first line of the pair</item>
        ///     <item><see cref="FastColumnRenderableSeries"/> uses this property to draw the outline of the columns</item>
        ///     <item><see cref="FastCandlestickRenderableSeries"/>, <see cref="FastOhlcRenderableSeries"/> and <see cref="XyScatterRenderableSeries"/> all ignore this property</item>
        /// </list>
        /// </remarks>
        Color Stroke { get; set; }

        /// <summary>
        /// Gets or sets the StrokeThickness in pixels for this series 
        /// </summary>
        float StrokeThickness { get; set; }
*/

        /// <summary>
        /// Gets or sets the DataSeries associated with this series
        /// </summary>
        [NativePropertyConverterDeclaration("DataSeries")]
        [BindablePropertyDefinition]

        IDataSeries DataSeries { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Y-Axis which this renderable series is measured against
        /// </summary>
        [BindablePropertyDefinition]
        string YAxisId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the X-Axis which this renderable series is measured against
        /// </summary>
        [BindablePropertyDefinition]
        string XAxisId { get; set; }
    }
}