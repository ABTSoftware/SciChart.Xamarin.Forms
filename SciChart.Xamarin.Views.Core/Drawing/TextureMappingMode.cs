using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Drawing
{
    [EnumDefinition]
    public enum TextureMappingMode
    {
        [EnumValueDefinition(null, "Screen")]
        PerScreen,

        [EnumValueDefinition(null, "Primitive")]
        PerPrimitive
    }
}