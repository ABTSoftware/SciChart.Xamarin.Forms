//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AndroidApplication = Android.App.Application;
using AndroidComplexUnitType = Android.Util.ComplexUnitType;
using AndroidContext = Android.Content.Context;
using AndroidTypeface = Android.Graphics.Typeface;
using IAndroidAttributesSet = Android.Util.IAttributeSet;
using Xamarin.Forms;


namespace SciChart.Xamarin.Android.Renderer
{
	using SciChart.Data.Model;
	using SciChart.Charting.Visuals.RenderableSeries;
	using SciChart.Charting.Visuals.Axes;
	using SciChart.Charting.Visuals.Annotations;
	using SciChart.Charting.Modifiers;
	using SciChart.Charting.Model.DataSeries;
	using SciChart.Xamarin.Android.Renderer.Utility;
	using SciChart.Drawing.Common;
	using SciChart.Charting3D.Visuals.RenderableSeries;
	using SciChart.Charting3D.Visuals.Axes;
	
	
	public partial class FastCandlestickRenderableSeriesAndroid : FastCandlestickRenderableSeries, SciChart.Xamarin.Views.Visuals.RenderableSeries.IFastCandlestickRenderableSeries, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public FastCandlestickRenderableSeriesAndroid()
		{
		}
		
		public FastCandlestickRenderableSeriesAndroid(SciChart.Charting.Visuals.RenderableSeries.Data.OhlcRenderPassData currentRenderPassData, SciChart.Charting.Visuals.RenderableSeries.HitTest.IHitProvider hitProvider, SciChart.Charting.Visuals.RenderableSeries.HitTest.INearestPointProvider nearestPointProvider) : 
				base(currentRenderPassData, hitProvider, nearestPointProvider)
		{
		}
		
