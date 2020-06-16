using Java.Lang;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
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

    public partial class LegendModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }

        public void SetSourceMode(SourceMode sourceMode)
        {
            base.SetSourceMode(sourceMode.SourceModeFromXamarin()); 
        }
    }


    public partial class ModifierGroup3DAndroid
    {
        public new ChartModifier3DCollection ChildModifiers => new FormsChartModifier3DCollectionAndroid(base.ChildModifiers);

        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class ZoomExtentsModifier3DAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class PinchZoomModifier3DAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class OrbitModifier3DAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }
    #endregion

    #region Annotations 

    public partial class BoxAnnotationAndroid
    {
        public Color BackgroundColor { get; set; }
    }
    #endregion
}