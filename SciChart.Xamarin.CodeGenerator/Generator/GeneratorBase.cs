using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;
using SciChart.Xamarin.CodeGenerator.Information;
using SciChart.Xamarin.CodeGenerator.Information.Extraction;
using SciChart.Xamarin.CodeGenerator.Utility;
using SciChart.Xamarin.Views.Core.Common;
using SciChart.Xamarin.Views.Core.Generation;

namespace SciChart.Xamarin.CodeGenerator.Generator
{
    public abstract class GeneratorBase<T>
    {
        protected readonly ITypeInformationExtractor<T> _typeInformationExtractor;

        protected GeneratorBase(ITypeInformationExtractor<T> typeInformationExtractor, string platform, string mainNamespace)
        {
            _typeInformationExtractor = typeInformationExtractor;
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

        public virtual void AddTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                ProcessType(type, _typeInformationExtractor.GetInformationAboutType(type));
            }
        }

        protected abstract void ProcessType(Type type, T information);

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

            Console.WriteLine($"{path}: File was generate successfully");
        }

        protected virtual string GetTypeName(Type type)
        {
            return type.FullName;
        }
    }
}