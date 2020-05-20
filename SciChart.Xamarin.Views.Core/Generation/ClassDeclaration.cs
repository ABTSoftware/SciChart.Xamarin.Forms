using System;
using SciChart.Xamarin.Views.Core.Common;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class ClassDeclaration : Attribute
    {
        public readonly string NativeAndroidType;
        public readonly string NativeIosType;
        public readonly Type BaseXamarinFormsType;

        public ClassDeclaration(string nativeAndroidType, string nativeIOSType, Type baseXamarinFormsType)
        {
            NativeAndroidType = nativeAndroidType;
            NativeIosType = nativeIOSType;
            BaseXamarinFormsType = baseXamarinFormsType;
        }
    }
}
