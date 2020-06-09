﻿using SciChart.Xamarin.Views.Core.Generation;
using SciChart.Xamarin.Views.Drawing;

namespace SciChart.Xamarin.Views.Visuals.Annotations
{
    [ClassDeclaration("AxisMarkerAnnotation", typeof(IAnchorPointAnnotation))]
    [InjectNativeSciChartObject]
    public interface IAxisMarkerAnnotation : IAnchorPointAnnotation
    {
        [BindablePropertyDefinition()] 
        string FormattedValue { get; set; }

        [BindablePropertyDefinition()]
        [NativePropertyConverterDeclaration("FontStyle")]
        IFontStyle FontStyle { get; set; }

        [BindablePropertyDefinition()]
        int MarkerPointWidth { get; set; }
    }
}