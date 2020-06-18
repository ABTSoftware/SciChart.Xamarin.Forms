using System;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Utility;
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

        protected override NativeMethodConverterInformation GetMethodDeclarationFrom(MethodInfo method)
        {
            var attribute = method.GetCustomAttribute<NativeMethodConverterDeclaration>();

            return new NativeMethodConverterInformation()
            {
                Name = method.Name,
                ReturnType = method.ReturnType,
                Params = method.GetParameters().Select(p => new ParameterInformation()
                {
                    Name = p.Name,
                    ParameterType = p.ParameterType.ToGenericName(),
                }).ToArray(),

                Converter = attribute.IOSConverter,
                NativeMethodName = attribute.IOSNativeMethod ?? method.Name
            };
        }


        protected override void ExtractionEnumInformationFrom(Type enumType, EnumDefinition enumDefinition, EnumConvertorInformation information)
        {
            information.NativeEnumType = enumDefinition.IOSEnumName ?? $"SCI{enumType.Name}";

            information.EnumValues = Enum.GetNames(enumType).Select(x => (x, enumType.GetField(x).GetAttribute<EnumValueDefinition>()?.IOSName ?? x)).ToArray();
        }
    }
}