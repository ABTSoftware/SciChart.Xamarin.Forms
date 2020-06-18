using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NativeMethodConverterDeclaration : Attribute
    {
        public string AndroidConverter { get; }

        public string IOSConverter { get; }

        public string AndroidNativeMethod { get; }

        public string IOSNativeMethod { get; }

        public NativeMethodConverterDeclaration(string converter = null, string nativeMethod = null) : this(converter, nativeMethod, converter, nativeMethod)
        {
        }

        public NativeMethodConverterDeclaration(string androidConverter, string androidNativeMethod,
            string iOSConverter, string iOSNativeMethod)
        {
            AndroidConverter = androidConverter;
            AndroidNativeMethod = androidNativeMethod;
            IOSConverter = iOSConverter;
            IOSNativeMethod = iOSNativeMethod;
        }
    }
}