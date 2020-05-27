namespace SciChart.Xamarin.CodeGenerator.Information
{
    public class XamarinFormsTypeInformation : TypeInformationBase
    {
        public BindablePropertyInformation[] BindableProperties { get; set; }

        public MethodInformation[] Methods { get; set; }

        public bool IsBaseTypeGeneric { get; set; }

        public override string ReflectionBaseTypeName => IsBaseTypeGeneric ? base.ReflectionBaseTypeName : BaseType;

        public override string GenericBaseTypeName => IsBaseTypeGeneric ? base.GenericBaseTypeName : BaseType;

        public XamarinFormsFactoryCtorInformation[] FactoryConstructors { get; set; }

        public bool ImplementNativeObjectWrapperInterface { get; set; }
    }
}