using System;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public abstract class MobileTypeInformationExtractorBase<T> : TypeInformationExtractorBase<T> where T : MobileTypeInformation
    {
        protected override void ExtractInformationFrom(Type type, T information)
        {
            base.ExtractInformationFrom(type, information);

            information.NativePropertyConverters = type.GetPublicProperties()
                .Where(property => Attribute.IsDefined(property, typeof(NativePropertyConverterDeclaration)))
                .Select(GetPropertyDeclarationFrom).ToArray();
        }

        protected abstract NativePropertyConverterInformation GetPropertyDeclarationFrom(PropertyInfo property);

        public EnumConvertorInformation ExtractEnumInformation(Type enumType)
        {
            var enumDeclaration = enumType.GetCustomAttribute<EnumDefinition>();

            var information = new EnumConvertorInformation();

            ExtractionEnumInformationFrom(enumType, enumDeclaration, information);

            return information;
        }

        protected virtual void ExtractionEnumInformationFrom(Type enumType, EnumDefinition enumDefinition, EnumConvertorInformation information)
        {
            information.EnumValues = Enum.GetNames(enumType).Select(x => (x, x)).ToArray();
        }
    }
}