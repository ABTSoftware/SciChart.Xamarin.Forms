using System;
using System.Reflection;

namespace SciChart.Xamarin.CodeGenerator.Information
{
    public class PropertyInformation : PropertyInformationBase
    {
        public bool HasGet { get; set; }
        public bool HasSet { get; set; }
    }
}