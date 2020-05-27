using CoreGraphics;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSFactory))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public partial class iOSFactory : INativeSciChartObjectFactory
    {
    }

    public partial class SolidPenStyleiOS
    {
        public SolidPenStyleiOS(System.Drawing.Color color, float thickness, bool antiAliasing, float[] strokeDashArray)
            : base(color.ColorFromXamarin(), thickness, antiAliasing, strokeDashArray)
        {

        }
    }

    public partial class SolidBrushStyleiOS
    {
        public SolidBrushStyleiOS(in System.Drawing.Color colorCode) : base(colorCode.ColorFromXamarin())
        {
        }
    }

    public partial class LinearGradientBrushStyleiOS
    {
        public LinearGradientBrushStyleiOS(float x0, float y0, float x1, float y1, System.Drawing.Color startColor,
            System.Drawing.Color endColor) : base(new CGPoint(x0, y0), new CGPoint(x1, y1),
            startColor.ColorFromXamarin(), endColor.ColorFromXamarin())
        {

        }
    }

    public partial class FontStyleiOS
    {
        public FontStyleiOS(float textSize, System.Drawing.Color textColor) : base(textSize, textColor.ColorFromXamarin())
        {

        }
    }
}
