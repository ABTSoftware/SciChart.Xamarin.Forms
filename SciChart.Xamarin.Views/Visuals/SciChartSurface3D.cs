using System.Collections.Specialized;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Axes3D;
using SciChart.Xamarin.Views.Visuals.RenderableSeries3D;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public class SciChartSurface3D : NativeViewProvider, ISciChartSurface3D
    {
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnXAxisDependencyPropertyChanged, null, null, null);

        public static readonly BindableProperty YAxisProperty = BindableProperty.Create("YAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnYAxisDependencyPropertyChanged, null, null, null);

        public static readonly BindableProperty ZAxisProperty = BindableProperty.Create("ZAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnZAxisDependencyPropertyChanged, null, null, null);

        public static readonly BindableProperty RenderableSeriesProperty = BindableProperty.Create("RenderableSeries", typeof(RenderableSeries3DCollection), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnRenderableSeriesDependencyPropertyChanged, null, null,
            (s) =>
            {
                var c = new RenderableSeries3DCollection();
                c.CollectionChanged += ((SciChartSurface3D)s).OnAnyCollectionChanged;
                return c;
            });

        public static readonly BindableProperty ChartModifiersProperty = BindableProperty.Create("ChartModifiers", typeof(ChartModifier3DCollection), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnChartModifiersDependencyPropertyChanged, null, null, (s) =>
        {
            var c = new ChartModifier3DCollection();
            c.CollectionChanged += ((SciChartSurface3D)s).OnAnyCollectionChanged;
            return c;
        });

        public SciChartSurface3D()
        {
            this.BindingContextChanged += (s, e) => PropagateBindingContext();
        }

        public IAxis3D YAxis
        {
            get => (IAxis3D)GetValue(YAxisProperty);
            set => SetValue(YAxisProperty, value);
        }

        public IAxis3D XAxis
        {
            get => (IAxis3D)GetValue(XAxisProperty);
            set => SetValue(XAxisProperty, value);
        }

        public IAxis3D ZAxis
        {
            get => (IAxis3D)GetValue(ZAxisProperty);
            set => SetValue(ZAxisProperty, value);
        }

        public RenderableSeries3DCollection RenderableSeries
        {
            get => (RenderableSeries3DCollection)GetValue(RenderableSeriesProperty);
            set => SetValue(RenderableSeriesProperty, value);
        }

        public ChartModifier3DCollection ChartModifiers
        {
            get => (ChartModifier3DCollection)GetValue(ChartModifiersProperty);
            set => SetValue(ChartModifiersProperty, value);
        }


        private static void OnXAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnYAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnZAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }

        private static void OnRenderableSeriesDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IRenderableSeries3D>(bindable, oldvalue, newvalue, ((SciChartSurface3D)bindable).OnAnyCollectionChanged);
        }

        private static void OnChartModifiersDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            WireUpCollectionChanged<IChartModifier3D>(bindable, oldvalue, newvalue, ((SciChartSurface3D)bindable).OnAnyCollectionChanged);
        }

        private static void WireUpCollectionChanged<T>(BindableObject bindable, object oldvalue, object newvalue, NotifyCollectionChangedEventHandler handler)
        {
            var scs = ((SciChartSurface3D)bindable);
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
            ChartModifiers.ForEachDo(x => x.Cast<IBindingContextProvider>().BindingContext = BindingContext);
        }
    }
}