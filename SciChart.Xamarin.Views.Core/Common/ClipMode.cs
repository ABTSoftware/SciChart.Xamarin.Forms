using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Core.Common
{
    [EnumDefinition]
    public enum ClipMode
    {
        None,
        StretchAtExtents,
        ClipAtMin,
        ClipAtMax,
        ClipAtExtents
    }
}