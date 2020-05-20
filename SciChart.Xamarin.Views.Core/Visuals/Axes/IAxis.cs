
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [InjectAndroidContext]
    [AbstractClassDefinition]
    [ClassDeclaration("AxisBase", "SCIAxisBase", typeof(IAxisCore))]
    [XamarinFormsWrapperDefinition("AxisBase")]
    public interface IAxis : IAxisCore
    {
        /// <summary>
        /// Gets or sets the Alignment for this axis, e.g. Left, Right, Bottom, Top
        /// </summary>
        // AxisAlignment AxisAlignment { get; set; }
    }
}