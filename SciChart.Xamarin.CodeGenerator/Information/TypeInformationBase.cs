using System;
using System.Collections.Generic;
using System.Linq;
using SciChart.Xamarin.CodeGenerator.Utility;

namespace SciChart.Xamarin.CodeGenerator.Information
{
    public abstract class TypeInformationBase
    {
        public string BaseType { get; set; }

        public string Type { get; set; }

        public (Type, string)[] GenericParams { get; set; }

        public bool IsAbstract { get; set; }

        public PropertyInformation[] Properties { get; set; }

        public virtual string ReflectionBaseTypeName => BaseType.ToReflectedName(GenericParams?.Length ?? 0);

        public virtual string GenericBaseTypeName => BaseType.ToGenericName(GenericParams);
        public virtual string GenericTypeName => Type.ToGenericName(GenericParams);

        public FactoryCtorInformation[] FactoryConstructors { get; set; }
    }
}