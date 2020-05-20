using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BindablePropertyDefinition : Attribute
    {
        public string DefaultValue { get; }

        public BindablePropertyDefinition(string defaultValue = null)
        {
            DefaultValue = defaultValue;
        }
    }
}