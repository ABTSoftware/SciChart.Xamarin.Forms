using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NativePropertyConverterDeclaration : Attribute
    {
        public string Converter { get; }

        public string NativeProperty { get; }

        public NativePropertyConverterDeclaration(string converter = null, string nativeProperty = null)
        {
            Converter = converter;
            NativeProperty = nativeProperty;
        }
    }
}