﻿using System;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Utility;
using SciChartSurfaceX = SciChart.Xamarin.Views.Visuals.SciChartSurface;

namespace SciChart.Xamarin.Android.Renderer
{
    public class SciChartSurfaceAndroidPropertyMapper : PropertyMapper<SciChartSurfaceX, SciChartSurface>
    {
        private RenderableSeriesCollectionAndroid _rSeriesCollection;
        private AxisCollectionAndroid _xAxesCollection;
        private AxisCollectionAndroid _yAxesCollection;

        public SciChartSurfaceAndroidPropertyMapper(SciChartSurfaceX sourceControl, Charting.Visuals.SciChartSurface targetControl) : base(sourceControl, targetControl)
        {
            this.Add(SciChartSurfaceX.RenderableSeriesProperty.PropertyName, OnRenderableSeriesChanged);
            this.Add(SciChartSurfaceX.ChartTitleProperty.PropertyName, (s, d) => { }); // TODO: ChartTitle not supported in android
//            this.Add(SciChartSurfaceX.BackgroundColorProperty.PropertyName, (s, d) => d.Background = new SolidColorBrush(ColorUtil.FromXamarinColor(s.BackgroundColor)));
//            this.Add(SciChartSurfaceX.ForegroundColorProperty.PropertyName, (s, d) => d.Foreground = new SolidColorBrush(ColorUtil.FromXamarinColor(s.ForegroundColor)));
            this.Add(SciChartSurfaceX.XAxesProperty.PropertyName, OnXAxesChanged);
            this.Add(SciChartSurfaceX.YAxesProperty.PropertyName, OnYAxesChanged);
            this.Init();
        }

        private void OnRenderableSeriesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _rSeriesCollection?.Dispose();
            _rSeriesCollection = new RenderableSeriesCollectionAndroid(target.RenderableSeries, source.RenderableSeries);
        }

        private void OnXAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _xAxesCollection?.Dispose();
            _xAxesCollection = new AxisCollectionAndroid(target.XAxes, source.XAxes);
        }

        private void OnYAxesChanged(SciChartSurfaceX source, SciChartSurface target)
        {
            _yAxesCollection?.Dispose();
            _yAxesCollection = new AxisCollectionAndroid(target.YAxes, source.YAxes);
        }
    }
}