		public SciChart.Xamarin.Views.Drawing.IBrushStyle FillDownBrushStyle
		{
			get
			{
				return base.FillDownBrushStyle.BrushStyleToXamarin();
			}
			set
			{
				base.FillDownBrushStyle = value.BrushStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IBrushStyle FillUpBrushStyle
		{
			get
			{
				return base.FillUpBrushStyle.BrushStyleToXamarin();
			}
			set
			{
				base.FillUpBrushStyle = value.BrushStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IPenStyle StrokeDownStyle
		{
			get
			{
				return base.StrokeDownStyle.PenStyleToXamarin();
			}
			set
			{
				base.StrokeDownStyle = value.PenStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IPenStyle StrokeUpStyle
		{
			get
			{
				return base.StrokeUpStyle.PenStyleToXamarin();
			}
			set
			{
				base.StrokeUpStyle = value.PenStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.DataSeries.IDataSeries DataSeries
		{
			get
			{
				return base.DataSeries.DataSeriesToXamarin();
			}
			set
			{
				base.DataSeries = value.DataSeriesFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IPenStyle StrokeStyle
		{
			get
			{
				return base.StrokeStyle.PenStyleToXamarin();
			}
			set
			{
				base.StrokeStyle = value.PenStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class FastLineRenderableSeriesAndroid : FastLineRenderableSeries, SciChart.Xamarin.Views.Visuals.RenderableSeries.IFastLineRenderableSeries, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public FastLineRenderableSeriesAndroid()
		{
		}
		
		public FastLineRenderableSeriesAndroid(SciChart.Charting.Visuals.RenderableSeries.Data.LineRenderPassData currentRenderPassData, SciChart.Charting.Visuals.RenderableSeries.HitTest.IHitProvider hitProvider, SciChart.Charting.Visuals.RenderableSeries.HitTest.INearestPointProvider nearestPointProvider) : 
				base(currentRenderPassData, hitProvider, nearestPointProvider)
		{
		}
		
		public SciChart.Xamarin.Views.Model.DataSeries.IDataSeries DataSeries
		{
			get
			{
				return base.DataSeries.DataSeriesToXamarin();
			}
			set
			{
				base.DataSeries = value.DataSeriesFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IPenStyle StrokeStyle
		{
			get
			{
				return base.StrokeStyle.PenStyleToXamarin();
			}
			set
			{
				base.StrokeStyle = value.PenStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class NumericAxisAndroid : NumericAxis, SciChart.Xamarin.Views.Visuals.Axes.INumericAxis, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public NumericAxisAndroid() : 
				base(AndroidApplication.Context)
		{
		}
		
		public NumericAxisAndroid(AndroidContext context) : 
				base(context)
		{
		}
		
		public NumericAxisAndroid(SciChart.Charting.Visuals.Axes.IAxisModifierSurface axisModifierSurface) : 
				base(axisModifierSurface)
		{
		}
		
		public NumericAxisAndroid(SciChart.Data.Model.IRange defaultNonZeroRange, SciChart.Charting.Visuals.Axes.IAxisModifierSurface axisModifierSurface) : 
				base(defaultNonZeroRange, axisModifierSurface)
		{
		}
		
		public SciChart.Xamarin.Views.Visuals.Axes.AxisAlignment AxisAlignment
		{
			get
			{
				return base.AxisAlignment.AlignmentToXamarin();
			}
			set
			{
				base.AxisAlignment = value.AlignmentFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Drawing.IBrushStyle AxisBandsFill
		{
			get
			{
				return base.AxisBandsStyle.BrushStyleToXamarin();
			}
			set
			{
				base.AxisBandsStyle = value.BrushStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Visuals.Axes.AutoRange AutoRange
		{
			get
			{
				return base.AutoRange.AutoRangeToXamarin();
			}
			set
			{
				base.AutoRange = value.AutoRangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.IRange VisibleRange
		{
			get
			{
				return base.VisibleRange.RangeToXamarin();
			}
			set
			{
				base.VisibleRange = value.RangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.IRange GrowBy
		{
			get
			{
				return base.GrowBy.RangeToXamarin();
			}
			set
			{
				base.GrowBy = value.RangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.RangeClipMode VisibleRangeLimitMode
		{
			get
			{
				return base.VisibleRangeLimitMode.RangeClipModeToXamarin();
			}
			set
			{
				base.VisibleRangeLimitMode = value.RangeClipModeFromXamarin();
			}
		}
		
		public System.IComparable MinimalZoomConstrain
		{
			get
			{
				return base.MinimalZoomConstrain.ComparableToXamarin();
			}
			set
			{
				base.MinimalZoomConstrain = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MaximumZoomConstrain
		{
			get
			{
				return base.MaximumZoomConstrain.ComparableToXamarin();
			}
			set
			{
				base.MaximumZoomConstrain = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MajorDelta
		{
			get
			{
				return base.MajorDelta.ComparableToXamarin();
			}
			set
			{
				base.MajorDelta = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MinorDelta
		{
			get
			{
				return base.MinorDelta.ComparableToXamarin();
			}
			set
			{
				base.MinorDelta = value.ComparableFromXamarin();
			}
		}
		
		public uint MaxAutoTicks
		{
			get
			{
				return base.MaxAutoTicks.UIntToXamarin();
			}
			set
			{
				base.MaxAutoTicks = value.UIntFromXamarin();
			}
		}
		
		public uint MinorsPerMajor
		{
			get
			{
				return base.MinorsPerMajor.UIntToXamarin();
			}
			set
			{
				base.MinorsPerMajor = value.UIntFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class NumericAxis3DAndroid : NumericAxis3D, SciChart.Xamarin.Views.Visuals.Axes3D.INumericAxis3D, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public NumericAxis3DAndroid()
		{
		}
		
		public NumericAxis3DAndroid(SciChart.Data.Model.IRange defaultNonZeroRange) : 
				base(defaultNonZeroRange)
		{
		}
		
		public SciChart.Xamarin.Views.Drawing.IBrushStyle AxisBandsFill
		{
			get
			{
				return base.AxisBandsStyle.BrushStyleToXamarin();
			}
			set
			{
				base.AxisBandsStyle = value.BrushStyleFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Visuals.Axes.AutoRange AutoRange
		{
			get
			{
				return base.AutoRange.AutoRangeToXamarin();
			}
			set
			{
				base.AutoRange = value.AutoRangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.IRange VisibleRange
		{
			get
			{
				return base.VisibleRange.RangeToXamarin();
			}
			set
			{
				base.VisibleRange = value.RangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.IRange GrowBy
		{
			get
			{
				return base.GrowBy.RangeToXamarin();
			}
			set
			{
				base.GrowBy = value.RangeFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Model.RangeClipMode VisibleRangeLimitMode
		{
			get
			{
				return base.VisibleRangeLimitMode.RangeClipModeToXamarin();
			}
			set
			{
				base.VisibleRangeLimitMode = value.RangeClipModeFromXamarin();
			}
		}
		
		public System.IComparable MinimalZoomConstrain
		{
			get
			{
				return base.MinimalZoomConstrain.ComparableToXamarin();
			}
			set
			{
				base.MinimalZoomConstrain = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MaximumZoomConstrain
		{
			get
			{
				return base.MaximumZoomConstrain.ComparableToXamarin();
			}
			set
			{
				base.MaximumZoomConstrain = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MajorDelta
		{
			get
			{
				return base.MajorDelta.ComparableToXamarin();
			}
			set
			{
				base.MajorDelta = value.ComparableFromXamarin();
			}
		}
		
		public System.IComparable MinorDelta
		{
			get
			{
				return base.MinorDelta.ComparableToXamarin();
			}
			set
			{
				base.MinorDelta = value.ComparableFromXamarin();
			}
		}
		
		public uint MaxAutoTicks
		{
			get
			{
				return base.MaxAutoTicks.UIntToXamarin();
			}
			set
			{
				base.MaxAutoTicks = value.UIntFromXamarin();
			}
		}
		
		public uint MinorsPerMajor
		{
			get
			{
				return base.MinorsPerMajor.UIntToXamarin();
			}
			set
			{
				base.MinorsPerMajor = value.UIntFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class BoxAnnotationAndroid : BoxAnnotation, SciChart.Xamarin.Views.Visuals.Annotations.IBoxAnnotation, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public BoxAnnotationAndroid() : 
				base(AndroidApplication.Context)
		{
		}
		
		public BoxAnnotationAndroid(AndroidContext context) : 
				base(context)
		{
		}
		
		public BoxAnnotationAndroid(AndroidContext context, IAndroidAttributesSet attrs) : 
				base(context, attrs)
		{
		}
		
		public BoxAnnotationAndroid(AndroidContext context, IAndroidAttributesSet attrs, int defStyleAttr) : 
				base(context, attrs, defStyleAttr)
		{
		}
		
		public BoxAnnotationAndroid(AndroidContext context, IAndroidAttributesSet attrs, int defStyleAttr, int defStyleRes) : 
				base(context, attrs, defStyleAttr, defStyleRes)
		{
		}
		
		public System.IComparable X1
		{
			get
			{
				return base.X1Value;
			}
			set
			{
				base.X1Value = value;
			}
		}
		
		public System.IComparable X2
		{
			get
			{
				return base.X2Value;
			}
			set
			{
				base.X2Value = value;
			}
		}
		
		public System.IComparable Y1
		{
			get
			{
				return base.Y1Value;
			}
			set
			{
				base.Y1Value = value;
			}
		}
		
		public System.IComparable Y2
		{
			get
			{
				return base.Y2Value;
			}
			set
			{
				base.Y2Value = value;
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.Direction2D DragDirections
		{
			get
			{
				return base.DragDirections.Direction2DToXamarin();
			}
			set
			{
				base.DragDirections = value.Direction2DFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.Direction2D ResizeDirections
		{
			get
			{
				return base.ResizeDirections.Direction2DToXamarin();
			}
			set
			{
				base.ResizeDirections = value.Direction2DFromXamarin();
			}
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class ModifierGroupAndroid : ModifierGroup, SciChart.Xamarin.Views.Modifiers.IModifierGroup, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public ModifierGroupAndroid()
		{
		}
		
		public ModifierGroupAndroid(SciChart.Charting.Modifiers.IChartModifier[] childModifiers) : 
				base(childModifiers)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class PinchZoomModifierAndroid : PinchZoomModifier, SciChart.Xamarin.Views.Modifiers.IPinchZoomModifier, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public PinchZoomModifierAndroid()
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class TooltipModifierAndroid : TooltipModifier, SciChart.Xamarin.Views.Modifiers.ITooltipModifier, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public TooltipModifierAndroid()
		{
		}
		
		public TooltipModifierAndroid(SciChart.Charting.Modifiers.Behaviors.CrossDrawableBehavior crossDrawableBehavior) : 
				base(crossDrawableBehavior)
		{
		}
		
		public TooltipModifierAndroid(SciChart.Charting.Modifiers.Behaviors.CrossDrawableBehavior crossDrawableBehavior, int tooltipContainerLayoutResId) : 
				base(crossDrawableBehavior, tooltipContainerLayoutResId)
		{
		}
		
		public TooltipModifierAndroid(SciChart.Charting.Modifiers.Behaviors.TooltipBehavior tooltipBehavior, SciChart.Charting.Modifiers.Behaviors.CrossDrawableBehavior crossDrawableBehavior) : 
				base(tooltipBehavior, crossDrawableBehavior)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class ZoomExtentsModifierAndroid : ZoomExtentsModifier, SciChart.Xamarin.Views.Modifiers.IZoomExtentsModifier, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public ZoomExtentsModifierAndroid()
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class ZoomPanModifierAndroid : ZoomPanModifier, SciChart.Xamarin.Views.Modifiers.IZoomPanModifier, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public ZoomPanModifierAndroid()
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class DoubleRangeAndroid : DoubleRange, SciChart.Xamarin.Views.Model.IDoubleRange, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public DoubleRangeAndroid(double min, double max) : 
				base(min, max)
		{
		}
		
		public DoubleRangeAndroid()
		{
		}
		
		public DoubleRangeAndroid(SciChart.Data.Model.DoubleRange range) : 
				base(range)
		{
		}
		
		public DoubleRangeAndroid(Java.Lang.Double min, Java.Lang.Double max) : 
				base(min, max)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class OhlcDataSeriesAndroid<TX, TY> : OhlcDataSeries<TX,TY>, SciChart.Xamarin.Views.Model.DataSeries.IOhlcDataSeries<TX,TY>, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
		where TX : System.IComparable
		where TY : System.IComparable
	{
		
		public OhlcDataSeriesAndroid()
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class XyDataSeriesAndroid<TX, TY> : XyDataSeries<TX,TY>, SciChart.Xamarin.Views.Model.DataSeries.IXyDataSeries<TX,TY>, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
		where TX : System.IComparable
		where TY : System.IComparable
	{
		
		public XyDataSeriesAndroid()
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class FontStyleAndroid : FontStyle, SciChart.Xamarin.Views.Drawing.IFontStyle, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public FontStyleAndroid(AndroidTypeface typeface, float textSize, uint textColor, bool antiAliasing) : 
				base(typeface, textSize, textColor, antiAliasing)
		{
		}
		
		public FontStyleAndroid(AndroidTypeface typeface, float textSize, System.Drawing.Color textColor, bool antiAliasing) : 
				base(typeface, textSize, textColor, antiAliasing)
		{
		}
		
		public FontStyleAndroid(AndroidContext context, AndroidTypeface typeface, float textSize, System.Drawing.Color textColor, AndroidComplexUnitType unit, bool antiAliasing) : 
				base(context, typeface, textSize, textColor, unit, antiAliasing)
		{
		}
		
		public FontStyleAndroid(float textSize, uint textColor) : 
				base(textSize, textColor)
		{
		}
		
		public FontStyleAndroid(float textSize, System.Drawing.Color textColor) : 
				base(textSize, textColor)
		{
		}
		
		public FontStyleAndroid(AndroidContext context, float textSize, System.Drawing.Color textColor, AndroidComplexUnitType unit) : 
				base(context, textSize, textColor, unit)
		{
		}
		
		public FontStyleAndroid(AndroidTypeface typeface, float textSize, int textColor, bool antiAliasing) : 
				base(typeface, textSize, textColor, antiAliasing)
		{
		}
		
		public FontStyleAndroid(float textSize, int textColor) : 
				base(textSize, textColor)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class LinearGradientBrushStyleAndroid : LinearGradientBrushStyle, SciChart.Xamarin.Views.Drawing.ILinearGradientBrushStyle, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, System.Drawing.Color[] colors, float[] stops) : 
				base(x0, y0, x1, y1, colors, stops)
		{
		}
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, uint[] colors, float[] stops) : 
				base(x0, y0, x1, y1, colors, stops)
		{
		}
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, System.Drawing.Color startColor, System.Drawing.Color endColor) : 
				base(x0, y0, x1, y1, startColor, endColor)
		{
		}
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, uint startColor, uint endColor) : 
				base(x0, y0, x1, y1, startColor, endColor)
		{
		}
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, int startColor, int endColor) : 
				base(x0, y0, x1, y1, startColor, endColor)
		{
		}
		
		public LinearGradientBrushStyleAndroid(float x0, float y0, float x1, float y1, int[] colors, float[] stops) : 
				base(x0, y0, x1, y1, colors, stops)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class SolidBrushStyleAndroid : SolidBrushStyle, SciChart.Xamarin.Views.Drawing.ISolidBrushStyle, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public SolidBrushStyleAndroid(System.Drawing.Color color) : 
				base(color)
		{
		}
		
		public SolidBrushStyleAndroid(uint color) : 
				base(color)
		{
		}
		
		public SolidBrushStyleAndroid(int color) : 
				base(color)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class SolidPenStyleAndroid : SolidPenStyle, SciChart.Xamarin.Views.Drawing.ISolidPenStyle, SciChart.Xamarin.Views.Core.Common.INativeSciChartObject
	{
		
		public SolidPenStyleAndroid(uint color, float thickness, bool antiAliasing, float[] strokeDashArray) : 
				base(color, thickness, antiAliasing, strokeDashArray)
		{
		}
		
		public SolidPenStyleAndroid(System.Drawing.Color color, float thickness, bool antiAliasing, float[] strokeDashArray) : 
				base(color, thickness, antiAliasing, strokeDashArray)
		{
		}
		
		public SolidPenStyleAndroid(AndroidContext context, uint color, bool antiAliasing, float thickness, AndroidComplexUnitType unit, float[] strokeDashArray) : 
				base(context, color, antiAliasing, thickness, unit, strokeDashArray)
		{
		}
		
		public SolidPenStyleAndroid(AndroidContext context, System.Drawing.Color color, bool antiAliasing, float thickness, AndroidComplexUnitType unit, float[] strokeDashArray) : 
				base(context, color, antiAliasing, thickness, unit, strokeDashArray)
		{
		}
		
		public SolidPenStyleAndroid(int color, bool antiAliasing, float thickness, float[] strokeDashArray) : 
				base(color, antiAliasing, thickness, strokeDashArray)
		{
		}
		
		public SciChart.Xamarin.Views.Core.Common.INativeSciChartObject NativeSciChartObject
		{
			get
			{
				return this;
			}
		}
	}
	
	public partial class AndroidFactory
	{
		
		public SciChart.Xamarin.Views.Visuals.RenderableSeries.IFastLineRenderableSeries NewFastLineRenderableSeries()
		{
			return new FastLineRenderableSeriesAndroid();
		}
		
		public SciChart.Xamarin.Views.Visuals.RenderableSeries.IFastCandlestickRenderableSeries NewFastCandlestickRenderableSeries()
		{
			return new FastCandlestickRenderableSeriesAndroid();
		}
		
		public SciChart.Xamarin.Views.Visuals.Axes.INumericAxis NewNumericAxis()
		{
			return new NumericAxisAndroid();
		}
		
		public SciChart.Xamarin.Views.Model.DataSeries.IXyDataSeries<TX,TY> NewXyDataSeries<TX, TY>()
			where TX : System.IComparable
			where TY : System.IComparable
		{
			return new XyDataSeriesAndroid<TX,TY>();
		}
		
		public SciChart.Xamarin.Views.Model.DataSeries.IOhlcDataSeries<TX,TY> NewOhlcDataSeries<TX, TY>()
			where TX : System.IComparable
			where TY : System.IComparable
		{
			return new OhlcDataSeriesAndroid<TX,TY>();
		}
		
		public SciChart.Xamarin.Views.Model.IDoubleRange NewDoubleRange(double min, double max)
		{
			return new DoubleRangeAndroid(min, max);
		}
		
		public SciChart.Xamarin.Views.Model.IDoubleRange NewDoubleRange()
		{
			return new DoubleRangeAndroid();
		}
		
		public SciChart.Xamarin.Views.Visuals.Annotations.IBoxAnnotation NewBoxAnnotation()
		{
			return new BoxAnnotationAndroid();
		}
		
		public SciChart.Xamarin.Views.Modifiers.IZoomPanModifier NewZoomPanModifier()
		{
			return new ZoomPanModifierAndroid();
		}
		
		public SciChart.Xamarin.Views.Modifiers.IPinchZoomModifier NewPinchZoomModifier()
		{
			return new PinchZoomModifierAndroid();
		}
		
		public SciChart.Xamarin.Views.Modifiers.ITooltipModifier NewTooltipModifier()
		{
			return new TooltipModifierAndroid();
		}
		
		public SciChart.Xamarin.Views.Modifiers.IZoomExtentsModifier NewZoomExtentsModifier()
		{
			return new ZoomExtentsModifierAndroid();
		}
		
		public SciChart.Xamarin.Views.Modifiers.IModifierGroup NewModifierGroup()
		{
			return new ModifierGroupAndroid();
		}
		
		public SciChart.Xamarin.Views.Drawing.ISolidPenStyle NewSolidPenStyle(System.Drawing.Color color, float thickness, bool antiAliasing, float[] strokeDashArray)
		{
			return new SolidPenStyleAndroid(color, thickness, antiAliasing, strokeDashArray);
		}
		
		public SciChart.Xamarin.Views.Drawing.ISolidBrushStyle NewSolidBrushStyle(System.Drawing.Color color)
		{
			return new SolidBrushStyleAndroid(color);
		}
		
		public SciChart.Xamarin.Views.Drawing.ILinearGradientBrushStyle NewLinearGradientBrushStyle(float x0, float y0, float x1, float y1, System.Drawing.Color startColor, System.Drawing.Color endColor)
		{
			return new LinearGradientBrushStyleAndroid(x0, y0, x1, y1, startColor, endColor);
		}
		
		public SciChart.Xamarin.Views.Drawing.IFontStyle NewFontStyle(float textSize, System.Drawing.Color textColor)
		{
			return new FontStyleAndroid(textSize, textColor);
		}
		
		public SciChart.Xamarin.Views.Visuals.Axes3D.INumericAxis3D NewNumericAxis3D()
		{
			return new NumericAxis3DAndroid();
		}
	}
}
