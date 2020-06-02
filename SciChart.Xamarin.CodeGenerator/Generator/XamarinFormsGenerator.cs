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
        private readonly Dictionary<Type, string> _typeMappings = new Dictionary<Type, string>()
        {
            {typeof(Color), "XFColor"},
        };

        private readonly CodeTypeDeclaration _factoryInterfaceDeclaration;
        public XamarinFormsGenerator(ITypeInformationExtractor<XamarinFormsTypeInformation> typeInformationExtractor) : base(typeInformationExtractor, "Forms", "SciChart.Xamarin.Views")
        {
            GlobalNamespace.Imports.Add(new CodeNamespaceImport("System"));

            foreach (var xamarinFormsNamespace in Assembly.GetAssembly(typeof(INativeSciChartObject)).GetTypes().Select(x => x.Namespace).Where(x => x.StartsWith("SciChart.Xamarin.Views")))
            {
                GlobalNamespace.Imports.Add(new CodeNamespaceImport(xamarinFormsNamespace));
            }

            _factoryInterfaceDeclaration = new CodeTypeDeclaration("INativeSciChartObjectFactory")
            {
                IsPartial = true,
                IsInterface = true
            };

            CompileUnit.Namespaces.Add(new CodeNamespace("SciChart.Xamarin.Views.Core.Common")
            {
                Types = { _factoryInterfaceDeclaration }
            });

            AddTypeAliases();
        }

        private void AddTypeAliases()
        {
            foreach (var mapping in _typeMappings)
            {
                GlobalNamespace.Imports.Add(new CodeNamespaceImport($"{mapping.Value} = {mapping.Key}"));
            }
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
                        "Get", new CodeTypeReference("INativeSciChartObjectFactory")));

                var factoryName = $"New{information.Type}";
                var factoryMethod = new CodeMethodReferenceExpression(factory, factoryName);

                var factoryInterfaceMethod = new CodeMemberMethod()
                {
                    ReturnType = new CodeTypeReference(factoryConstructor.ReturnType.ToGenericName()),
                    Name = factoryName,
                };

                if (information.GenericParams != null)
                {
                    foreach (var (paramType, paramName) in information.GenericParams)
                    {
                        factoryMethod.TypeArguments.Add(paramName);

                        var codeTypeParameter = new CodeTypeParameter(paramName);
                        codeTypeParameter.Constraints.Add(paramType);
                        factoryInterfaceMethod.TypeParameters.Add(codeTypeParameter);

                    }
                }

                var sciChartFactoryInvoke = new CodeMethodInvokeExpression(factoryMethod);
                foreach (var (paramName, paramType) in factoryConstructor.Params)
                {
                    var mappedParamType = GetTypeName(paramType);
                    constructor.Parameters.Add(new CodeParameterDeclarationExpression(mappedParamType, paramName));
                    sciChartFactoryInvoke.Parameters.Add(new CodeArgumentReferenceExpression(paramName));
                    factoryInterfaceMethod.Parameters.Add(new CodeParameterDeclarationExpression(mappedParamType, paramName));
                }

                constructor.ChainedConstructorArgs.Add(sciChartFactoryInvoke);

                members.Add(constructor);

                _factoryInterfaceDeclaration.Members.Add(factoryInterfaceMethod);
            }

            AddWrapperConstructor(type, information, typeDeclaration);

            if (information.BaseType == "View")
            {
                typeDeclaration.BaseTypes.Add(typeof(IBindingContextProvider));
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
                    ReturnType = new CodeTypeReference(GetTypeName(methodInfo.ReturnType)),
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

            if (information.ImplementNativeObjectWrapperInterface)
            {
                const string variableName = "_nativeSciChartObject";
                var fieldDeclaration = new CodeMemberField()
                {
                    Name = variableName,
                    Type = new CodeTypeReference(typeof(INativeSciChartObject)),
                    Attributes = MemberAttributes.Private,
                };
                var propertyDeclaration = new CodeMemberProperty()
                {
                    Name = "NativeSciChartObject",
                    Type = new CodeTypeReference(typeof(INativeSciChartObject)),
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                    HasGet = true,
                    GetStatements = {new CodeMethodReturnStatement(new CodeVariableReferenceExpression(variableName))}
                };

                members.Add(fieldDeclaration);
                members.Add(propertyDeclaration);
            }
        }


        protected virtual void CreatePropertyFrom(Type type, PropertyInformation property, XamarinFormsTypeInformation information, CodeTypeMemberCollection members)
        {
            var propertyName = property.Name;
            var propertyType = GetTypeName(property.PropertyType);

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
            var propertyType = GetTypeName(property.PropertyType);

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

        private static void AddWrapperConstructor(Type type, XamarinFormsTypeInformation information, CodeTypeDeclaration typeDeclaration)
        {
            var wrapperConstructor = new CodeConstructor()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Parameters = { new CodeParameterDeclarationExpression(type.ToGenericName(), "nativeObject") }
            };

            if (information.BaseType == null || information.BaseType == "View")
            {
                wrapperConstructor.Statements.Add(new CodeAssignStatement(
                    new CodeVariableReferenceExpression("_nativeSciChartObject"),
                    new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("nativeObject"),
                        "NativeSciChartObject")));
            }
            else
            {
                wrapperConstructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("nativeObject"));
            }

            typeDeclaration.Members.Add(wrapperConstructor);
        }

        protected override string GetTypeName(Type type)
        {
            return _typeMappings.TryGetValue(type, out var mappedType) ? mappedType : type.FullName;
        }
    }
}