using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using SciChart.Xamarin.CodeGenerator.Information;
using SciChart.Xamarin.CodeGenerator.Information.Extraction;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public class iOSGenerator : MobileGeneratorBase<iOSTypeInformation>
    {
        private readonly List<TypeDefinition> _iOSNativeTypes = new List<TypeDefinition>();

        public iOSGenerator(string sciChartiOSVersion, ITypeInformationExtractor<iOSTypeInformation> typeInformationExtractor) : base(typeInformationExtractor, "iOS", "SciChart.Xamarin.iOS.Renderer")
        {
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.iOS.Charting"));
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Xamarin.iOS.Renderer.Utility"));

            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var sciChartiOS = Path.Combine(userFolder, ".nuget", "packages", "scichart.ios", sciChartiOSVersion, "lib", "Xamarin.iOS10");
            var charting = ModuleDefinition.ReadModule(Path.Combine(sciChartiOS, "SciChart.iOS.Charting.dll"));

            _iOSNativeTypes.AddRange(charting.Types);
        }

        protected override void InitType(Type classType, iOSTypeInformation information, CodeTypeDeclaration typeDeclaration)
        {
            base.InitType(classType, information, typeDeclaration);

            var nativeClassDefinition = _iOSNativeTypes.Single(definition => definition.Name == information.ReflectionBaseTypeName);
            foreach (var nativeConstructor in nativeClassDefinition.GetConstructors())
            {
                // skip internal Xamarin.iOS constructors
                if (nativeConstructor.Parameters.Count == 1 && (nativeConstructor.Parameters.First().ParameterType.FullName == "Foundation.NSObjectFlag" || nativeConstructor.Parameters.First().ParameterType.FullName == "System.IntPtr"))
                    continue;

                // skip static ctor
                if (nativeConstructor.Name == ".cctor")
                    continue;


                var constructor = new CodeConstructor()
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                };

                foreach (var parameter in nativeConstructor.Parameters)
                {
                    var parameterType = parameter.ParameterType.ToGenericName();
             
                    constructor.Parameters.Add(
                        new CodeParameterDeclarationExpression(parameterType, parameter.Name));
                    constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(parameter.Name));
                }

                if (information.InjectInitMethod)
                {
                    var initCall = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "InternalInit");

                    constructor.Statements.Add(initCall);
                }

                typeDeclaration.Members.Add(constructor);
            }
        }
    }
}