using System;
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
        IFastLineRenderableSeries NewFastLineRenderableSeries();

        INumericAxis NewNumericAxis();

        IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable;

        IDoubleRange NewDoubleRange(double min, double max);

        IDoubleRange NewDoubleRange();

        IBoxAnnotation NewBoxAnnotation();

        IZoomPanModifier NewZoomPanModifier();
    }
}