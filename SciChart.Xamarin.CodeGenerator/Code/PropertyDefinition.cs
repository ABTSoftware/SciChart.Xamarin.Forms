using System.CodeDom;

namespace SciChart.Xamarin.CodeGenerator.Code
{
    public class PropertyDefinition
    {
        public string Name { get; }
        public string Type { get; }

        public PropertyDefinition(Mono.Cecil.PropertyDefinition propertyDefinition)
        {
            Name = propertyDefinition.Name;
            Type = propertyDefinition.PropertyType.Name;
        }

        public void WriteTo(CodeTypeDeclaration type)
        {
            var callbackName = $"On{Name}PropertyChanged";
            var bindableProperty = new CodeMemberField(Type, Name)
            {
                Attributes = (MemberAttributes.Public | MemberAttributes.Static | MemberAttributes.Final),
                InitExpression = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression("BindableProperty"), "Create"), new CodeExpression[]
                {
                    new CodePrimitiveExpression(Name), 
                    new CodeArgumentReferenceExpression("id"), 
                    new CodeTypeOfExpression(new CodeTypeReference(new CodeTypeParameter(Type))), 
                    new CodeTypeOfExpression(new CodeTypeReference(new CodeTypeParameter(Type))), 
                    new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("TEst"), "test"), 
                })

            };

            var property = new CodeMemberProperty()
            {
                Name = Name,
                Type = new CodeTypeReference(Type),
                HasGet = true,
                HasSet = true,
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                GetStatements = { new CodeMethodReturnStatement(new CodeCastExpression(Type, new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "GetValue", new CodeArgumentReferenceExpression(Name))))},
                SetStatements = { new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "test", new CodeArgumentReferenceExpression(Name), new CodePropertySetValueReferenceExpression()) }
            };

            var propertyChangedCallback = new CodeMemberMethod()
            {
                Name = callbackName,
                Attributes = MemberAttributes.Private | MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(void)),
                Parameters =
                {
                    new CodeParameterDeclarationExpression("BindableObject", "bindable"),
                    new CodeParameterDeclarationExpression(typeof(object), "oldValue"),
                    new CodeParameterDeclarationExpression(typeof(object), "newValue"),
                }
            };

            type.Members.Add(bindableProperty);
            type.Members.Add(property);
            type.Members.Add(propertyChangedCallback);
        }
    }
}