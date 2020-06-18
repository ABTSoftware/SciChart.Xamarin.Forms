using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Utility
{
    public static class ReflectionUtils
    {
        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            if (!type.IsInterface)
                return type.GetProperties();

            return (new Type[] { type })
                .Concat(type.GetInterfaces())
                .SelectMany(i => i.GetProperties());
        }

        public static IEnumerable<MethodInfo> GetPublicMethods(this Type type)
        {
            if (!type.IsInterface)
                return type.GetMethods();

            return (new Type[] { type })
                .Concat(type.GetInterfaces())
                .SelectMany(i => i.GetMethods());
        }

        public static bool HasInjectAndroidContext(this Type type)
        {
            var injectAndroidContextAttribute = typeof(InjectAndroidContext);
            if (!type.IsInterface)
                return Attribute.IsDefined(type, injectAndroidContextAttribute);

            return Attribute.IsDefined(type, injectAndroidContextAttribute) || type.GetInterfaces().Any(t => Attribute.IsDefined(t, injectAndroidContextAttribute));

        }

        public static string ToReflectedName(this string type, int genericParamsCount)
        {
            if (genericParamsCount > 0)
            {
                return $"{type}`{genericParamsCount}";
            }
            else
            {
                return type;
            }
        }
        public static string ToGenericName(this string type, (Type, string)[] genericParams)
        {
            if (genericParams != null && genericParams.Length > 0)
            {
                var genericParamsString = String.Join(",", genericParams.Select(x => x.Item2));
                return $"{type}<{genericParamsString}>";
            }
            else
            {
                return type;
            }
        }

        public static string ToGenericName(this Type type)
        {
            if (type.IsGenericType)
            {
                var genericParamsString = String.Join(",", type.GetGenericArguments().Select(x => x.Name));
                var name = type.Name.Split('`').FirstOrDefault() ?? type.Name;
                return $"{type.Namespace}.{name}<{genericParamsString}>";
            }

            if (type.IsGenericParameter)
                return type.Name;

            return $"{type.Namespace}.{type.Name}";
        }

        public static string ToGenericName(this TypeReference type)
        {
            if (type.IsGenericInstance)
            {
                var genericParamsString = String.Join(",", type.GenericParameters.Select(x => x.Name));
                var name = type.Name.Split('`').FirstOrDefault() ?? type.Name;
                return $"{type.Namespace}.{name}<{genericParamsString}>";
            }

            if (type.IsGenericParameter)
                return type.Name;

            if (type.IsArray)
                return type.FullName.Replace("0...","");

            return $"{type.Namespace}.{type.Name}";
        }

        public static string ToXamarinFormsName(this Type type)
        {
            if (Attribute.IsDefined(type, typeof(XamarinFormsWrapperDefinition)))
                return type.GetCustomAttribute<XamarinFormsWrapperDefinition>().WrapperName;

            // remove 'I' prefix from interface
            var typeName = type.Name;
            if (type.IsInterface && typeName.StartsWith('I'))
            {
                typeName = typeName.Substring(1);
            }

            // remove generic params from name
            if (type.IsGenericType)
            {
                typeName = typeName.Split('`').First();
            }

            return typeName;
        }

        public static T GetAttribute<T>(this Type type) where T : Attribute
        {
            if (Attribute.IsDefined(type, typeof(T)))
            {
                return type.GetCustomAttribute<T>();
            }
            else
            {
                return null;
            }
        }

        public static T GetAttribute<T>(this PropertyInfo property) where T : Attribute
        {
            if (Attribute.IsDefined(property, typeof(T)))
            {
                return property.GetCustomAttribute<T>();
            }
            else
            {
                return null;
            }
        }

        public static T GetAttribute<T>(this FieldInfo field) where T : Attribute
        {
            if (Attribute.IsDefined(field, typeof(T)))
            {
                return field.GetCustomAttribute<T>();
            }
            else
            {
                return null;
            }
        }
    }
}