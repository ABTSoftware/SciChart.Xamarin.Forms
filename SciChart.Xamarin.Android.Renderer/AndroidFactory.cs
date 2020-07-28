using System.ComponentModel;
using System.Linq;
using Java.Lang;
using SciChart.Charting.Visuals;
using SciChart.Xamarin.Android.Renderer;
using SciChart.Xamarin.Android.Renderer.DependencyService;
using SciChart.Xamarin.Android.Renderer.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ISciChartSurface = SciChart.Xamarin.Views.Visuals.ISciChartSurface;

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

    public partial class XAxisDragModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
        }
    }

    public partial class YAxisDragModifierAndroid
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => SetIsEnabled(value);
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
        public void SetBackgroundColor(Color backgroundColor)
        {
            base.SetBackgroundColor(backgroundColor.ToAndroid());
        }
    }

    public partial class AxisMarkerAnnotationAndroid
    {
        public void SetBackgroundColor(Color backgroundColor)
        {
            base.SetBackgroundColor(backgroundColor.ToAndroid());
        }
    }

    #endregion


    #region RenderableSeries

    public partial class ColorMapAndroid
    {
        public ColorMapAndroid(Color startColor, Color endColor) : base(startColor.ColorFromXamarin(), endColor.ColorFromXamarin())
        {

        }

        public ColorMapAndroid(Color[] colors, float[] stops) : base(colors.Select(x => x.ColorFromXamarin()).ToArray(), stops)
        {

        }
    }

    #endregion

    #region VerticalGroup

    public partial class SciChartVerticalGroupAndroid
    {
        public void AddSurfaceToGroup(ISciChartSurface surface)
        {
            var sciChartSurface = GetNativeSciChartSurface(surface);
            if (sciChartSurface != null)
                base.AddSurfaceToGroup(sciChartSurface);
        }

        public void RemoveSurfaceFromGroup(ISciChartSurface surface)
        {
            var sciChartSurface = GetNativeSciChartSurface(surface);
            if(sciChartSurface != null)
                base.RemoveSurfaceFromGroup(sciChartSurface);
        }

        private static SciChartSurface GetNativeSciChartSurface(ISciChartSurface surface)
        {
            return surface?.NativeView as SciChartSurface;
        }
    }

    #endregion
}