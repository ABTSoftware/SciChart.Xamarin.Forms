using System;
using System.Linq;

namespace SciChart.Xamarin.Views.Generation
{
    public class GenericClassDeclaration : ClassDeclaration
    {
        public readonly string[] _genericParamNames;

        public GenericClassDeclaration(Type xamarinFormsInterface, string nativeAndroidType, string nativeIOSType, params string[] genericParamNames) : base(xamarinFormsInterface, nativeAndroidType, nativeIOSType)
        {
            _genericParamNames = genericParamNames;
        }

        protected override PlatformTypeInformation GetAndroidTypeInformation()
        {
            var information = base.GetAndroidTypeInformation();

            var genericParameterType = _xamarinFormsInterface.GenericTypeArguments;
            information.GenericParams = genericParameterType.Zip(_genericParamNames, (type, name) => (type, name)).ToArray();

            var nativeType = information.NativeType;
            information.NativeType = GetGenericName(nativeType);
            information.ReflectionNativeTypeName = GetReflectedName(nativeType);
            information.WrapperType = $"{nativeType}Android";
            information.XamarinFormsInterface =
                information.XamarinFormsInterface.Split('`').Select(GetGenericName).FirstOrDefault() ??
                information.XamarinFormsInterface;

            information.ConstructorName = GetGenericName(information.WrapperType);

            return information;
        }

        protected override PlatformTypeInformation GetiOSTypeInformation()
        {
            var information = base.GetiOSTypeInformation();

            var genericParameterType = _xamarinFormsInterface.GenericTypeArguments;
            information.GenericParams = genericParameterType.Zip(_genericParamNames, (type, name) => (type, name)).ToArray();

            var nativeType = information.NativeType;
            information.NativeType = GetGenericName(nativeType);
            information.ReflectionNativeTypeName = GetReflectedName(nativeType);
            information.WrapperType = $"{nativeType}iOS";
            information.XamarinFormsInterface =
                information.XamarinFormsInterface.Split('`').Select(GetGenericName).FirstOrDefault() ??
                information.XamarinFormsInterface;

            information.ConstructorName = GetGenericName(information.WrapperType);

            return information;
        }
        private string GetGenericName(string typename)
        {
            var genericParamsString = string.Join(",", _genericParamNames);
            return $"{typename}<{genericParamsString}>";
        }

        private string GetReflectedName(string typename)
        {
            return $"{typename}`{_genericParamNames.Length}";
        }
    }
}