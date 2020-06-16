using System;
using CoreGraphics;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSFactory))]
namespace SciChart.Xamarin.iOS.Renderer
{
    public partial class iOSFactory : INativeSciChartObjectFactory
    {
    }

    #region Style

    public partial class SolidPenStyleiOS
    {
        public SolidPenStyleiOS(Color color, float thickness, bool antiAliasing, float[] strokeDashArray)
            : base(color.ColorFromXamarin(), thickness, antiAliasing, strokeDashArray)
        {

        }
    }

    public partial class SolidBrushStyleiOS
    {
        public SolidBrushStyleiOS(Color colorCode) : base(colorCode.ColorFromXamarin())
        {
        }
    }

    public partial class LinearGradientBrushStyleiOS
    {
        public LinearGradientBrushStyleiOS(float x0, float y0, float x1, float y1, Color startColor, Color endColor) : base(new CGPoint(x0, y0), new CGPoint(x1, y1),
            startColor.ColorFromXamarin(), endColor.ColorFromXamarin())
        {

        }
    }

    public partial class FontStyleiOS
    {
        public FontStyleiOS(float textSize, Color textColor) : base(textSize, textColor.ColorFromXamarin())
        {

        }
    }

    #endregion

    #region Annotations

    public partial class BoxAnnotationiOS
    {
        public void MoveBasePointTo(float xCoord, float yCoord, int index)
        {
            base.MoveBasePointTo(new CGPoint(xCoord, yCoord), index);
        }

        public void MoveAnnotation(float horizontalOffset, float verticalOffset)
        {
            base.MoveAnnotationByXDelta(horizontalOffset, verticalOffset);
        }
    }

    public partial class LineArrowAnnotationiOS
    {
        public void MoveBasePointTo(float xCoord, float yCoord, int index)
        {
            base.MoveBasePointTo(new CGPoint(xCoord, yCoord), index);
        }

        public void MoveAnnotation(float horizontalOffset, float verticalOffset)
        {
            base.MoveAnnotationByXDelta(horizontalOffset, verticalOffset);
        }
    }

    public partial class LineAnnotationiOS
    {
        public void MoveBasePointTo(float xCoord, float yCoord, int index)
        {
            base.MoveBasePointTo(new CGPoint(xCoord, yCoord), index);
        }

        public void MoveAnnotation(float horizontalOffset, float verticalOffset)
        {
            base.MoveAnnotationByXDelta(horizontalOffset, verticalOffset);
        }
    }

    public partial class TextAnnotationiOS
    {
        public void MoveBasePointTo(float xCoord, float yCoord, int index)
        {
            base.MoveBasePointTo(new CGPoint(xCoord, yCoord), index);
        }

        public void MoveAnnotation(float horizontalOffset, float verticalOffset)
        {
            base.MoveAnnotationByXDelta(horizontalOffset, verticalOffset);
        }
    }

    public partial class AxisMarkerAnnotationiOS
    {
        public int MarkerPointWidth
        {
            get => (int) base.MarkerPointSize;
            set => base.MarkerPointSize = value;
        }

        public void MoveBasePointTo(float xCoord, float yCoord, int index)
        {
            base.MoveBasePointTo(new CGPoint(xCoord, yCoord), index);
        }

        public void MoveAnnotation(float horizontalOffset, float verticalOffset)
        {
            base.MoveAnnotationByXDelta(horizontalOffset, verticalOffset);
        }
    }

    #endregion

    #region PointMarkers

    public partial class EllipsePointMarkeriOS
    {
        public int Width
        {
            get => (int) base.Size.Width;
            set => base.Size = new CGSize(value, base.Size.Height);
        }

        public int Height
        {
            get => (int) base.Size.Height;
            set => base.Size = new CGSize(base.Size.Width, value);
        }
    }

    #endregion

    #region ChartModifiers
    public partial class ModifierGroupiOS
    {
        public new ChartModifierCollection ChildModifiers => new FormsChartModifierCollectionIOS(base.ChildModifiers);

        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => ((SCIChartModifierCore) this).IsEnabled = value;
        }

        public new bool ReceiveHandledEvents
        {
            get => base.ReceiveHandledEvents;
            set => ((SCIChartModifierCore)this).ReceiveHandledEvents = value;
        }
    }

    public partial class LegendModifieriOS
    {
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => ((SCIChartModifierCore)this).IsEnabled = value;
        }

        public new bool ReceiveHandledEvents
        {
            get => base.ReceiveHandledEvents;
            set => ((SCIChartModifierCore)this).ReceiveHandledEvents = value;
        }

        public void SetShowLegend(bool showLegend)
        {
            base.ShowLegend = showLegend;
        }

        public void SetShowCheckboxes(bool showCheckboxes)
        {
            base.ShowCheckBoxes = showCheckboxes;
        }

        public void SetShowSeriesMarkers(bool showSeriesMarkers)
        {
            base.ShowSeriesMarkers = showSeriesMarkers;
        }

        public void SetSourceMode(SourceMode sourceMode)
        {
            base.SourceMode = sourceMode.SourceModeFromXamarin();
        }
    }

    public partial class ModifierGroup3DiOS
    {
        public new ChartModifier3DCollection ChildModifiers => new FormsChartModifier3DCollectionIOS(base.ChildModifiers);

        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set => ((SCIChartModifierCore)this).IsEnabled = value;
        }

        public new bool ReceiveHandledEvents
        {
            get => base.ReceiveHandledEvents;
            set => ((SCIChartModifierCore)this).ReceiveHandledEvents = value;
        }
    }
    #endregion
}
