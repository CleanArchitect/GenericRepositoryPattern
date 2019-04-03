using Examples.Data.Entities;
using System;
using System.Linq;

namespace Examples.UseCases.Shared
{
    public static class PeriodEntityQueries
    {
        public static IQueryable<TEntity> InPeriod<TEntity>(this IQueryable<TEntity> queryable, DateTime? fromDate, DateTime? toDate) where TEntity : PeriodEntity
        {
            if (!fromDate.HasValue || !toDate.HasValue)
                return queryable;

            return queryable.Where(example => 
                example.DatumStart.Value.Date <= toDate && 
                !example.DatumEinde.HasValue || 
                example.DatumEinde.Value.Date >= fromDate.Value.Date);
        }
    }
}
