using System;
using Examples.Domain.UseCases;

namespace Examples.Domain.Entities
{
    public class Example : BaseEntity
    {
        public string ExampleString { get; protected set; }

        public bool? ExampleBoolean { get; protected set; }

        public int? ExampleInt { get; protected set; }

        private Example() { }

        public Example(string exampleString, bool? exampleBoolean, int? exampleInt)
        {
            ExampleString = exampleString;
            ExampleBoolean = exampleBoolean;
            ExampleInt = exampleInt;
        }

        internal void Update(UpdateExampleInput input)
        {
            ExampleString = input.ExampleString;
            ExampleInt = input.ExampleInt;
            ExampleBoolean = input.ExampleBoolean;
        }
    }

    internal static class ExampleQueries
    {
        internal static bool IsComplete(this Example example)
        {
            return !string.IsNullOrEmpty(example.ExampleString) && example.ExampleBoolean.HasValue && example.ExampleInt.HasValue;
        }

        internal static bool HasExampleBoolean(this Example example, bool? exampleBoolean)
        {
            if (!exampleBoolean.HasValue)
            {
                return true;
            }

            return example.ExampleBoolean == exampleBoolean;
        }

        internal static bool HasExampleInt(this Example example, int? exampleInt)
        {
            if (!exampleInt.HasValue)
            {
                return true;
            }

            return example.ExampleInt == exampleInt;
        }

        internal static bool HasExampleString(this Example example, string exampleString)
        {
            if (string.IsNullOrEmpty(exampleString))
            {
                return true;
            }

            var contains = example.ExampleString.Contains(exampleString, StringComparison.CurrentCultureIgnoreCase);
            var startsWith = example.ExampleString.StartsWith(exampleString, StringComparison.CurrentCultureIgnoreCase);
            var equals = example.ExampleString.Equals(exampleString, StringComparison.CurrentCultureIgnoreCase);

            return contains || startsWith || equals;
        }
    }
}