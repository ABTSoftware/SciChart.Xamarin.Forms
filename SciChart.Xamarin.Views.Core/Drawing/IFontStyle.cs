using System;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Drawing
{
    [ClassDeclaration("FontStyle", null)]
    [InjectNativeSciChartObject(new[] {"textSize", "textColor"}, new[] { typeof(float), typeof(Color) })]
    public interface IFontStyle : INativeSciChartObjectWrapper
    {
        
    }
}