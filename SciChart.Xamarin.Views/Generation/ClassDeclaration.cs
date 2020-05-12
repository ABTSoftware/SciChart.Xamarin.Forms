using System;
using System.Collections.Generic;
using System.Text;

namespace SciChart.Xamarin.Views.Generation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassDeclaration : Attribute
    {
        protected readonly string _nativeAndroidType;
        protected readonly string _nativeIosType;
        protected readonly Type _xamarinFormsInterface;

        public ClassDeclaration(Type xamarinFormsInterface, string nativeAndroidType, string nativeIOSType)
        {
            _xamarinFormsInterface = xamarinFormsInterface;
            _nativeAndroidType = nativeAndroidType;
            _nativeIosType = nativeIOSType;
        }

        public PlatformTypeInformation GetInformationFor(SciChartPlatform platform)
        {
            switch (platform)
            {
                case SciChartPlatform.iOS:
                    return GetiOSTypeInformation();
                case SciChartPlatform.Android:
                    return GetAndroidTypeInformation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(platform), platform, "Unsupported Platform");
            }
        }

        protected virtual PlatformTypeInformation GetAndroidTypeInformation()
        {
            var wrapperType = $"{_nativeAndroidType}Android";
            return new PlatformTypeInformation()
            {
                NativeType = _nativeAndroidType,
                ReflectionNativeTypeName = _nativeAndroidType,
                WrapperType = wrapperType,
                ConstructorName = wrapperType,
                XamarinFormsInterface = _xamarinFormsInterface.FullName
            };
        }

        protected virtual PlatformTypeInformation GetiOSTypeInformation()
        {
            var wrapperType = $"{_nativeIosType}iOS";
            if (wrapperType.StartsWith("SCI"))
            {
                wrapperType = wrapperType.Remove(0, 3);
            }

            return new PlatformTypeInformation()
            {
                NativeType = _nativeIosType,
                ReflectionNativeTypeName = _nativeIosType,
                WrapperType = wrapperType,
                ConstructorName = wrapperType,
                XamarinFormsInterface = _xamarinFormsInterface.FullName
            };
        }
    }
}
