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
            if (annotationCoordinateMode == SCIAnnotationCoordinateMode.Absolute)
                return AnnotationCoordinateMode.Absolute;

            if (annotationCoordinateMode == SCIAnnotationCoordinateMode.Relative)
                return AnnotationCoordinateMode.Relative;

            if (annotationCoordinateMode == SCIAnnotationCoordinateMode.RelativeX)
                return AnnotationCoordinateMode.RelativeX;

            if (annotationCoordinateMode == SCIAnnotationCoordinateMode.RelativeY)
                return AnnotationCoordinateMode.RelativeY;

            throw new NotImplementedException("The SCIAnnotationCoordinateMode value " + annotationCoordinateMode.ToString() + " has not been handled");
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
            if (annotationSurface == SCIAnnotationSurfaceEnum.AboveChart) return AnnotationSurface.AboveChart;
            if (annotationSurface == SCIAnnotationSurfaceEnum.BelowChart) return AnnotationSurface.BelowChart;
            if (annotationSurface == SCIAnnotationSurfaceEnum.XAxis) return AnnotationSurface.XAxis;
            if (annotationSurface == SCIAnnotationSurfaceEnum.YAxis) return AnnotationSurface.YAxis;

            throw new NotImplementedException("The SCIAnnotationSurfaceEnum value " + annotationSurface.ToString() + " has not been handled");
        }
    }
}