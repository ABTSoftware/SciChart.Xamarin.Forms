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
        protected MobileGeneratorBase(ITypeInformationExtractor<T> typeInformationExtractor, string platform, string mainNamespace) : base(typeInformationExtractor, platform, mainNamespace)
        {
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

            return new CodeMemberProperty()
            {
                Name = propertyName,
                Type = new CodeTypeReference(GetTypeName(information.PropertyType)),
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                HasGet = true,
                HasSet = true,
                GetStatements =
                {
                    new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), nativePropertyName), $"{converter}ToXamarin"))
                },
                SetStatements =
                { 
                    new CodeAssignStatement()
                    {
                        Left = new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), nativePropertyName),
                        Right = new CodeMethodInvokeExpression(new CodePropertySetValueReferenceExpression(), $"{converter}FromXamarin")
                    }
                }
            };
        }

        protected string GetTypeName(Type type)
        {
            var typeName = type.FullName;
            if (typeName.StartsWith("Xamarin.Forms.")) return typeName.Replace("Xamarin.Forms.", "");

            return typeName;
        }

        public void AddFactories(IEnumerable<MethodInfo> factoryMethods)
        {
            var factory = new CodeTypeDeclaration($"{Platform}Factory")
            {
                IsPartial = true,
            };

            foreach (var factoryMethod in factoryMethods)
            {
                ProcessFactory(factoryMethod, factory);
            }

            MainNamespace.Types.Add(factory);
        }

        private void ProcessFactory(MethodInfo factoryMethodInfo, CodeTypeDeclaration factory)
        {
            var returnType = factoryMethodInfo.ReturnType;
            var information = _typeInformationExtractor.GetInformationAboutType(returnType);

            var parameters = new List<CodeParameterDeclarationExpression>();
            var arguments = new List<CodeExpression>();
            foreach (var parameterInfo in factoryMethodInfo.GetParameters())
            {
                parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType, parameterInfo.Name));
                arguments.Add(new CodeArgumentReferenceExpression(parameterInfo.Name));
            }

            var factoryMethod = new CodeMemberMethod()
            {
                ReturnType = new CodeTypeReference(returnType.ToGenericName()),
                Name = $"New{information.Type.Replace(Platform, "")}",
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Statements =
                {
                    new CodeMethodReturnStatement(new CodeObjectCreateExpression(information.GenericTypeName, arguments.ToArray()))
                }
            };

            factoryMethod.Parameters.AddRange(parameters.ToArray());

            TryAddGenericTypeParameters(information, factoryMethod.TypeParameters);

            factory.Members.Add(factoryMethod);
        }
    }
}