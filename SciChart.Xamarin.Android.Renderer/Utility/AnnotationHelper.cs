using System;
using SciChart.Xamarin.Views.Core.Common;

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
    }
}