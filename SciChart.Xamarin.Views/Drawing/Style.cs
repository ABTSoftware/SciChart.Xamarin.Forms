namespace SciChart.Xamarin.Views.Drawing
{
    public partial class FontStyle
    {
        public FontStyle(IFontStyle style)
        {
            _nativeSciChartObject = style.NativeSciChartObject;
        }
    }

    public partial class PenStyle
    {
        protected PenStyle(IPenStyle style)
        {
            _nativeSciChartObject = style.NativeSciChartObject;
        }
    }

    public partial class BrushStyle
    {
        protected BrushStyle(IBrushStyle style) 
        {
            _nativeSciChartObject = style.NativeSciChartObject;
        }
    }

    public partial class SolidPenStyle
    {
        public SolidPenStyle(ISolidPenStyle style) : base(style)
        {

        }
    }

    public partial class SolidBrushStyle : BrushStyle
    {
        public SolidBrushStyle(ISolidBrushStyle style) : base(style)
        {

        }
    }
}