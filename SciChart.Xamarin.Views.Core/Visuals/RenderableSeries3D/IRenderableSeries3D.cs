using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model.DataSeries3D;
using SciChart.Xamarin.Views.Visuals.PointMarkers3D;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries3D
{
    [ClassDeclaration("BaseRenderableSeries3D", "SCIRenderableSeriesBase3D", typeof(IRenderableSeriesCore))]
    [AbstractClassDefinition]
    [XamarinFormsWrapperDefinition("BaseRenderableSeries3D")]
    public interface IRenderableSeries3D : IRenderableSeriesCore
    {
        /// <summary>
        /// Gets or sets the DataSeries associated with this series
        /// </summary>
        [NativePropertyConverterDeclaration("DataSeries")]
        [BindablePropertyDefinition]

        IDataSeries3D DataSeries { get; set; }

        [NativePropertyConverterDeclaration("PointMarker3D")]
        [BindablePropertyDefinition]

        IPointMarker3D PointMarker { get; set; }
    }
}