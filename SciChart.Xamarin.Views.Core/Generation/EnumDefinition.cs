using System;

namespace SciChart.Xamarin.Views.Core.Generation
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class EnumDefinition : Attribute
    {
        public string IOSEnumName { get; }
        public string AndroidEnumName { get; }

        public EnumDefinition(string androidEnumName, string iosEnumName)
        {
            AndroidEnumName = androidEnumName;
            IOSEnumName = iosEnumName;
        }

        public EnumDefinition(string enumName) : this(enumName, $"SCI{enumName}")
        {

        }

        public EnumDefinition() : this(null, null)
        {

        }
    }
}