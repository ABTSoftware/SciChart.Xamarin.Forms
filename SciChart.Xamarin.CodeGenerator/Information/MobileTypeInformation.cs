namespace SciChart.Xamarin.CodeGenerator.Information
{
    public abstract class MobileTypeInformation : TypeInformationBase
    {
        public NativePropertyConverterInformation[] NativePropertyConverters { get; set; }

        public NativeMethodConverterInformation[] NativeMethodConverters { get; set; }
    }
}