using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using SciChart.Xamarin.Views;
using SciChart.Xamarin.Views.Generation;

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public class AndroidGenerator : GeneratorBase
    {
        private readonly List<TypeDefinition> _androidNativeTypes = new List<TypeDefinition>();

        private readonly Dictionary<string, string> _typeMappings = new Dictionary<string, string>()
        {
            {"Android.App.Application", "AndroidApplication"},
            {"Android.Content.Context", "AndroidContext" },
        };

        public AndroidGenerator(string sciChartAndroidVersion) : base("Android", "SciChart.Xamarin.Android.Renderer")
        {
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Data.Model"));
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Charting.Visuals.RenderableSeries"));
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Charting.Visuals.Axes"));
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Charting.Model.DataSeries"));
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Xamarin.Android.Renderer.Utility"));

            AddTypeAliases();

            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var sciChartAndroid = Path.Combine(userFolder, ".nuget", "packages", "scichart.android", sciChartAndroidVersion, "lib", "MonoAndroid440");
            var sciChartAndroid3d = Path.Combine(userFolder, ".nuget", "packages", "scichart.android3d", sciChartAndroidVersion, "lib", "MonoAndroid440");

            var core = ModuleDefinition.ReadModule(Path.Combine(sciChartAndroid, "SciChart.Android.Core.dll"));
            var data = ModuleDefinition.ReadModule(Path.Combine(sciChartAndroid, "SciChart.Android.Data.dll"));
            var drawing = ModuleDefinition.ReadModule(Path.Combine(sciChartAndroid, "SciChart.Android.Drawing.dll"));
            var charting = ModuleDefinition.ReadModule(Path.Combine(sciChartAndroid, "SciChart.Android.Charting.dll"));
            var charting3d = ModuleDefinition.ReadModule(Path.Combine(sciChartAndroid3d, "SciChart.Android.Charting3D.dll"));

            _androidNativeTypes.AddRange(core.Types);
            _androidNativeTypes.AddRange(data.Types);
            _androidNativeTypes.AddRange(drawing.Types);
            _androidNativeTypes.AddRange(charting.Types);
            _androidNativeTypes.AddRange(charting3d.Types);
        }

        private void AddTypeAliases()
        {
            foreach (var mapping in _typeMappings)
            {
                GlobalNamespace.Imports.Add(new CodeNamespaceImport($"{mapping.Value} = {mapping.Key}"));
            }
        }

        protected override void InitType(Type classType, PlatformTypeInformation information,
            CodeTypeDeclaration typeDeclaration)
        {
            base.InitType(classType, information, typeDeclaration);

            if (Attribute.IsDefined(classType, typeof(InjectAndroidContext)))
            {
                var constructor = new CodeConstructor()
                {
                    Attributes = MemberAttributes.Public | MemberAttributes.Final,
                };

                constructor.BaseConstructorArgs.Add(
                    new CodePropertyReferenceExpression(
                        new CodeTypeReferenceExpression("AndroidApplication"), "Context")
                );

                typeDeclaration.Members.Add(constructor);
            }

            var nativeClassDefinition = _androidNativeTypes.Single(definition => definition.Name == information.ReflectionNativeTypeName);
            foreach (var nativeConstructor in nativeClassDefinition.GetConstructors())
            {
                // skip internal Xamarin.Android constructor
                if(nativeConstructor.Parameters.Count == 2 && nativeConstructor.Parameters.First().Name == "javaReference")
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
                    var parameterType = parameter.ParameterType.FullName;

                    if (_typeMappings.TryGetValue(parameterType, out var mappedType))
                        parameterType = mappedType;
                    
                    constructor.Parameters.Add(
                        new CodeParameterDeclarationExpression(parameterType, parameter.Name));
                    constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(parameter.Name));
                }
             
                typeDeclaration.Members.Add(constructor);
            }
        }

        protected override PlatformTypeInformation GetTypeInformation(ClassDeclaration declaration)
        {
            return declaration.GetInformationFor(SciChartPlatform.Android);
        }
    }
}