using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    public class TypeConverterDeclaration : Attribute
    {
        public TypeConverterDeclaration(string typeConverter)
        {
            TypeConverter = typeConverter;
        }

        public string TypeConverter { get; }
    }
}