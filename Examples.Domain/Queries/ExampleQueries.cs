using Examples.Data.Entities;
using Examples.UseCases.Shared;
using System.Linq;

namespace Examples.Domain.Queries
{
    public static class ExampleQueries
    {
        public static IQueryable<Example> WithExampleString(this IQueryable<Example> queryable, string query, StringOperator? stringOperator)
        {
            if (string.IsNullOrEmpty(query))
                return queryable;

            return queryable.Where(x => x.ExampleString.Matches(query, stringOperator));
        }

        public static IQueryable<Example> WithExampleBoolean(this IQueryable<Example> queryable, bool? query)
        {
            if (!query.HasValue)
                return queryable;

            return queryable.Where(x => x.ExampleBoolean.Equals(query));
        }

        public static IQueryable<Example> WithExampleInt(this IQueryable<Example> queryable, int? query, IntOperator? intOperator = IntOperator.Equals)
        {
            if (!query.HasValue)
                return queryable;

            return queryable.Where(x => x.ExampleInt.Matches(query, intOperator));
        }
    }
}
