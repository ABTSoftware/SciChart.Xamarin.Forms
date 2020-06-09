using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Visuals.Annotations;

namespace SciChart.Xamarin.iOS.Renderer.Utility
{
    public static class AnnotationHelper
    {
        public static SCIDirection2D Direction2DFromXamarin(this Direction2D direction2D)
        {
            switch (direction2D)
            {
                case Direction2D.XDirection: return SCIDirection2D.XDirection;
                case Direction2D.YDirection: return SCIDirection2D.YDirection;
                case Direction2D.XyDirection: return SCIDirection2D.XyDirection;
                default:
                    throw new NotImplementedException("The Direction2D value " + direction2D.ToString() + " has not been handled");
            }
        }

        public static Direction2D Direction2DToXamarin(this SCIDirection2D direction2D)
        {
            switch (direction2D)
            {
                case SCIDirection2D.XDirection: return Direction2D.XDirection;
                case SCIDirection2D.YDirection: return Direction2D.YDirection;
                case SCIDirection2D.XyDirection: return Direction2D.XyDirection;
                default:
                    throw new NotImplementedException("The SCIDirection2D value " + direction2D.ToString() + " has not been handled");
            }
        }

        public static SCIAnnotationCoordinateMode AnnotationCoordinateModeFromXamarin(this AnnotationCoordinateMode annotationCoordinateMode)
        {
            switch (annotationCoordinateMode)
            {
                case AnnotationCoordinateMode.Absolute: return SCIAnnotationCoordinateMode.Absolute;
                case AnnotationCoordinateMode.Relative: return SCIAnnotationCoordinateMode.Relative;
                case AnnotationCoordinateMode.RelativeX: return SCIAnnotationCoordinateMode.RelativeX;
                case AnnotationCoordinateMode.RelativeY: return SCIAnnotationCoordinateMode.RelativeY;
                default:
                    throw new NotImplementedException("The AnnotationCoordinateMode value " + annotationCoordinateMode.ToString() + " has not been handled");
            }
        }

        public static AnnotationCoordinateMode AnnotationCoordinateModeToXamarin(this SCIAnnotationCoordinateMode annotationCoordinateMode)
        {
            switch (annotationCoordinateMode)
            {
                case SCIAnnotationCoordinateMode.Absolute: return AnnotationCoordinateMode.Absolute;
                case SCIAnnotationCoordinateMode.Relative: return AnnotationCoordinateMode.Relative;
                case SCIAnnotationCoordinateMode.RelativeX: return AnnotationCoordinateMode.RelativeX;
                case SCIAnnotationCoordinateMode.RelativeY: return AnnotationCoordinateMode.RelativeY;
                default:
                    throw new NotImplementedException("The SCIAnnotationCoordinateMode value " + annotationCoordinateMode.ToString() + " has not been handled");
            }
        }

        public static SCIAnnotationSurfaceEnum AnnotationSurfaceFromXamarin(this AnnotationSurface annotationSurface)
        {
            switch (annotationSurface)
            {
                case AnnotationSurface.AboveChart: return SCIAnnotationSurfaceEnum.AboveChart; ;
                case AnnotationSurface.BelowChart: return SCIAnnotationSurfaceEnum.BelowChart;
                case AnnotationSurface.XAxis: return SCIAnnotationSurfaceEnum.XAxis;
                case AnnotationSurface.YAxis: return SCIAnnotationSurfaceEnum.YAxis;
                default:
                    throw new NotImplementedException("The AnnotationSurface value " + annotationSurface.ToString() + " has not been handled");
            }
        }

        public static AnnotationSurface AnnotationSurfaceToXamarin(this SCIAnnotationSurfaceEnum annotationSurface)
        {
            switch (annotationSurface)
            {
                case SCIAnnotationSurfaceEnum.AboveChart: return AnnotationSurface.AboveChart;
                case SCIAnnotationSurfaceEnum.BelowChart: return AnnotationSurface.BelowChart;
                case SCIAnnotationSurfaceEnum.XAxis: return AnnotationSurface.XAxis;
                case SCIAnnotationSurfaceEnum.YAxis: return AnnotationSurface.YAxis;
                default:
                    throw new NotImplementedException("The SCIAnnotationSurfaceEnum value " + annotationSurface.ToString() + " has not been handled");
            }
        }

        public static SCIHorizontalAnchorPoint HorizontalAnchorPointFromXamarin(this HorizontalAnchorPoint horizontalAnchorPoint)
        {
            switch (horizontalAnchorPoint)
            {
                case HorizontalAnchorPoint.Left:
                    return SCIHorizontalAnchorPoint.Left;
                case HorizontalAnchorPoint.Center:
                    return SCIHorizontalAnchorPoint.Center;
                case HorizontalAnchorPoint.Right:
                    return SCIHorizontalAnchorPoint.Right;
                default:
                    throw new NotImplementedException("The HorizontalAnchorPoint value " + horizontalAnchorPoint.ToString() + " has not been handled");
            }

        }

        public static HorizontalAnchorPoint HorizontalAnchorPointToXamarin(this SCIHorizontalAnchorPoint horizontalAnchorPoint)
        {
            switch (horizontalAnchorPoint)
            {
                case SCIHorizontalAnchorPoint.Left:
                    return HorizontalAnchorPoint.Left;
                case SCIHorizontalAnchorPoint.Center:
                    return HorizontalAnchorPoint.Center;
                case SCIHorizontalAnchorPoint.Right:
                    return HorizontalAnchorPoint.Right;
                default:
                    throw new NotImplementedException("The SCIHorizontalAnchorPoint value " + horizontalAnchorPoint.ToString() + " has not been handled");
            }
        }

        public static SCIVerticalAnchorPoint VerticalAnchorPointFromXamarin(this VerticalAnchorPoint verticalAnchorPoint)
        {
            switch (verticalAnchorPoint)
            {
                case VerticalAnchorPoint.Top:
                    return SCIVerticalAnchorPoint.Top;
                case VerticalAnchorPoint.Center:
                    return SCIVerticalAnchorPoint.Center;
                case VerticalAnchorPoint.Bottom:
                    return SCIVerticalAnchorPoint.Bottom;
                default:
                    throw new NotImplementedException("The VerticalAnchorPoint value " + verticalAnchorPoint.ToString() + " has not been handled");
            }

        }

        public static VerticalAnchorPoint VerticalAnchorPointToXamarin(this SCIVerticalAnchorPoint verticalAnchorPoint)
        {
            switch (verticalAnchorPoint)
            {
                case SCIVerticalAnchorPoint.Top:
                    return VerticalAnchorPoint.Top;
                case SCIVerticalAnchorPoint.Center:
                    return VerticalAnchorPoint.Center;
                case SCIVerticalAnchorPoint.Bottom:
                    return VerticalAnchorPoint.Bottom;
                default:
                    throw new NotImplementedException("The SCIVerticalAnchorPoint value " + verticalAnchorPoint.ToString() + " has not been handled");
            }
        }
    }
}