using System.Collections.Specialized;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Visuals.Annotations;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.RenderableSeries;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface
    {        
        AxisCollection XAxes { get; set; }
        AxisCollection YAxes { get; set; }
        RenderableSeriesCollection RenderableSeries { get; set; }
        System.Collections.ObjectModel.ObservableCollection<IAnnotation> Annotations { get; set; }
    }

    public class SciChartSurface : View, ISciChartSurface
    {        
        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty XAxesProperty = BindableProperty.Create("XAxes", typeof(AxisCollection), typeof(SciChartSurface), null, BindingMode.Default, null, OnXAxesDependencyPropertyChanged, null, null, (s) =>
        {
            var c = new AxisCollection();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        /// <summary>
        /// Defines the YAxes BindableProperty
        /// </summary>
        public static readonly BindableProperty YAxesProperty = BindableProperty.Create("YAxes", typeof(AxisCollection), typeof(SciChartSurface), null, BindingMode.Default, null, OnYAxesDependencyPropertyChanged, null, null, (s) =>
        {
            var c = new AxisCollection();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(RenderableSeriesCollection), typeof(SciChartSurface), null, BindingMode.Default, null, OnRenderableSeriesDependencyPropertyChanged, null, null,
            (s) =>
            {
                var c = new RenderableSeriesCollection();
                c.CollectionChanged += ((SciChartSurface) s).OnAnyCollectionChanged;
                return c;
            });        

        /// <summary>
        /// Defines the RenderableSeries BindableProperty
        /// </summary>
        public static readonly BindableProperty AnnotationsProperty = BindableProperty.Create("Annotations", typeof(System.Collections.ObjectModel.ObservableCollection<IAnnotation>), typeof(SciChartSurface), null, BindingMode.Default, null, null, null, null, (s) =>
        {
            var c = new System.Collections.ObjectModel.ObservableCollection<IAnnotation>();
            c.CollectionChanged += ((SciChartSurface)s).OnAnyCollectionChanged;
            return c;
        });

        public SciChartSurface()
        {
            this.BindingContextChanged += (s, e) => PropagateBindingContext();
        }

        public AxisCollection YAxes
        {
            get => (AxisCollection)GetValue(YAxesProperty);
            set => SetValue(YAxesProperty, value);
        }

        public AxisCollection XAxes
        {
            get => (AxisCollection)GetValue(XAxesProperty); 
            set => SetValue(XAxesProperty, value);
        }

        public RenderableSeriesCollection RenderableSeries
        {
            get => (RenderableSeriesCollection)GetValue(RenderableSeriesProperty);
            set => SetValue(RenderableSeriesProperty, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<IAnnotation> Annotations
        {
            get => (System.Collections.ObjectModel.ObservableCollection<IAnnotation>)GetValue(AnnotationsProperty);
            set => SetValue(AnnotationsProperty, value);
        }

        private static void OnRenderableSeriesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IRenderableSeries>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }

        private static void OnXAxesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IAxis>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }
        private static void OnYAxesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IAxis>(bindable, oldvalue, newvalue, ((SciChartSurface)bindable).OnAnyCollectionChanged);
        }

        private static void WireUpCollectionChanged<T>(BindableObject bindable, object oldvalue, object newvalue, NotifyCollectionChangedEventHandler handler)
        {
            var scs = ((SciChartSurface)bindable);
            var oldCollection = oldvalue as System.Collections.ObjectModel.ObservableCollection<T>;
            var newCollection = newvalue as System.Collections.ObjectModel.ObservableCollection<T>;

            if (oldCollection != null)
            {
                oldCollection.CollectionChanged -= handler;
            }
            if (newCollection != null)
            {
                newCollection.CollectionChanged += handler;
            }

            scs.OnAnyCollectionChanged(newCollection, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnAnyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Reset) PropagateBindingContext();
        }

        private void PropagateBindingContext()
        {
            RenderableSeries.ForEachDo(x => x.Cast<IBindingContextProvider>().BindingContext = BindingContext);
            XAxes.ForEachDo(x => x.Cast<IBindingContextProvider>().BindingContext = BindingContext);
            YAxes.ForEachDo(x => x.Cast<IBindingContextProvider>().BindingContext = BindingContext);
            Annotations.ForEachDo(x => x.Cast<IBindingContextProvider>().BindingContext = BindingContext);       
        }
    }
}
