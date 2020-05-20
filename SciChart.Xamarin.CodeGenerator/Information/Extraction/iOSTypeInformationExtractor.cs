using System;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Information.Extraction
{
    public class iOSTypeInformationExtractor : MobileTypeInformationExtractorBase<iOSTypeInformation>
    {
        protected override void ExtractClassDeclaration(Type type, ClassDeclaration classDeclaration,
            iOSTypeInformation information)
        {
            var nativeType = classDeclaration.NativeIosType;
            var wrapperType = $"{nativeType}iOS";

            if (wrapperType.StartsWith("SCI"))
            {
                wrapperType = wrapperType.Remove(0, 3);
            }

            information.BaseType = nativeType;
            information.Type = wrapperType;
        }
    }
}