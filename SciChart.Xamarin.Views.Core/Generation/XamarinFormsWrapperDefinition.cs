using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class XamarinFormsWrapperDefinition : Attribute
    {
        public XamarinFormsWrapperDefinition(string wrapperName)
        {
            WrapperName = wrapperName;
        }

        public string WrapperName { get; }
    }
}