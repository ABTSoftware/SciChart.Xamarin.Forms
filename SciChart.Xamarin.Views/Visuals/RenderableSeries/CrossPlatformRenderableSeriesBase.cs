using System;
using System.Diagnostics;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Generation;
using SciChart.Xamarin.Views.Model.DataSeries;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public abstract class CrossPlatformRenderableSeriesBase : View, IRenderableSeries, IBindingContextProvider
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
        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create("StrokeThickness", typeof(float), typeof(SciChartSurface), 1f, BindingMode.Default, null, OnStrokeThicknessPropertyChanged, null, null, null);

        /// <summary>
        /// Defines the DataSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty DataSeriesProperty = BindableProperty.Create("DataSeries", typeof(IDataSeries), typeof(SciChartSurface), null, BindingMode.Default, null, OnDataSeriesPropertyChanged, null, null, null);        

        protected CrossPlatformRenderableSeriesBase(IRenderableSeries nativeRenderableSeries)
        {
            NativeSciChartObject = nativeRenderableSeries.NativeSciChartObject;

            this.BindingContextChanged += (s, e) =>
            {
                Debug.WriteLine("Binding Context changed for " + GetType().Name);
            };
        }

        public INativeSciChartObject NativeSciChartObject { get; }

        public string XAxisId
        {
            get => (string)GetValue(XAxisIdProperty);
            set => SetValue(XAxisIdProperty, value);
        }

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

        public float StrokeThickness
        {
            get => (float)GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        [PropertyDeclaration("DataSeries")]
        public IDataSeries DataSeries
        {
            get => (IDataSeries)GetValue(DataSeriesProperty);
            set => SetValue(DataSeriesProperty, value);
        }

        private static void OnXAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).XAxisId = (string)newvalue;
        }

        private static void OnYAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).YAxisId = (string)newvalue;
        }
        private static void OnStrokePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).Stroke = (Color)newvalue;
        }
        private static void OnStrokeThicknessPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).StrokeThickness = (int)newvalue;
        }

        private static void OnDataSeriesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).DataSeries = (IDataSeries)newvalue;
        }

    }
}