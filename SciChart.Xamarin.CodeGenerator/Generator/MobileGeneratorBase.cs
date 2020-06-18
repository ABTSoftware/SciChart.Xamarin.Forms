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

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public abstract class MobileGeneratorBase<T> : GeneratorBase<T> where T : MobileTypeInformation
    {
        private readonly CodeTypeDeclaration _factoryDeclaration;

        protected MobileGeneratorBase(ITypeInformationExtractor<T> typeInformationExtractor, string platform, string mainNamespace) : base(typeInformationExtractor, platform, mainNamespace)
        {
            _factoryDeclaration = new CodeTypeDeclaration($"{Platform}Factory")
            {
                IsPartial = true,
            };

        }

        public override void AddTypes(IEnumerable<Type> types)
        {
            base.AddTypes(types);

            MainNamespace.Types.Add(_factoryDeclaration);
        }

        protected override void ProcessType(Type type, T information)
        {
            if (information.IsAbstract) 
                return;

            var baseNativeType = information.GenericBaseTypeName;
            var nativeWrapperName = information.Type;
            var typeDeclaration = new CodeTypeDeclaration(nativeWrapperName)
            {
                BaseTypes = { baseNativeType, type.ToGenericName(), typeof(INativeSciChartObject) },
                IsPartial = true,
            };

            InitType(type, information, typeDeclaration);

            TryAddGenericTypeParameters(information, typeDeclaration.TypeParameters);

            MainNamespace.Types.Add(typeDeclaration);

            foreach (var factoryCtorInformation in information.FactoryConstructors)
            {
                ProcessFactory(factoryCtorInformation);
            }
        }

        private void TryAddGenericTypeParameters(T information, CodeTypeParameterCollection typeParameters)
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

        protected virtual void InitType(Type classType, T information,
            CodeTypeDeclaration typeDeclaration)
        {
            var members = typeDeclaration.Members;

            foreach (var converter in information.NativePropertyConverters)
            {
                members.Add(CreateNativePropertyConverterFrom(converter));
            }

            foreach (var converter in information.NativeMethodConverters)
            {
                members.Add(CreateNativeMethodConverterFrom(converter));
            }

            members.Add(new CodeMemberProperty()
            {
                Name = "NativeSciChartObject",
                Type = new CodeTypeReference(typeof(INativeSciChartObject)),
                HasGet = true,
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                GetStatements = {new CodeMethodReturnStatement(new CodeThisReferenceExpression())}
            });
        }

        private CodeMemberProperty CreateNativePropertyConverterFrom(NativePropertyConverterInformation information)
        {
            var propertyName = information.Name;
            var nativePropertyName = information.NativeName;
            var converter = information.Converter;

            var nativeProperty = new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), nativePropertyName);

            CodeExpression setter;
            CodeExpression getter;
            if (converter != null)
            {
                getter = new CodeMethodInvokeExpression(nativeProperty, $"{converter}ToXamarin");
                setter = new CodeMethodInvokeExpression(new CodePropertySetValueReferenceExpression(), $"{converter}FromXamarin");
            }
            else
            {
                getter = nativeProperty;
                setter = new CodePropertySetValueReferenceExpression();
            }

            var attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (propertyName == nativePropertyName)
                attributes |= MemberAttributes.New;

            return new CodeMemberProperty()
            {
                Name = propertyName,
                Type = new CodeTypeReference(GetTypeName(information.PropertyType)),
                Attributes = attributes,
                HasGet = true,
                HasSet = true,
                GetStatements =
                {
                    new CodeMethodReturnStatement(getter)
                },
                SetStatements =
                { 
                    new CodeAssignStatement()
                    {
                        Left = nativeProperty,
                        Right = setter                    }
                }
            };
        }

        private CodeMemberMethod CreateNativeMethodConverterFrom(NativeMethodConverterInformation information)
        {
            var methodName = information.Name;
            var nativeMethodName = information.NativeMethodName;
            var converter = information.Converter;

            var attributes = MemberAttributes.Public | MemberAttributes.Final;
            if (methodName == nativeMethodName)
                attributes |= MemberAttributes.New;

            var methodDeclaration = new CodeMemberMethod()
            {
                Name = methodName,
                Attributes = attributes,
                ReturnType = new CodeTypeReference(information.ReturnType),
            };

            var parameters = new List<CodeParameterDeclarationExpression>();
            var arguments = new List<CodeExpression>();
            foreach (var parameterInfo in information.Params)
            {
                parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType, parameterInfo.Name));
                arguments.Add(new CodeArgumentReferenceExpression(parameterInfo.Name));
            }

            var nativeMethodCall = new CodeMethodInvokeExpression(new CodeBaseReferenceExpression(), nativeMethodName, arguments.ToArray());

            // call converter extensions if it's present
            if (converter != null)
                nativeMethodCall = new CodeMethodInvokeExpression(nativeMethodCall, $"{converter}ToXamarin");

            if (information.ReturnType != typeof(void))
            {
                methodDeclaration.Statements.Add(new CodeMethodReturnStatement(nativeMethodCall));
            }
            else
            {
                methodDeclaration.Statements.Add(nativeMethodCall);
            }

            methodDeclaration.Parameters.AddRange(parameters.ToArray());

            return methodDeclaration;
        }

        protected override string GetTypeName(Type type)
        {
            var typeName = type.FullName;
            if (typeName.StartsWith("Xamarin.Forms.")) return typeName.Replace("Xamarin.Forms.", "");

            return typeName;
        }

        private void ProcessFactory(FactoryCtorInformation factoryMethodInfo)
        {
            var returnType = factoryMethodInfo.ReturnType;
            var information = _typeInformationExtractor.GetInformationAboutType(returnType);

            var parameters = new List<CodeParameterDeclarationExpression>();
            var arguments = new List<CodeExpression>();
            foreach (var (paramName, paramType) in factoryMethodInfo.Params)
            {
                parameters.Add(new CodeParameterDeclarationExpression(GetTypeName(paramType), paramName));
                arguments.Add(new CodeArgumentReferenceExpression(paramName));
            }

            var factoryName = $"New{returnType.ToXamarinFormsName()}";
            var factoryMethod = new CodeMemberMethod()
            {
                ReturnType = new CodeTypeReference(returnType.ToGenericName()),
                Name = factoryName,
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Statements =
                {
                    new CodeMethodReturnStatement(new CodeObjectCreateExpression(information.GenericTypeName, arguments.ToArray()))
                }
            };

            factoryMethod.Parameters.AddRange(parameters.ToArray());

            TryAddGenericTypeParameters(information, factoryMethod.TypeParameters);

            _factoryDeclaration.Members.Add(factoryMethod);
        }

        public void AddEnumMappings(IEnumerable<Type> enums)
        {
            if(!(_typeInformationExtractor is MobileTypeInformationExtractorBase<T> mobileInformationExtractor)) return;

            foreach (var enumToMap in enums)
            {
                var information = mobileInformationExtractor.ExtractEnumInformation(enumToMap);
                DefineEnumMapping(enumToMap, information);
            }
        }

        private void DefineEnumMapping(Type enumToMap, EnumConvertorInformation information)
        {
            var name = enumToMap.Name;

            var helperClassDeclaration = new CodeTypeDeclaration($"{name}Mapper")
            {
                Attributes = MemberAttributes.Public
            };

            // CodeDom doesn't support static classes so need to hack it to add static keyword
            helperClassDeclaration.StartDirectives.Add(new CodeRegionDirective(CodeRegionMode.Start, $"{name} extensions" + Environment.NewLine + "\tstatic"));
            helperClassDeclaration.EndDirectives.Add(new CodeRegionDirective(CodeRegionMode.End, string.Empty));

            var nativeValue = "nativeValue";
            var formsValue = "xamarinFormsValue";

            // CodeDom doesn't support extensions so need to hack it to add this as part of type declaration
            var toXamarinMethod = new CodeMemberMethod()
            {
                Name = $"{name}ToXamarin",
                Attributes = MemberAttributes.Public | MemberAttributes.Static,
                Parameters = { new CodeParameterDeclarationExpression($"this {information.NativeEnumType}", nativeValue)},
                ReturnType = new CodeTypeReference(enumToMap)
            };

            var fromXamarinMethod = new CodeMemberMethod()
            {
                Name = $"{name}FromXamarin",
                Attributes = MemberAttributes.Public | MemberAttributes.Static,
                Parameters = { new CodeParameterDeclarationExpression($"this {enumToMap.FullName}", formsValue)},
                ReturnType = new CodeTypeReference(information.NativeEnumType)
            };

            foreach (var (xamarinEnumName, nativeEnumName) in information.EnumValues)
            {
                var nativeEnumValue = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(new CodeTypeReference(information.NativeEnumType)), nativeEnumName);
                var nativeValueEqualCheck = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(nativeValue), CodeBinaryOperatorType.IdentityEquality, nativeEnumValue);

                var xamarinEnumValue = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(enumToMap), xamarinEnumName);
                var xamarinValueEqualCheck = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(formsValue), CodeBinaryOperatorType.IdentityEquality, xamarinEnumValue);

                var xamarinMapping = new CodeConditionStatement(xamarinValueEqualCheck, new CodeMethodReturnStatement(nativeEnumValue));
                var nativeMapping = new CodeConditionStatement(nativeValueEqualCheck, new CodeMethodReturnStatement(xamarinEnumValue));

                fromXamarinMethod.Statements.Add(xamarinMapping);
                toXamarinMethod.Statements.Add(nativeMapping);
            }

            // throw exception if there is no mapping
            var codeThrowExceptionStatement = new CodeThrowExceptionStatement( new CodeObjectCreateExpression(new CodeTypeReference(typeof(ArgumentOutOfRangeException)), new CodePrimitiveExpression($"The {name} value has not been handled")));
            toXamarinMethod.Statements.Add(codeThrowExceptionStatement);
            fromXamarinMethod.Statements.Add(codeThrowExceptionStatement);

            helperClassDeclaration.Members.Add(toXamarinMethod);
            helperClassDeclaration.Members.Add(fromXamarinMethod);

            MainNamespace.Types.Add(helperClassDeclaration);
        }
    }
}