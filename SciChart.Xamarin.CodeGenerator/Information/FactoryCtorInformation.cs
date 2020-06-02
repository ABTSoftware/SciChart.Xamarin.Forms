using System;
using System.Collections.Generic;

namespace SciChart.Xamarin.CodeGenerator.Information
{
    public class FactoryCtorInformation
    {
        public string[] ParamNames { get; set; }
        public Type[] ParamTypes { get; set; }

        public Type ReturnType { get; set; }

        public IEnumerable<(string, Type)> Params
        {
            get
            {
                if (ParamNames != null && ParamTypes != null && ParamNames.Length == ParamTypes.Length)
                {
                    for (int i = 0; i < ParamNames.Length; i++)
                    {
                        yield return (ParamNames[i], ParamTypes[i]);
                    }
                }
            }
        }
    }
}