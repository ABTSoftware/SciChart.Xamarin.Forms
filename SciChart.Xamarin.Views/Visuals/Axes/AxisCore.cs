using System;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;
using SciChart.Xamarin.Views.Model;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals.Axes
{
    [InjectAndroidContext]
    public abstract class AxisCore : View, IAxisCore, IBindingContextProvider
    {

        public static string DefaultAxisId = "DefaultAxisId";

        protected AxisCore(IAxisCore nativeAxis)
        {
            NativeSciChartObject = nativeAxis.NativeSciChartObject;
        }

        public INativeSciChartObject NativeSciChartObject { get; }

        /// <summary>
        /// Defines the XAxisId BindableProperty
        /// </summary>
        public static readonly BindableProperty AxisIdProperty = BindableProperty.Create("AxisId", typeof(string), typeof(AxisCore), AxisCore.DefaultAxisId, BindingMode.Default, null, OnAxisIdPropertyChanged, null, null, null);

        public static readonly BindableProperty AxisTitleProperty = BindableProperty.Create("AxisTitle", typeof(string), typeof(AxisCore), null, BindingMode.Default, null, OnAxisTitlePropertyChanged, null, null, null);        

        public static readonly BindableProperty FlipCoordinatesProperty = BindableProperty.Create("FlipCoordinates", typeof(bool), typeof(AxisCore), false, BindingMode.Default, null, OnFlipCoordinatesPropertyChanged, null, null, null);        

        public static readonly BindableProperty TextFormattingProperty = BindableProperty.Create("TextFormatting", typeof(string), typeof(AxisCore), "0:00", BindingMode.Default, null, OnTextFormattingPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawMinorTicksProperty = BindableProperty.Create("DrawMinorTicks", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawMinorTicksPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawLabelsProperty = BindableProperty.Create("DrawLabels", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawLabelsPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawMajorTicksProperty = BindableProperty.Create("DrawMajorTicks", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawMajorTicksPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawMajorGridLinesProperty = BindableProperty.Create("DrawMajorGridLines", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawMajorGridLinesPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawMinorGridLinesProperty = BindableProperty.Create("DrawMinorGridLines", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawMinorGridLinesPropertyChanged, null, null, null);        

        public static readonly BindableProperty DrawMajorBandsProperty = BindableProperty.Create("DrawMajorBands", typeof(bool), typeof(AxisCore), true, BindingMode.Default, null, OnDrawMajorBandsPropertyChanged, null, null, null);        

        public static readonly BindableProperty AxisBandsFillProperty = BindableProperty.Create("AxisBandsFill", typeof(Color), typeof(AxisCore), Color.Default, BindingMode.Default, null, OnAxisBandsFillPropertyChanged, null, null, null);        

        public static readonly BindableProperty AutoRangeProperty = BindableProperty.Create("AutoRange", typeof(AutoRange), typeof(AxisCore), AutoRange.Once, BindingMode.Default, null, OnAutoRangePropertyPropertyChanged, null, null, null);        

        public static readonly BindableProperty VisibleRangeProperty = BindableProperty.Create("VisibleRange", typeof(IRange), typeof(AxisCore), null, BindingMode.Default, null, OnVisibleRangeProperty, null, null, null);

        public static readonly BindableProperty GrowByProperty = BindableProperty.Create("GrowBy", typeof(IRange), typeof(AxisCore), null, BindingMode.Default, null, OnGrowByPropertyChanged, null, null, null);

        public event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;


        public string AxisTitle
        {
            get => (string) GetValue(AxisTitleProperty);
            set => SetValue(AxisTitleProperty, value);
        }

        public bool FlipCoordinates
        {
            get => (bool)GetValue(FlipCoordinatesProperty);
            set => SetValue(FlipCoordinatesProperty, value);
        }

        public string TextFormatting
        {
            get => (string)GetValue(TextFormattingProperty);
            set => SetValue(TextFormattingProperty, value);
        }

        public bool DrawMinorTicks
        {
            get => (bool)GetValue(DrawMinorTicksProperty);
            set => SetValue(DrawMinorTicksProperty, value);
        }

        public bool DrawLabels
        {
            get => (bool)GetValue(DrawLabelsProperty);
            set => SetValue(DrawLabelsProperty, value);
        }

        public bool DrawMajorTicks
        {
            get => (bool)GetValue(DrawMajorTicksProperty);
            set => SetValue(DrawMajorTicksProperty, value);
        }

        public bool DrawMajorGridLines
        {
            get => (bool)GetValue(DrawMajorGridLinesProperty);
            set => SetValue(DrawMajorGridLinesProperty, value);
        }

        public bool DrawMinorGridLines
        {
            get => (bool)GetValue(DrawMinorGridLinesProperty);
            set => SetValue(DrawMinorGridLinesProperty, value);
        }

        public bool DrawMajorBands
        {
            get => (bool)GetValue(DrawMajorBandsProperty);
            set => SetValue(DrawMajorBandsProperty, value);
        }

        [PropertyDeclaration("BrushStyle", "AxisBandsStyle")]
        public Color AxisBandsFill
        {
            get => (Color)GetValue(AxisBandsFillProperty);
            set => SetValue(AxisBandsFillProperty, value);
        }

        [PropertyDeclaration("AutoRange")]
        public AutoRange AutoRange
        {
            get => (AutoRange)GetValue(AutoRangeProperty);
            set => SetValue(AutoRangeProperty, value);
        }

        public string AxisId
        {
            get => (string) GetValue(AxisIdProperty);
            set => SetValue(AxisIdProperty, value);
        }

        [PropertyDeclaration("Range")]
        public IRange VisibleRange
        {
            get => (IRange)GetValue(VisibleRangeProperty);
            set => SetValue(VisibleRangeProperty, value);
        }

        [PropertyDeclaration("Range")]
        public IRange GrowBy
        {
            get => (IRange) GetValue(GrowByProperty);
            set => SetValue(GrowByProperty, value);
        }

        private static void OnAxisIdPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().AxisId = (string)newvalue;
        }

        private static void OnAxisTitlePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().AxisTitle = (string)newvalue;
        }
        private static void OnFlipCoordinatesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().FlipCoordinates = (bool)newvalue;
        }
        private static void OnTextFormattingPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().TextFormatting = (string)newvalue;
        }

        private static void OnDrawMinorTicksPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawMinorTicks = (bool)newvalue;
        }

        private static void OnDrawLabelsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawLabels = (bool)newvalue;
        }

        private static void OnDrawMajorTicksPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawMajorTicks = (bool)newvalue;
        }

        private static void OnDrawMajorGridLinesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawMajorGridLines = (bool)newvalue;
        }

        private static void OnDrawMinorGridLinesPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawMinorGridLines = (bool)newvalue;
        }

        private static void OnDrawMajorBandsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().DrawMajorBands = (bool)newvalue;
        }

        private static void OnAxisBandsFillPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().AxisBandsFill = (Color)newvalue;
        }

        private static void OnAutoRangePropertyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().AutoRange = (AutoRange)newvalue;
        }

        private static void OnVisibleRangeProperty(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().VisibleRange = (IRange)newvalue;
        }

        private static void OnGrowByPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((AxisCore)bindable).NativeSciChartObject.Cast<IAxisCore>().GrowBy = (IDoubleRange)newvalue;
        }
    }
}