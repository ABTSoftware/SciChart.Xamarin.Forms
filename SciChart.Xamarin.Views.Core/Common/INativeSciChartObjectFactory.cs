using System;
using System.Drawing;
using SciChart.Xamarin.Views.Drawing;
using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Core.Common
{
    [SciChartObjectFactory]
    public interface INativeSciChartObjectFactory
    {
        #region RenderableSeries

        IFastLineRenderableSeries NewFastLineRenderableSeries();
        IFastCandlestickRenderableSeries NewFastCandlestickRenderableSeries();

        #endregion

        INumericAxis NewNumericAxis();

        #region DataSeries

        IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable;
        IOhlcDataSeries<TX, TY> NewOhlcDataSeries<TX, TY>() where TX : IComparable where TY : IComparable;

        #endregion

        IDoubleRange NewDoubleRange(double min, double max);

        IDoubleRange NewDoubleRange();

        IBoxAnnotation NewBoxAnnotation();

        #region Modifiers
        IZoomPanModifier NewZoomPanModifier();
        IPinchZoomModifier NewPinchZoomModifier();
        ITooltipModifier NewTooltipModifier();
        IZoomExtentsModifier NewZoomExtentsModifier();
        IModifierGroup NewModifierGroup();

        #endregion

        #region Style
        ISolidPenStyle NewSolidPenStyle(Color color, float thickness, bool antiAliasing, float[] strokeDashArray);

        ISolidBrushStyle NewSolidBrushStyle(Color color);

        ILinearGradientBrushStyle NewLinearGradientBrushStyle(float x0, float y0, float x1, float y1, Color startColor, Color endColor);

        IFontStyle NewFontStyle(float textSize, Color textColor);

        #endregion
    }
}