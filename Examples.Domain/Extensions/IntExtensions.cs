using System.Linq;

namespace Examples.UseCases.Shared
{
    public static class IntExtensions
    {
        /// <summary>
        /// Default IntOperator.Equals
        /// </summary>
        public static bool Matches(this int? value, int? query, IntOperator? intOperator = IntOperator.Equals)
        {
            if (!value.HasValue || !query.HasValue)
                return true;

            return value.Value.Matches(query, intOperator);
        }

        /// <summary>
        /// Default IntOperator.Equals
        /// </summary>
        public static bool Matches(this int value, int? query, IntOperator? intOperator)
        {
            if (!query.HasValue)
                return true;

            return value.Matches(query, intOperator);
        }

        private static bool Matches(this int value, int query, IntOperator intOperator)
        {
            switch (intOperator)
            {
                case IntOperator.Equals:
                    return value == query;
                case IntOperator.GreaterThan:
                    return value > query;
                case IntOperator.GreaterThanOrEqual:
                    return value >= query;
                case IntOperator.LessThan:
                    return value < query;
                case IntOperator.LessThanOrEqual:
                    return value <= query;
                default:
                    return value == query;
            }
        }
    }
}
