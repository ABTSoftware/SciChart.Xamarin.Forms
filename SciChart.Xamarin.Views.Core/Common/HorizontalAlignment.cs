using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Core.Common
{
    [EnumDefinition("AndroidGravityFlags", "SCIAlignment")]
    public enum HorizontalAlignment
    {
       [EnumValueDefinition("FillHorizontal")]
       Fill,
       [EnumValueDefinition("CenterHorizontal")]
       Center,
       Left,
       Right
    }
}