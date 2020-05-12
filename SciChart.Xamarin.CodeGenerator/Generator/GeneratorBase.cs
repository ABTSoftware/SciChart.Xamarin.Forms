using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;
using SciChart.Xamarin.Views.Common;
using SciChart.Xamarin.Views.Generation;

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public abstract class GeneratorBase
    {
        protected GeneratorBase(string platform, string mainNamespace)
        {
            Platform = platform;

            CompileUnit = new CodeCompileUnit();
            GlobalNamespace = new CodeNamespace();
            MainNamespace = new CodeNamespace(mainNamespace);

            GlobalNamespace.Imports.Add(new CodeNamespaceImport("Xamarin.Forms"));

            CompileUnit.Namespaces.Add(GlobalNamespace);
            CompileUnit.Namespaces.Add(MainNamespace);
        }

        public CodeCompileUnit CompileUnit { get; }

        public string Platform { get; }

        protected CodeNamespace MainNamespace { get; }

        protected CodeNamespace GlobalNamespace { get; }

        public void AddTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                ProcessType(type);
            }
        }

        protected virtual void ProcessType(Type classType)
        {
            var attribute = classType.GetCustomAttribute<ClassDeclaration>();

            var information = GetTypeInformation(attribute);
            var baseNativeType = information.NativeType;
            var nativeWrapperName = information.WrapperType;
            var xamarinFormsInterface = information.XamarinFormsInterface;
            var type = new CodeTypeDeclaration(nativeWrapperName)
            {
                BaseTypes = { baseNativeType, xamarinFormsInterface, typeof(INativeSciChartObject) },
                IsPartial = true,
            };

            InitType(classType, information, type);

            TryAddGenericTypeParameters(information, type.TypeParameters);

            MainNamespace.Types.Add(type);
        }

        private void TryAddGenericTypeParameters(PlatformTypeInformation information,
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

        protected virtual void InitType(Type classType, PlatformTypeInformation information,
            CodeTypeDeclaration typeDeclaration)
        {
            var members = typeDeclaration.Members;

            foreach (var propertyInfo in classType.GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(PropertyDeclaration))))
            {
                members.Add(CreatePropertyFrom(propertyInfo));
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

        protected abstract PlatformTypeInformation GetTypeInformation(ClassDeclaration declaration);

        protected virtual CodeMemberProperty CreatePropertyFrom(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<PropertyDeclaration>();

            var propertyName = property.Name;
            var nativePropertyName = attribute.NativeProperty ?? propertyName;
           
            return new CodeMemberProperty()
            {
                Name = propertyName,
                Type = new CodeTypeReference(GetTypeName(property.PropertyType)),
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                HasGet = true,
                HasSet = true,
                GetStatements =
                {
                    new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), nativePropertyName), $"{attribute.Converter}ToXamarin"))
                },
                SetStatements =
                { 
                    new CodeAssignStatement()
                    {
                        Left = new CodePropertyReferenceExpression(new CodeBaseReferenceExpression(), nativePropertyName),
                        Right = new CodeMethodInvokeExpression(new CodePropertySetValueReferenceExpression(), $"{attribute.Converter}FromXamarin")
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
                var attribute = factoryMethod.GetCustomAttribute<FactoryMethod>();
                ProcessFactory(factoryMethod, attribute.ReturnType, factory);
            }

            MainNamespace.Types.Add(factory);
        }

        private void ProcessFactory(MethodInfo factoryMethodInfo, Type returnType, CodeTypeDeclaration factory)
        {
            var attribute = returnType.GetCustomAttribute<ClassDeclaration>();

            var information = GetTypeInformation(attribute);

            var parameters = new List<CodeParameterDeclarationExpression>();
            var arguments = new List<CodeExpression>();
            foreach (var parameterInfo in factoryMethodInfo.GetParameters())
            {
                parameters.Add(new CodeParameterDeclarationExpression(parameterInfo.ParameterType, parameterInfo.Name));
                arguments.Add(new CodeArgumentReferenceExpression(parameterInfo.Name));
            }

            var factoryMethod = new CodeMemberMethod()
            {
                ReturnType = new CodeTypeReference(information.XamarinFormsInterface),
                Name = $"New{information.WrapperType.Replace(Platform, "")}",
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Statements =
                {
                    new CodeMethodReturnStatement(new CodeObjectCreateExpression(information.ConstructorName, arguments.ToArray()))
                }
            };

            factoryMethod.Parameters.AddRange(parameters.ToArray());

            TryAddGenericTypeParameters(information, factoryMethod.TypeParameters);

            factory.Members.Add(factoryMethod);
        }

        public void SaveTo(string path)
        {
            var options = new CodeGeneratorOptions
            {
                IndentString = "\t",
                BlankLinesBetweenMembers = true,
                BracingStyle = "C"
            };

            var provider = new CSharpCodeProvider();
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                provider.GenerateCodeFromCompileUnit(CompileUnit, writer, options);
            }
        }
    }
}