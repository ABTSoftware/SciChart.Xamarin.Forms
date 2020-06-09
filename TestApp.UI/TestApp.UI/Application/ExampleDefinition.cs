using System;

namespace TestApp.UI.Application
{
    public enum ExampleIcon
    {
        Annotations,
        Axis,
        BandChart,
        BubbleChart,
        CandlestickChart,
        ColumnChart,
        CubeChart,
        DigitalLine,
        ErrorBars,
        Fan,
        FeatureChart,
        HeatmapChart,
        Impulse,
        LineChart,
        MountainChart,
        Ohlc,
        PieChart,
        RealTime,
        ScatterChart,
        StackedBar,
        StackedColumn,
        StackedColumns100,
        StackedMountainChart,
        Themes,
        ZoomPan,

        Axis3D,
        Scatter3D,
        Surface3D,
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExampleDefinition : Attribute
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ExampleIcon? Icon { get; set; }

        public ExampleDefinition(string title, string description, ExampleIcon icon)
        {
            Title = title;
            Description = description;
            Icon = icon;
        }
    }
}