using System;
using System.Drawing;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Drawing
{
    [ClassDeclaration("SolidBrushStyle", typeof(IBrushStyle))]
    [InjectNativeSciChartObject(new[] {"color"}, new Type[] {typeof(Color)})]
    public interface ISolidBrushStyle : IBrushStyle
    {
        
    }
}