﻿using System;
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

        private static NativePropertyConverterInformation GetPropertyDeclarationFrom(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<NativePropertyConverterDeclaration>();

            return new NativePropertyConverterInformation()
            {
                Converter = attribute.Converter,
                Name = property.Name,
                NativeName = attribute.NativeProperty ?? property.Name,
                PropertyType = property.PropertyType
            };
        }
    }
}