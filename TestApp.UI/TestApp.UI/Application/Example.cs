﻿using System;
using System.Linq;
using System.Reflection;

namespace TestApp.UI.Application
{
    public class Example
    {
        public Type ExampleType { get; }
        public string Title { get; }
        public string Description { get; }
        public ExampleIcon? Icon { get; }

        public Example(Type exampleType)
        {
            ExampleType = exampleType;

            var attribute = exampleType.GetCustomAttributes<ExampleDefinition>().Single();

            Title = attribute.Title;
            Description = attribute.Description;
            Icon = attribute.Icon;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}