using System;
using System.Linq;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class GenericParamsDeclaration : Attribute
    {
        public readonly string[] GenericParamNames;
        public readonly Type[] GenericParamTypes;

        public GenericParamsDeclaration(string[] genericParamNames, Type[] genericParamTypes)
        {
            GenericParamNames = genericParamNames;
            GenericParamTypes = genericParamTypes;
        }
    }
}