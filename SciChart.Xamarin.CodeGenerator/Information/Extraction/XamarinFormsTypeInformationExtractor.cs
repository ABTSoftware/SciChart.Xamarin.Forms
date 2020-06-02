using System;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public class XamarinFormsTypeInformationExtractor : TypeInformationExtractorBase<XamarinFormsTypeInformation>
    {
        protected override void ExtractInformationFrom(Type type, XamarinFormsTypeInformation information)
        {
            base.ExtractInformationFrom(type, information);

            information.BindableProperties = type.GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(BindablePropertyDefinition)))
                .Select(x =>
                    new BindablePropertyInformation()
                    {
                        Name = x.Name,
                        PropertyType = x.PropertyType
                    }).ToArray();

            information.Methods = type.GetMethods()
                .Where(m => Attribute.IsDefined(m, typeof(MethodDeclaration)))
                .Select(x => new MethodInformation()
                {
                    Name = x.Name,
                    ReturnType = x.ReturnType,
                    Params = x.GetParameters().Select(p => new ParameterInformation()
                    {
                        Name = p.Name,
                        ParameterType = p.ParameterType.ToGenericName()
                    }).ToArray()
                })
                .ToArray();
        }

        protected override void ExtractClassDeclaration(Type type, ClassDeclaration classDeclaration,
            XamarinFormsTypeInformation information)
        {
            information.Type = type.ToXamarinFormsName();

            var baseXamarinFormsType = classDeclaration.BaseXamarinFormsType;
            if (baseXamarinFormsType != null)
            {
                information.IsBaseTypeGeneric = baseXamarinFormsType.IsGenericType;
                information.BaseType = baseXamarinFormsType.ToXamarinFormsName();
            }

            var allInterfaces = type.GetInterfaces();
            var baseInterfaces = baseXamarinFormsType?.GetInterfaces() ?? new Type[0];

            information.ImplementNativeObjectWrapperInterface = allInterfaces.Except(baseInterfaces).Any(t => t == typeof(INativeSciChartObjectWrapper));
        }
    }
}