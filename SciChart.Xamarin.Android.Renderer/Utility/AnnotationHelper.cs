using System;
using SciChart.Charting.Visuals.Annotations;
using SciChart.Xamarin.Views.Core.Common;
using AnnotationCoordinateMode = SciChart.Xamarin.Views.Visuals.Annotations.AnnotationCoordinateMode;
using AnnotationSurface = SciChart.Xamarin.Views.Visuals.Annotations.AnnotationSurface;
using VerticalAnchorPoint = SciChart.Charting.Visuals.Annotations.VerticalAnchorPoint;

namespace SciChart.Xamarin.Android.Renderer.Utility
{
    public static class AnnotationHelper
    {
        public static SciChart.Charting.Direction2D Direction2DFromXamarin(this Direction2D direction2D)
        {
            switch (direction2D)
            {
                case Direction2D.XDirection: return Charting.Direction2D.XDirection;
                case Direction2D.YDirection: return Charting.Direction2D.YDirection;
                case Direction2D.XyDirection: return Charting.Direction2D.XyDirection;
                default:
                    throw new NotImplementedException("The Direction2D value " + direction2D.ToString() + " has not been handled");
            }
        }

        public static Direction2D Direction2DToXamarin(this Charting.Direction2D direction2D)
        {
            if (direction2D == Charting.Direction2D.XDirection) return Direction2D.XDirection;
            if (direction2D == Charting.Direction2D.YDirection) return Direction2D.YDirection;
            if (direction2D == Charting.Direction2D.XyDirection) return Direction2D.XyDirection;

            throw new NotImplementedException("The Direction2D value " + direction2D.ToString() + " has not been handled");
        }

        public static Charting.Visuals.Annotations.AnnotationCoordinateMode AnnotationCoordinateModeFromXamarin(this AnnotationCoordinateMode annotationCoordinateMode)
        {
            switch (annotationCoordinateMode)
            {
                case AnnotationCoordinateMode.Absolute: return Charting.Visuals.Annotations.AnnotationCoordinateMode.Absolute;
                case AnnotationCoordinateMode.Relative: return Charting.Visuals.Annotations.AnnotationCoordinateMode.Relative;
                case AnnotationCoordinateMode.RelativeX: return Charting.Visuals.Annotations.AnnotationCoordinateMode.RelativeX;
                case AnnotationCoordinateMode.RelativeY: return Charting.Visuals.Annotations.AnnotationCoordinateMode.RelativeY;
                default:
                    throw new NotImplementedException("The AnnotationCoordinateMode value " + annotationCoordinateMode.ToString() + " has not been handled");
            }
        }

        public static AnnotationCoordinateMode AnnotationCoordinateModeToXamarin(this Charting.Visuals.Annotations.AnnotationCoordinateMode annotationCoordinateMode)
        {
            if (annotationCoordinateMode == Charting.Visuals.Annotations.AnnotationCoordinateMode.Absolute)
                return AnnotationCoordinateMode.Absolute;

            if (annotationCoordinateMode == Charting.Visuals.Annotations.AnnotationCoordinateMode.Relative)
                return AnnotationCoordinateMode.Relative;

            if (annotationCoordinateMode == Charting.Visuals.Annotations.AnnotationCoordinateMode.RelativeX)
                return AnnotationCoordinateMode.RelativeX;

            if (annotationCoordinateMode == Charting.Visuals.Annotations.AnnotationCoordinateMode.RelativeY)
                return AnnotationCoordinateMode.RelativeY;

            throw new NotImplementedException("The AnnotationCoordinateMode value " + annotationCoordinateMode.ToString() + " has not been handled");
        }

        public static AnnotationSurfaceEnum AnnotationSurfaceFromXamarin(this AnnotationSurface annotationSurface)
        {
            switch (annotationSurface)
            {
                case AnnotationSurface.AboveChart: return AnnotationSurfaceEnum.AboveChart; ;
                case AnnotationSurface.BelowChart: return AnnotationSurfaceEnum.BelowChart;
                case AnnotationSurface.XAxis: return AnnotationSurfaceEnum.XAxis;
                case AnnotationSurface.YAxis: return AnnotationSurfaceEnum.YAxis;
                default:
                    throw new NotImplementedException("The AnnotationSurface value " + annotationSurface.ToString() + " has not been handled");
            }
        }

