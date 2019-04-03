using System;

namespace Examples.UseCases.Shared
{
    /// <summary>
    /// Default match op alle StringOperators
    /// </summary>
    public static class StringExtensions
    {
        public static bool Matches(this string value, string query, StringOperator? stringOperator)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(query))
                return true;

            switch (stringOperator)
            {
                case StringOperator.Equals:
                    return value.Equals(query, StringComparison.CurrentCultureIgnoreCase);
                case StringOperator.Contains:
                    return value.Contains(query);
                case StringOperator.StartsWith:
                    return value.StartsWith(query);
                case StringOperator.EndsWith:
                    return value.EndsWith(query);
                default: 
                    return 
                        value.Matches(query, StringOperator.Contains) ||
                        value.Matches(query, StringOperator.Equals) ||
                        value.Matches(query, StringOperator.StartsWith) ||
                        value.Matches(query, StringOperator.EndsWith);
            }
        }
    }
}
