using System;
using System.Reflection;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public class iOSTypeInformationExtractor : MobileTypeInformationExtractorBase<iOSTypeInformation>
    {
        protected override void ExtractClassDeclaration(Type type, ClassDeclaration classDeclaration,
            iOSTypeInformation information)
        {
            var nativeType = classDeclaration.NativeIosType;
            var wrapperType = $"{nativeType}iOS";

            if (wrapperType.StartsWith("SCI"))
            {
                wrapperType = wrapperType.Remove(0, 3);
            }

            information.BaseType = nativeType;
            information.Type = wrapperType;
        }

        protected override NativePropertyConverterInformation GetPropertyDeclarationFrom(PropertyInfo property)

        {
            var attribute = property.GetCustomAttribute<NativePropertyConverterDeclaration>();

            return new NativePropertyConverterInformation()
            {
                Converter = attribute.IOSConverter,
                Name = property.Name,
                NativeName = attribute.IOSNativeProperty ?? property.Name,
                PropertyType = property.PropertyType
            };
        }
    }
}