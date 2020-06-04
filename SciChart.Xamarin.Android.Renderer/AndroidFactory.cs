using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFactory))]
namespace SciChart.Xamarin.Android.Renderer
{

    public partial class AndroidFactory : INativeSciChartObjectFactory
    {
        
    }

    #region ChartModifiers

    public partial class ModifierGroupAndroid
    {
        public new ChartModifierCollection ChildModifiers => new FormsChartModifierCollectionAndroid(base.ChildModifiers);

        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class TooltipModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class ZoomExtentsModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class ZoomPanModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class PinchZoomModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }
    #endregion
}