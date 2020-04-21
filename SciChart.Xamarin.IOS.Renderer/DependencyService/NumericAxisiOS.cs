using System;
using SciChart.iOS.Charting;
using SciChart.Xamarin.iOS.Renderer.Utility;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;

namespace SciChart.Xamarin.iOS.Renderer.DependencyService
{
    [Foundation.Register]
    internal class NumericAxisiOS : SCINumericAxis, INativeAxis
    {
        public NumericAxisiOS()
        {
        }
    }
}