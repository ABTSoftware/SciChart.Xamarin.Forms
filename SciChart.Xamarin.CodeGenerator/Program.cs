using System;
using System.IO;
using System.Linq;
using System.Reflection;
using SciChart.Xamarin.CodeGenerator.Generator;
using SciChart.Xamarin.CodeGenerator.Information;
using SciChart.Xamarin.CodeGenerator.Information.Extraction;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = GetProjectRoot();
            var androidFile = Path.Combine(root, "SciChart.Xamarin.Android.Renderer", "SciChartAndroidWrappers.cs");
            var iosFile = Path.Combine(root, "SciChart.Xamarin.iOS.Renderer", "SciChartiOSWrappers.cs");
            var formsFile = Path.Combine(root, "SciChart.Xamarin.Views", "SciChartFormsClasses.cs");

            var types = Assembly.GetAssembly(typeof(IBindingContextProvider)).GetTypes().ToList();

            var classes = types.Where(t => Attribute.IsDefined(t, typeof(ClassDeclaration))).ToList();
            var factories = types.Where(t => Attribute.IsDefined(t, typeof(SciChartObjectFactory)))
                .SelectMany(factory => factory.GetMethods()).ToList();
            
            var androidGenerator = new AndroidGenerator("3.1.0.4268", new AndroidTypeInformationExtractor());
            var iosGenerator = new iOSGenerator("3.1.0.4935", new iOSTypeInformationExtractor());
            var formsGenerator = new FormsGenerator(new XamarinFormsTypeInformationExtractor());

            androidGenerator.AddTypes(classes);
            iosGenerator.AddTypes(classes);
            formsGenerator.AddTypes(classes);

            androidGenerator.AddFactories(factories);
            iosGenerator.AddFactories(factories);

            androidGenerator.SaveTo(androidFile);
            iosGenerator.SaveTo(iosFile);
            formsGenerator.SaveTo(formsFile);
        }

        private static string GetProjectRoot()
        {
            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (currentDirectory.Name != "SciChart.Xamarin.Forms")
            {
                currentDirectory = currentDirectory.Parent;
            }

            var root = currentDirectory.FullName;
            return root;
        }
    }
}
