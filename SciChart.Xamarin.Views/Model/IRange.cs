using System;
using System.ComponentModel;
using SciChart.Xamarin.Views.Common;

namespace SciChart.Xamarin.Views.Model
{
    /// <summary>
    /// Defines the base interface to a Range (Min, Max), used throughout SciChart for visible, data and index range calculations
    /// </summary>
    public interface IRange : INativeSciChartObjectWrapper 
    {
        /// <summary>
        /// Gets the double representation of min value
        /// </summary>
        double MinAsDouble { get; }

        /// <summary>
        /// Gets the double representation of max value
        /// </summary>
        double MaxAsDouble { get; }
    }   
}