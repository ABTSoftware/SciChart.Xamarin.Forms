using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.PointMarkers;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    [ClassDeclaration("BaseRenderableSeries", "SCIRenderableSeriesBase", typeof(IRenderableSeriesCore))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("RenderableSeriesBase")]
    public interface IRenderableSeries : IRenderableSeriesCore
    {
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

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PenStyle")]
        IPenStyle StrokeStyle { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("PointMarker")]
        IPointMarker PointMarker { get; set; }
    }
}