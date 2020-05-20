using System;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public interface ITypeInformationExtractor<out T>
    {
        T GetInformationAboutType(Type type);
    }
}