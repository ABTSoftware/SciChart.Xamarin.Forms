using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.Views.Core.Common;

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
                    throw new NotImplementedException("The Direction2D value " + direction2D.ToString() + " has not been handled");
            }
        }
    }
}