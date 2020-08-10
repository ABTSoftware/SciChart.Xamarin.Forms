using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Core.Common
{
    [EnumDefinition("AndroidGravityFlags", "SCIAlignment")]
    public enum VerticalAlignment
    {
        [EnumValueDefinition("FillVertical")]
        Fill,
        [EnumValueDefinition("CenterVertical")]
        Center,
        Top,
        Bottom,
    }
}