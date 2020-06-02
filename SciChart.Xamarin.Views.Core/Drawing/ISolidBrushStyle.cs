using System;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Drawing
{
    [ClassDeclaration("SolidBrushStyle", typeof(IBrushStyle))]
    [InjectNativeSciChartObject(new[] {"color"}, new Type[] {typeof(Color)})]
    public interface ISolidBrushStyle : IBrushStyle
    {
        
    }
}