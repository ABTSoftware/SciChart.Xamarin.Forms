using System;
using System.Diagnostics;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public abstract class CrossPlatformRenderableSeriesBase : View, IRenderableSeries
    {
        /// <summary>
        /// Defines the XAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxisIdProperty = BindableProperty.Create("XAxisId", typeof(string), typeof(SciChartSurface), AxisCore.DefaultAxisId, BindingMode.Default, null, OnXAxisIdPropertyChanged, null, null, null);

        /// <summary>
        /// Defines the YAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxisIdProperty = BindableProperty.Create("YAxisId", typeof(string), typeof(SciChartSurface), AxisCore.DefaultAxisId, BindingMode.Default, null, OnYAxisIdPropertyChanged, null, null, null);

        /// <summary>
        /// Defines the Stroke BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeProperty = BindableProperty.Create("Stroke", typeof(Color), typeof(SciChartSurface), Color.White, BindingMode.Default, null, OnStrokePropertyChanged, null, null, null);

        /// <summary>
        /// Defines the StrokeThickness BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create("StrokeThickness", typeof(int), typeof(SciChartSurface), 1, BindingMode.Default, null, OnStrokeThicknessPropertyChanged, null, null, null);

        /// <summary>
        /// Defines the DataSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty DataSeriesProperty = BindableProperty.Create("DataSeries", typeof(IDataSeries), typeof(SciChartSurface), null, BindingMode.Default, null, OnDataSeriesPropertyChanged, null, null, null);        

        protected CrossPlatformRenderableSeriesBase(INativeRenderableSeries nativeRenderableSeries)
        {
            NativeRenderableSeries = nativeRenderableSeries;

            this.BindingContextChanged += (s, e) =>
            {
                Debug.WriteLine("Binding Context changed for " + GetType().Name);
            };
        }

        public string XAxisId
        {
            get => (string)GetValue(XAxisIdProperty);
            set => SetValue(XAxisIdProperty, value);
        }

        public INativeRenderableSeries NativeRenderableSeries { get; }

        public string YAxisId
        {
            get => (string)GetValue(YAxisIdProperty);
            set => SetValue(YAxisIdProperty, value);
        }

        public Color Stroke
        {
            get => (Color)GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        public int StrokeThickness
        {
            get => (int)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public IDataSeries DataSeries
        {
            get => (IDataSeries)GetValue(DataSeriesProperty);
            set => SetValue(DataSeriesProperty, value);
        }

        private static void OnXAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CrossPlatformRenderableSeriesBase)bindable).NativeRenderableSeries.XAxisId = (string)newvalue;
        }

        private static void OnYAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CrossPlatformRenderableSeriesBase)bindable).NativeRenderableSeries.YAxisId = (string)newvalue;
        }
        private static void OnStrokePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CrossPlatformRenderableSeriesBase)bindable).NativeRenderableSeries.Stroke = (Color)newvalue;
        }
        private static void OnStrokeThicknessPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CrossPlatformRenderableSeriesBase)bindable).NativeRenderableSeries.StrokeThickness = (int)newvalue;
        }

        private static void OnDataSeriesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CrossPlatformRenderableSeriesBase)bindable).NativeRenderableSeries.DataSeries = (IDataSeries)newvalue;
        }
    }
}