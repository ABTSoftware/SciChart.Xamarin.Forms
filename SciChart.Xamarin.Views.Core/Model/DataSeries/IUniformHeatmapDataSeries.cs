using System;
using System.Collections.Generic;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.Views.Model.DataSeries
{
    [ClassDeclaration("UniformHeatmapDataSeries", "UniformHeatmapDataSeries", typeof(IDataSeries))]
    [GenericParamsDeclaration(new[] { "TX", "TY", "TZ" }, new Type[] { typeof(IComparable), typeof(IComparable), typeof(IComparable) })]
    [InjectNativeSciChartObject(new []{"xSize", "ySize"}, new []{typeof(int), typeof(int)})]
    public interface IUniformHeatmapDataSeries<TX, TY, TZ> : IDataSeries where TX : IComparable where TY : IComparable  where TZ : IComparable
    {
        [PropertyDeclaration]
        TX StartX { get; set; }

        [PropertyDeclaration]
        TY StartY { get; set; }

        [PropertyDeclaration]
        TX StepX { get; set; }

        [PropertyDeclaration]
        TY StepY { get; set; }

        // TODO: Change signature in Android and implement in iOS
        // [MethodDeclaration]
        // void UpdateZAt(int xIndex, int yIndex, TZ value);

        [MethodDeclaration]
        void UpdateZValues(IEnumerable<TZ> values);

        [MethodDeclaration]
        void UpdateRangeZAt(int xIndex, int yIndex, IEnumerable<TZ> values);
    }
}