        public static AnnotationSurface AnnotationSurfaceToXamarin(this AnnotationSurfaceEnum annotationSurface)
        {
            if (annotationSurface == AnnotationSurfaceEnum.AboveChart) return AnnotationSurface.AboveChart;
            if (annotationSurface == AnnotationSurfaceEnum.BelowChart) return AnnotationSurface.BelowChart;
            if (annotationSurface == AnnotationSurfaceEnum.XAxis) return AnnotationSurface.XAxis;
            if (annotationSurface == AnnotationSurfaceEnum.YAxis) return AnnotationSurface.YAxis;

            throw new NotImplementedException("The AnnotationSurfaceEnum value " + annotationSurface.ToString() + " has not been handled");
        }

        public static HorizontalAnchorPoint HorizontalAnchorPointFromXamarin(this Views.Visuals.Annotations.HorizontalAnchorPoint horizontalAnchorPoint)
        {
            switch (horizontalAnchorPoint)
            {
                case Views.Visuals.Annotations.HorizontalAnchorPoint.Left:
                    return HorizontalAnchorPoint.Left;
                case Views.Visuals.Annotations. HorizontalAnchorPoint.Center:
                    return HorizontalAnchorPoint.Center;
                case Views.Visuals.Annotations.HorizontalAnchorPoint.Right:
                    return HorizontalAnchorPoint.Right;
                default:
                    throw new NotImplementedException("The HorizontalAnchorPoint value " + horizontalAnchorPoint.ToString() + " has not been handled");
            }
        }

        public static Views.Visuals.Annotations.HorizontalAnchorPoint HorizontalAnchorPointToXamarin(this HorizontalAnchorPoint horizontalAnchorPoint)
        {
            if (horizontalAnchorPoint == HorizontalAnchorPoint.Left)
                return Views.Visuals.Annotations.HorizontalAnchorPoint.Left;

            if (horizontalAnchorPoint == HorizontalAnchorPoint.Center)
                return Views.Visuals.Annotations.HorizontalAnchorPoint.Center;

            if (horizontalAnchorPoint == HorizontalAnchorPoint.Right)
                return Views.Visuals.Annotations.HorizontalAnchorPoint.Right;

            throw new NotImplementedException("The HorizontalAnchorPoint value " + horizontalAnchorPoint.ToString() + " has not been handled");
        }

        public static VerticalAnchorPoint VerticalAnchorPointFromXamarin(this Views.Visuals.Annotations.VerticalAnchorPoint verticalAnchorPoint)
        {
            switch (verticalAnchorPoint)
            {
                case Views.Visuals.Annotations.VerticalAnchorPoint.Top:
                    return VerticalAnchorPoint.Top;
                case Views.Visuals.Annotations.VerticalAnchorPoint.Center:
                    return VerticalAnchorPoint.Center;
                case Views.Visuals.Annotations.VerticalAnchorPoint.Bottom:
                    return VerticalAnchorPoint.Bottom;
                default:
                    throw new NotImplementedException("The VerticalAnchorPoint value " + verticalAnchorPoint.ToString() + " has not been handled");
            }

        }

        public static Views.Visuals.Annotations.VerticalAnchorPoint VerticalAnchorPointToXamarin(this VerticalAnchorPoint verticalAnchorPoint)
        {
            if (verticalAnchorPoint == VerticalAnchorPoint.Top)
                return Views.Visuals.Annotations.VerticalAnchorPoint.Top;

            if (verticalAnchorPoint == VerticalAnchorPoint.Center)
                return Views.Visuals.Annotations.VerticalAnchorPoint.Center;

            if (verticalAnchorPoint == VerticalAnchorPoint.Bottom)
                return Views.Visuals.Annotations.VerticalAnchorPoint.Bottom;

            throw new NotImplementedException("The VerticalAnchorPoint value " + verticalAnchorPoint.ToString() + " has not been handled");
        }
    }
}