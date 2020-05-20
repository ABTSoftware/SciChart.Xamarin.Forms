using System;

namespace SciChart.Xamarin.CodeGenerator.Information
{
    public abstract class PropertyInformationBase
    {
        public string Name { get; set; }
        public Type PropertyType { get; set; }
    }
}