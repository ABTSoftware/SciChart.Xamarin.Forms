using System;

namespace SciChart.Xamarin.CodeGenerator.Information
{
    public class MethodInformation
    {
        public string Name { get; set; }
        public Type ReturnType { get; set; }

        public ParameterInformation[] Params { get; set; }
    }

    public struct ParameterInformation
    {
        public string Name { get; set; }
        public Type ParameterType { get; set; }
    }
}