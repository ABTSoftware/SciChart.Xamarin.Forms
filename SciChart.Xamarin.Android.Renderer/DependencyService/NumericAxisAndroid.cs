using System;
using Android.Content;
using SciChart.Charting.Visuals.Axes;
using SciChart.Xamarin.Android.Renderer.Utility;
using SciChart.Xamarin.Views.Core;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Visuals.Axes;
using Xamarin.Forms;
using AutoRange = SciChart.Xamarin.Views.Visuals.Axes.AutoRange;
using AxisAlignment = SciChart.Xamarin.Views.Visuals.Axes.AxisAlignment;
using IAxis = SciChart.Xamarin.Views.Visuals.Axes.IAxis;
using IAxisCore = SciChart.Xamarin.Views.Visuals.Axes.IAxisCore;
using NumericAxis = SciChart.Charting.Visuals.Axes.NumericAxis;
using NumericAxisXf = SciChart.Xamarin.Views.Visuals.Axes.NumericAxis;
using INumericAxis = SciChart.Xamarin.Views.Visuals.Axes.INumericAxis;

namespace SciChart.Xamarin.Android.Renderer.DependencyService
{
    internal class NumericAxisAndroid : NumericAxis, INativeAxis
    {
        public NumericAxisAndroid(Context context) : base(context)
        {

        }
    }
}