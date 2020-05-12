using System;

namespace SciChart.Xamarin.Views.Generation
{
    public class PlatformTypeInformation
    {
        public string NativeType { get; set; }
        public string ReflectionNativeTypeName { get; set; }
        public string WrapperType { get; set; }
        public string ConstructorName { get; set; }
        public (Type, string)[] GenericParams { get; set; }
        public string XamarinFormsInterface { get; set; }
    }
}