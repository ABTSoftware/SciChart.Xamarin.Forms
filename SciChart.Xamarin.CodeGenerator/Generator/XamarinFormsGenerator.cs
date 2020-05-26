using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Information;
using SciChart.Xamarin.CodeGenerator.Information.Extraction;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;
using Xamarin.Forms;

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public class XamarinFormsGenerator : GeneratorBase<XamarinFormsTypeInformation>
    {
        public XamarinFormsGenerator(ITypeInformationExtractor<XamarinFormsTypeInformation> typeInformationExtractor) : base(typeInformationExtractor, "Forms", "SciChart.Xamarin.Views")
        {
            GlobalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            GlobalNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Xamarin.Views.Model"));
            GlobalNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Xamarin.Views.Model.DataSeries"));
        }

        protected override void ProcessType(Type type, XamarinFormsTypeInformation information)
        {
            var typeDeclaration = new CodeTypeDeclaration(information.Type)
            {
                IsPartial = true, 
            };

            if (information.IsAbstract)
            {
                typeDeclaration.TypeAttributes |= TypeAttributes.Abstract;
            }
 
            var baseType = information.GenericBaseTypeName;
            if (baseType != null)
                typeDeclaration.BaseTypes.Add(baseType);

            typeDeclaration.BaseTypes.Add(type.ToGenericName());

            InitType(type, information, typeDeclaration);

            TryAddGenericTypeParameters(information, typeDeclaration.TypeParameters);

            var typeNamespace = new CodeNamespace(type.Namespace);
            typeNamespace.Types.Add(typeDeclaration);

            CompileUnit.Namespaces.Add(typeNamespace);
        }

        private void TryAddGenericTypeParameters(XamarinFormsTypeInformation information,
            CodeTypeParameterCollection typeParameters)
        {
            if (information.GenericParams != null)
            {
                foreach (var (genericType, genericName) in information.GenericParams)
                {
                    var param = new CodeTypeParameter(genericName);
                    param.Constraints.Add(genericType);

                    typeParameters.Add(param);
                }
            }

        }

        protected virtual void InitType(Type type, XamarinFormsTypeInformation information,
            CodeTypeDeclaration typeDeclaration)
        {
            var members = typeDeclaration.Members;

            foreach (var factoryConstructor in information.FactoryConstructors)
            {
                var constructor = new CodeConstructor()
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                };
                var factory = new CodeMethodInvokeExpression(
                    new CodeMethodReferenceExpression(
                        new CodeTypeReferenceExpression("DependencyService"),
                        "Get", new CodeTypeReference(typeof(INativeSciChartObjectFactory))));

                var sciChartFactoryInvoke = new CodeMethodInvokeExpression(factory, $"New{information.Type}");

                foreach (var (paramName, paramType) in factoryConstructor.Params)
                {
                    constructor.Parameters.Add(new CodeParameterDeclarationExpression(paramType, paramName));
                    sciChartFactoryInvoke.Parameters.Add(new CodeArgumentReferenceExpression(paramName));

                }
                constructor.BaseConstructorArgs.Add(
                    sciChartFactoryInvoke
                );

                members.Add(constructor);
            }

            foreach (var propertyInfo in information.BindableProperties)
            {
                CreateBindablePropertyFrom(type, propertyInfo, information, members);
            }

            foreach (var propertyInfo in information.Properties)
            {
                CreatePropertyFrom(type, propertyInfo, information, members);
            }

            foreach (var methodInfo in information.Methods)
            {
                var parameters = new List<CodeParameterDeclarationExpression>();
                var arguments = new List<CodeExpression>();
                foreach (var parameterInfo in methodInfo.Params)
                {
                    parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType, parameterInfo.Name));
                    arguments.Add(new CodeArgumentReferenceExpression(parameterInfo.Name));
                }

                var methodDeclaration = new CodeMemberMethod()
                {
                    Name = methodInfo.Name,
                    ReturnType = new CodeTypeReference(methodInfo.ReturnType),
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    Statements =
                    {
                        new CodeMethodInvokeExpression(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                            new CodeVariableReferenceExpression("NativeSciChartObject"),
                            "CastSciChartObject",
                            new CodeTypeReference[]
                            {
                                new CodeTypeReference(type.ToGenericName())
                            }
                        )), methodInfo.Name, arguments.ToArray())
                    }
                };

                methodDeclaration.Parameters.AddRange(parameters.ToArray());

                members.Add(methodDeclaration);
            }
        }

        protected virtual void CreatePropertyFrom(Type type, PropertyInformation property, XamarinFormsTypeInformation information, CodeTypeMemberCollection members)
        {
            var propertyName = property.Name;
            var propertyType = property.PropertyType.Name;

            var nativePropertyReference = new CodePropertyReferenceExpression(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                    new CodeVariableReferenceExpression("NativeSciChartObject"),
                    "CastSciChartObject",
                    new CodeTypeReference[]
                    {
                        new CodeTypeReference(type.ToGenericName())
                    }
                ),
                new CodeExpression[0]), propertyName);

            var propertyDeclaration = new CodeMemberProperty()
            {
                Name = propertyName,
                Type = new CodeTypeReference(propertyType),
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
            };

            if (property.HasSet)
            {
                propertyDeclaration.HasSet = true;
                propertyDeclaration.SetStatements.Add(new CodeAssignStatement(nativePropertyReference,
                    new CodePropertySetValueReferenceExpression()));
            }

            if (property.HasGet)
            {
                propertyDeclaration.HasGet = true;
                propertyDeclaration.GetStatements.Add(new CodeMethodReturnStatement(nativePropertyReference));
            }

            members.Add(propertyDeclaration);
        }

        protected virtual void CreateBindablePropertyFrom(Type type, BindablePropertyInformation property, XamarinFormsTypeInformation information, CodeTypeMemberCollection members)
        {
            var propertyName = property.Name;
            var propertyType = property.PropertyType.Name;

            var callbackName = $"On{propertyName}PropertyChanged";
            var defaultValueCreator = $"Default{propertyName}PropertyValueCreator";

            var bindablePropertyClassName = typeof(BindableProperty).Name;
            var bindablePropertyName = $"{propertyName}Property";
            var bindableProperty = new CodeMemberField(bindablePropertyClassName, bindablePropertyName)
            {
                Attributes = (MemberAttributes.Public | MemberAttributes.Static | MemberAttributes.Final),
                InitExpression = new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeTypeReferenceExpression(bindablePropertyClassName), "Create"), new CodeExpression[]
                {
                    new CodePrimitiveExpression(propertyName),
                    new CodeTypeOfExpression(new CodeTypeReference(new CodeTypeParameter(propertyType))),
                    new CodeTypeOfExpression(new CodeTypeReference(new CodeTypeParameter(information.Type))),
                    new CodePrimitiveExpression(null), 
                    new CodePropertyReferenceExpression(new CodeTypeReferenceExpression(typeof(BindingMode).Name), nameof(BindingMode.Default)), 
                    new CodePrimitiveExpression(null), 
                    new CodeArgumentReferenceExpression(callbackName), 
                    new CodePrimitiveExpression(null), 
                    new CodePrimitiveExpression(null), 
                    new CodeArgumentReferenceExpression(defaultValueCreator), 
                })

            };

            var propertyDeclaration = new CodeMemberProperty()
            {
                Name = propertyName,
                Type = new CodeTypeReference(propertyType),
                HasGet = true,
                HasSet = true,
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                GetStatements = { 
                    new CodeMethodReturnStatement(new CodeCastExpression(propertyType, 
                    new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "GetValue", new CodeArgumentReferenceExpression(bindablePropertyName)))
                ) },
                SetStatements =
                {
                    new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "SetValue", new CodeArgumentReferenceExpression(bindablePropertyName), new CodePropertySetValueReferenceExpression())
                }
            };

            var nativePropertyReference = new CodePropertyReferenceExpression(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(
                    new CodeVariableReferenceExpression("bindable"),
                    "CastBindableWrapper",
                    new CodeTypeReference[]
                    {
                        new CodeTypeReference(type)
                    }
                ),
                new CodeExpression[0]), propertyName);
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
                }, Statements =
                {
                    new CodeAssignStatement(nativePropertyReference, 
                        new CodeCastExpression(propertyType, new CodeVariableReferenceExpression("newValue"))
                        )
                }
            };

            var defaultValueCreatorCallback = new CodeMemberMethod()
            {
                Name = defaultValueCreator,
                Attributes = MemberAttributes.Private | MemberAttributes.Static,
                ReturnType = new CodeTypeReference(typeof(object)),
                Parameters =
                {
                    new CodeParameterDeclarationExpression("BindableObject", "bindable"),
                },
                Statements =
                {
                    new CodeMethodReturnStatement(nativePropertyReference)
                }
            };

            members.Add(bindableProperty);
            members.Add(propertyDeclaration);
            members.Add(propertyChangedCallback);
            members.Add(defaultValueCreatorCallback);

        }
    }
}