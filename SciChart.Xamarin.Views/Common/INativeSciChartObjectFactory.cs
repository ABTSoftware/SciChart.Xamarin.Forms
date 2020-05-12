using System;
using SciChart.Xamarin.Views.Generation;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;

namespace SciChart.Xamarin.Views.Common
{
    [SciChartObjectFactory]
    public interface INativeSciChartObjectFactory
    {
        [FactoryMethod(typeof(FastLineRenderableSeries))]
        IFastLineRenderableSeries NewFastLineRenderableSeries();

        [FactoryMethod(typeof(NumericAxis))]
        INumericAxis NewNumericAxis();

        [FactoryMethod(typeof(XyDataSeries<,>))]
        IXyDataSeries<TX, TY> NewXyDataSeries<TX, TY>() where TX : IComparable where TY : IComparable;

        [FactoryMethod(typeof(DoubleRange))]
        IDoubleRange NewDoubleRange(double min, double max);

        [FactoryMethod(typeof(DoubleRange))]
        IDoubleRange NewDoubleRange();
    }
}