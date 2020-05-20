using System.Diagnostics;
using SciChart.Xamarin.Views.Core.Common;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.RenderableSeries
{
    public abstract partial class CrossPlatformRenderableSeriesBase : View, IRenderableSeries, IBindingContextProvider
    {
        // <summary>
        /// Defines the Stroke BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeProperty = BindableProperty.Create("Stroke", typeof(Color), typeof(SciChartSurface), Color.White, BindingMode.Default, null, OnStrokePropertyChanged, null, null, null);

        /// <summary>
        /// Defines the StrokeThickness BindableProperty
        /// </summary>
        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create("StrokeThickness", typeof(float), typeof(SciChartSurface), 1f, BindingMode.Default, null, OnStrokeThicknessPropertyChanged, null, null, null);

        protected CrossPlatformRenderableSeriesBase(IRenderableSeries nativeRenderableSeries)
        {
            NativeSciChartObject = nativeRenderableSeries.NativeSciChartObject;

            this.BindingContextChanged += (s, e) =>
            {
                Debug.WriteLine("Binding Context changed for " + GetType().Name);
            };
        }

        public INativeSciChartObject NativeSciChartObject { get; }

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

        private static void OnStrokePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).Stroke = (Color)newvalue;
        }
        private static void OnStrokeThicknessPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
//            ((IRenderableSeries)((CrossPlatformRenderableSeriesBase)bindable).NativeSciChartObject).StrokeThickness = (int)newvalue;
        }
    }
}