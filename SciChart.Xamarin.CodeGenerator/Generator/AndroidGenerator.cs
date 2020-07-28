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
    public class AndroidGenerator : MobileGeneratorBase<AndroidTypeInformation>
    {
        private readonly List<TypeDefinition> _androidNativeTypes = new List<TypeDefinition>();

        private readonly Dictionary<string, string> _typeMappings = new Dictionary<string, string>()
        {
            {"Android.App.Application", "AndroidApplication"},
            {"Android.Content.Context", "AndroidContext"},
            {"Android.Util.IAttributeSet", "IAndroidAttributesSet"},
            {"Android.Util.ComplexUnitType", "AndroidComplexUnitType"},
            {"Android.Graphics.Typeface", "AndroidTypeface"},
            {"SciChart.Charting.Modifiers.AxisDragModifierBase.AxisDragMode", "AxisDragMode" }
        };

        public AndroidGenerator(string sciChartAndroidVersion, ITypeInformationExtractor<AndroidTypeInformation> typeInformationExtractor) : base(typeInformationExtractor, "Android", "SciChart.Xamarin.Android.Renderer")
        {
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

            // import all SciChart namespaces in Xamarin.Android wrapper
            foreach (var androidNativeNamespace in _androidNativeTypes.Select(x => x.Namespace).Where(x => x.StartsWith("SciChart.")))
            {
                MainNamespace.Imports.Add(new CodeNamespaceImport(androidNativeNamespace));
            }
            
            MainNamespace.Imports.Add(new CodeNamespaceImport("SciChart.Xamarin.Android.Renderer.Utility"));

            AddTypeAliases();
        }

        private void AddTypeAliases()
        {
            foreach (var mapping in _typeMappings)
            {
                GlobalNamespace.Imports.Add(new CodeNamespaceImport($"{mapping.Value} = {mapping.Key}"));
            }
        }

        protected override void InitType(Type classType, AndroidTypeInformation information,
            CodeTypeDeclaration typeDeclaration)
        {
            base.InitType(classType, information, typeDeclaration);

            if (information.InjectContextIntoConstructor)
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

            var nativeClassDefinition = _androidNativeTypes.Single(definition => definition.Name == information.ReflectionBaseTypeName);
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
                    var parameterType = parameter.ParameterType.ToGenericName();

                    if (_typeMappings.TryGetValue(parameterType, out var mappedType))
                        parameterType = mappedType;
                    
                    constructor.Parameters.Add(
                        new CodeParameterDeclarationExpression(parameterType, parameter.Name));
                    constructor.BaseConstructorArgs.Add(new CodeArgumentReferenceExpression(parameter.Name));
                }
             
                typeDeclaration.Members.Add(constructor);
            }
        }
    }
}