using System;

namespace SciChart.Xamarin.Views.Generation
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FactoryMethod : Attribute
    {
        public Type ReturnType { get; }

        public FactoryMethod(Type returnType)
        {
            ReturnType = returnType;
        }
    }

    [AttributeUsage(AttributeTargets.Interface)]
    public class SciChartObjectFactory : Attribute
    {

    }
}