using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NativePropertyConverterDeclaration : Attribute
    {
        public string AndroidConverter { get; }

        public string IOSConverter { get; }

        public string AndroidNativeProperty { get; }

        public string IOSNativeProperty { get; }

        public NativePropertyConverterDeclaration(string converter = null, string nativeProperty = null) : this(converter, nativeProperty, converter, nativeProperty)
        {
        }

        public NativePropertyConverterDeclaration(string androidConverter, string androidNativeProperty,
            string iOSConverter, string iOSNativeProperty)
        {
            AndroidConverter = androidConverter;
            AndroidNativeProperty = androidNativeProperty;
            IOSConverter = iOSConverter;
            IOSNativeProperty = iOSNativeProperty;
        }
    }
}