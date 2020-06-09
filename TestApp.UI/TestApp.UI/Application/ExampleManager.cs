using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestApp.UI.Application
{
    public class ExampleManager
    {
        private static ExampleManager _exampleManager;

        public static ExampleManager Instance => _exampleManager ?? (_exampleManager = new ExampleManager());

        public List<Example> Examples { get; }

        private ExampleManager()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().ToList();

            Examples = types.Where(t => Attribute.IsDefined(t, typeof(ExampleDefinition))).Select(t => new Example(t)).OrderBy(ex => ex.Title).ToList();
        }
    }
}