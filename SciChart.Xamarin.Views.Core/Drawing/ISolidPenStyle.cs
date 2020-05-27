using System;
using System.Drawing;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Drawing
{
    [ClassDeclaration("SolidPenStyle", typeof(IPenStyle))]
    [InjectNativeSciChartObject(
        new []{"color", "thickness", "antiAliasing", "strokeDashArray"},
        new Type[] { typeof(Color), typeof(float), typeof(bool), typeof(float[])})]
    public interface ISolidPenStyle : IPenStyle
    {
        
    }
}