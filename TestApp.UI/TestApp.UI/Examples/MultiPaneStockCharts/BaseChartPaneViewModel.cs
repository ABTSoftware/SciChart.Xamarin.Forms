using System;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Model;
using SciChart.Xamarin.Views.Model.ObservableCollection;
using SciChart.Xamarin.Views.Modifiers;
using SciChart.Xamarin.Views.Visuals.Axes;
using SciChart.Xamarin.Views.Visuals.Synchronization;
using TestApp.UI.Common;

namespace TestApp.UI.Examples.MultiPaneStockCharts
{
    public class BaseChartPaneViewModel : BaseViewModel
    {
        protected BaseChartPaneViewModel(SciChartVerticalGroup verticalGroup, DoubleRange xRange, string yAxisTextFormatting, bool isMainPane = false)
        {
            VerticalGroup = verticalGroup;

            var legendModifier = new LegendModifier() {ReceiveHandledEvents = true};
            legendModifier.SetShowCheckboxes(false);

            ChartModifiers = new ChartModifierCollection
            {
                new XAxisDragModifier
                {
                    DragMode = AxisDragMode.Pan, ClipModeX = ClipMode.StretchAtExtents,
                    ReceiveHandledEvents = true
                },
                new PinchZoomModifier {Direction = Direction2D.XDirection, ReceiveHandledEvents = true},
                new ZoomPanModifier() {ReceiveHandledEvents = true},
                new ZoomExtentsModifier() {ReceiveHandledEvents = true},
                legendModifier,
            };

            XAxes = new AxisCollection()
            {
                new CategoryDateTimeAxis()
                {
                    GrowBy = new DoubleRange(0, 0.05),
                    DrawLabels = isMainPane,
                    DrawMajorGridLines = isMainPane,
                    DrawMinorTicks = isMainPane,
                    VisibleRange = xRange
                }
            };

            YAxes = new AxisCollection()
            {
                new NumericAxis()
                {
                    AutoRange = AutoRange.Always,
                    MinorsPerMajor = (uint) (isMainPane ? 4 : 2),
                    MaxAutoTicks = (uint) (isMainPane ? 8 : 4),
                    GrowBy = isMainPane ? new DoubleRange(0.05, 0.05) : new DoubleRange(0, 0),
                    TextFormatting = yAxisTextFormatting
                }
            };
        }
        
        public RenderableSeriesCollection RenderableSeries { get; } = new RenderableSeriesCollection();

        public AxisCollection XAxes { get; }

        public AxisCollection YAxes { get; }

        public ChartModifierCollection ChartModifiers { get; }

        public AnnotationCollection Annotations { get; } = new AnnotationCollection();

        public SciChartVerticalGroup VerticalGroup { get; }
    }
}