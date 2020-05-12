using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;
using Mono.Cecil;
using SciChart.Xamarin.CodeGenerator.Code;
using SciChart.Xamarin.CodeGenerator.Generator;
using SciChart.Xamarin.Views.Generation;

namespace SciChart.Xamarin.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = GetProjectRoot();
            var androidFile = Path.Combine(root, "SciChart.Xamarin.Android.Renderer", "SciChartAndroidWrappers.cs");
            var iosFile = Path.Combine(root, "SciChart.Xamarin.iOS.Renderer", "SciChartiOSWrappers.cs");

            var types = Assembly.GetAssembly(typeof(ClassDeclaration)).GetTypes().ToList();

            var classes = types.Where(t => Attribute.IsDefined(t, typeof(ClassDeclaration))).ToList();
            var factories = types.Where(t => Attribute.IsDefined(t, typeof(SciChartObjectFactory)))
                .SelectMany(factory => factory.GetMethods()).Where(method => Attribute.IsDefined(method, typeof(FactoryMethod))).ToList();
            
            var androidGenerator = new AndroidGenerator("3.1.0.4268");
            var iosGenerator = new iOSGenerator("3.1.0.4935");

            androidGenerator.AddTypes(classes);
            iosGenerator.AddTypes(classes);

            androidGenerator.AddFactories(factories);
            iosGenerator.AddFactories(factories);

            androidGenerator.SaveTo(androidFile);
            iosGenerator.SaveTo(iosFile);
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
