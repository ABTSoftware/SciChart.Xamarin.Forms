using System;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

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