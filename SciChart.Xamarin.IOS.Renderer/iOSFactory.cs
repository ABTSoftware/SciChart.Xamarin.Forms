﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CoreGraphics;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer;
using SciChart.Xamarin.iOS.Renderer.DependencyService;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals;
using SciChart.Xamarin.Views.Visuals.Axes;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(iOSFactory))]
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

        public void SetBackgroundColor(Color backgroundColor)
        {
            base.FillBrush = new SCISolidBrushStyle(backgroundColor.ColorFromXamarin());
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

        public void SetBackgroundColor(Color backgroundColor)
        {
            base.BackgroundBrush = new SCISolidBrushStyle(backgroundColor.ColorFromXamarin());
        }
    }

    public partial class HorizontalLineAnnotationiOS
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

    public partial class VerticalLineAnnotationiOS
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

        public void SetLegendOrientation(Orientation orientation)
        {
            base.Orientation = orientation.OrientationFromXamarin();
        }

        public void SetLegendPosition(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, int topMargin, int leftMargin, int bottomMargin, int rightMargin)
        {
            var alignment = horizontalAlignment.HorizontalAlignmentFromXamarin() | verticalAlignment.VerticalAlignmentFromXamarin();
            this.Position = alignment;
            this.Margins = new UIEdgeInsets(topMargin, leftMargin, bottomMargin, rightMargin);
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

    #region RenderableSeries

    public partial class ColorMapiOS
    {
        public ColorMapiOS(Color startColor, Color endColor) : base(startColor.ToUIColor(), endColor.ToUIColor())
        {

        }

        public ColorMapiOS(Color[] colors, float[] stops) : base(colors.Select(x => x.ToUIColor()).ToArray(), stops)
        {

        }
    }

    #endregion

    #region VerticalGroup

    public partial class ChartVerticalGroupiOS
    {
        public void AddSurfaceToGroup(ISciChartSurface surface)
        {
            var sciChartSurface = GetNativeSciChartSurface(surface);
            if(sciChartSurface?.LayoutManager != null)
                base.AddSurfaceToGroup(sciChartSurface);
        }

        public void RemoveSurfaceFromGroup(ISciChartSurface surface)
        {
            var sciChartSurface = GetNativeSciChartSurface(surface);
            if (sciChartSurface?.LayoutManager != null)
                base.RemoveSurfaceFromGroup(sciChartSurface);
        }

        private static SCIChartSurface GetNativeSciChartSurface(ISciChartSurface surface)
        {
            return surface?.NativeView as SCIChartSurface;
        }
    }

    #endregion

    #region Axes

    public partial class NumericAxisiOS
    {
        private void InternalInit()
        {
            base.VisibleRangeChanged += OnVisibleRangeChange;
        }

        private void OnVisibleRangeChange(IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newrange, bool isanimating)
        {
            VisibleRangeChanged?.Invoke(this, new VisibleRangeChangedEventArgs(oldrange.RangeToXamarin(), newrange.RangeToXamarin(), isanimating));
        }

        public new event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }


    public partial class DateAxisiOS
    {
        private void InternalInit()
        {
            base.VisibleRangeChanged += OnVisibleRangeChange;
        }

        private void OnVisibleRangeChange(IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newrange, bool isanimating)
        {
            VisibleRangeChanged?.Invoke(this, new VisibleRangeChangedEventArgs(oldrange.RangeToXamarin(), newrange.RangeToXamarin(), isanimating));
        }

        public new event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }


    public partial class CategoryDateAxisiOS
    {
        private void InternalInit()
        {
            base.VisibleRangeChanged += OnVisibleRangeChange;
        }

        private void OnVisibleRangeChange(IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newrange, bool isanimating)
        {
            VisibleRangeChanged?.Invoke(this, new VisibleRangeChangedEventArgs(oldrange.RangeToXamarin(), newrange.RangeToXamarin(), isanimating));
        }

        public new event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }

    public partial class LogarithmicNumericAxisiOS
    {
        private void InternalInit()
        {
            base.VisibleRangeChanged += OnVisibleRangeChange;
        }

        private void OnVisibleRangeChange(IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newrange, bool isanimating)
        {
            VisibleRangeChanged?.Invoke(this, new VisibleRangeChangedEventArgs(oldrange.RangeToXamarin(), newrange.RangeToXamarin(), isanimating));
        }

        public new event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }

    #endregion

    #region Axes3D

    public partial class NumericAxis3DiOS
    {
        private void InternalInit()
        {
            base.VisibleRangeChanged += OnVisibleRangeChange;
        }

        private void OnVisibleRangeChange(IISCIAxisCore axis, IISCIRange oldrange, IISCIRange newrange, bool isanimating)
        {
            VisibleRangeChanged?.Invoke(this, new VisibleRangeChangedEventArgs(oldrange.RangeToXamarin(), newrange.RangeToXamarin(), isanimating));
        }

        public new event EventHandler<VisibleRangeChangedEventArgs> VisibleRangeChanged;
    }

    #endregion


    #region Range

    public partial class DoubleRangeiOS
    {
        private void InternalInit()
        {
            AddRangeChangeObserver(OnRangeChanged);
        }

        private void OnRangeChanged(IISCIComparable arg0, IISCIComparable arg1, IISCIComparable arg2, IISCIComparable arg3, SCIRangeClipMode arg4)
        {
            switch (arg4)
            {
                case SCIRangeClipMode.Min:
                    OnPropertyChanged("Min");
                    break;
                case SCIRangeClipMode.Max:
                    OnPropertyChanged("Max");
                    break;
                case SCIRangeClipMode.MinMax:
                    OnPropertyChanged("Min");
                    OnPropertyChanged("Max");
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
