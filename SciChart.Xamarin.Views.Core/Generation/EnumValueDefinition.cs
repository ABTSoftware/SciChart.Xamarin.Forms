using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumValueDefinition : Attribute
    {
        public string AndroidName { get; }
        public string IOSName { get; }

        public EnumValueDefinition(string androidName, string iOSName)
        {
            AndroidName = androidName;
            IOSName = iOSName;
        }
    }
}