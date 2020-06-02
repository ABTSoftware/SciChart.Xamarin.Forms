using System;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Drawing
{
    [ClassDeclaration("LinearGradientBrushStyle", typeof(IBrushStyle))]
    [InjectNativeSciChartObject(
        new[] { "x1", "y1", "x2", "y2", "startColor", "endColor" },
        new Type[] { typeof(float), typeof(float), typeof(float), typeof(float), typeof(Color), typeof(Color) })]
    public interface ILinearGradientBrushStyle : IBrushStyle
    {
        
    }
}