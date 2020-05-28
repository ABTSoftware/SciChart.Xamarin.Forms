using SciChart.Xamarin.Views.Visuals.Axes3D;
using Xamarin.Forms;

namespace SciChart.Xamarin.Views.Visuals
{
    public interface ISciChartSurface3D
    {
        IAxis3D XAxis { get; set; }
        IAxis3D YAxis { get; set; }
        IAxis3D ZAxis { get; set; }
    }

    public class SciChartSurface3D : View, ISciChartSurface3D
    {
        public static readonly BindableProperty XAxisProperty = BindableProperty.Create("XAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnXAxisDependencyPropertyChanged, null, null, null);

        public static readonly BindableProperty YAxisProperty = BindableProperty.Create("YAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnYAxisDependencyPropertyChanged, null, null, null);

        public static readonly BindableProperty ZAxisProperty = BindableProperty.Create("ZAxis", typeof(IAxis3D), typeof(SciChartSurface3D), null, BindingMode.Default, null, OnZAxisDependencyPropertyChanged, null, null, null);

        public SciChartSurface3D()
        {
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

        private static void OnXAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnYAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        private static void OnZAxisDependencyPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
    }
}