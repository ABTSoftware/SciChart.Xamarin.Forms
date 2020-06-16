using System;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public class AndroidTypeInformationExtractor : MobileTypeInformationExtractorBase<AndroidTypeInformation>
    {
        protected override void ExtractInformationFrom(Type type, AndroidTypeInformation information)
        {
            base.ExtractInformationFrom(type, information);

            information.InjectContextIntoConstructor = type.HasInjectAndroidContext();
        }

        protected override void ExtractClassDeclaration(Type type, ClassDeclaration classDeclaration,
            AndroidTypeInformation information)
        {
            var nativeType = classDeclaration.NativeAndroidType;
            var wrapperType = $"{nativeType}Android";

            information.BaseType = nativeType;
            information.Type = wrapperType;
        }

        protected override NativePropertyConverterInformation GetPropertyDeclarationFrom(PropertyInfo property)

        {
            var attribute = property.GetCustomAttribute<NativePropertyConverterDeclaration>();

            return new NativePropertyConverterInformation()
            {
                Converter = attribute.AndroidConverter,
                Name = property.Name,
                NativeName = attribute.AndroidNativeProperty ?? property.Name,
                PropertyType = property.PropertyType
            };
        }

        protected override void ExtractionEnumInformationFrom(Type enumType, EnumDefinition enumDefinition, EnumConvertorInformation information)
        {
            base.ExtractionEnumInformationFrom(enumType, enumDefinition, information);

            information.NativeEnumType = enumDefinition.AndroidEnumName ?? enumType.Name;
        }
    }
}