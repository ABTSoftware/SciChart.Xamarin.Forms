using System;

namespace SciChart.Xamarin.Views.Generation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyDeclaration : Attribute
    {
        public string Converter { get; }

        public string NativeProperty { get; }

        public PropertyDeclaration(string converter, string nativeProperty = null)
        {
            Converter = converter;
            NativeProperty = nativeProperty;
        }
    }
}