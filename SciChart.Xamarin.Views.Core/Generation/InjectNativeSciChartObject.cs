using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = true)]
    public class InjectNativeSciChartObject : Attribute
    {
        public string[] ParamNames { get; }
        public Type[] ParamTypes { get; }

        public InjectNativeSciChartObject() : this(null, null)
        {

        }

        public InjectNativeSciChartObject(string[] paramNames, Type[] paramTypes)
        {
            ParamNames = paramNames;
            ParamTypes = paramTypes;
        }
    }
}