using System;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public abstract class TypeInformationExtractorBase<T> : ITypeInformationExtractor<T> where T : TypeInformationBase
    {
        public T GetInformationAboutType(Type type)
        {
            var instance = Activator.CreateInstance<T>();

            ExtractInformationFrom(type, instance);

            return instance;
        }

        protected virtual void ExtractInformationFrom(Type type, T information)
        {
            ExtractClassDeclaration(type, type.GetCustomAttribute<ClassDeclaration>(), information);

            if(Attribute.IsDefined(type, typeof(GenericParamsDeclaration)))
                ExtractGenericClassParams(type.GetCustomAttribute<GenericParamsDeclaration>(), information);

            if (Attribute.IsDefined(type, typeof(AbstractClassDefinition)))
                information.IsAbstract = true;

            information.Properties = type.GetProperties()
                .Where(property => Attribute.IsDefined(property, typeof(PropertyDeclaration)))
                .Select(x => new PropertyInformation()
                {
                    Name = x.Name,
                    PropertyType = x.PropertyType,
                    HasSet = x.GetSetMethod() != null,
                    HasGet = x.GetGetMethod() != null,
                }).ToArray();
        }

        protected abstract void ExtractClassDeclaration(Type type, ClassDeclaration classDeclaration, T information);

        private void ExtractGenericClassParams(GenericParamsDeclaration genericParamsDeclaration, T information)
        {
            information.GenericParams = genericParamsDeclaration.GenericParamNames.Zip(genericParamsDeclaration.GenericParamTypes, (s, type) => (type, s)).ToArray();
        }
    }
}