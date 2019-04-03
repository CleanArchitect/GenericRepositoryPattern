using Examples.Data.Entities;
using System.Linq;

namespace Examples.UseCases.Shared
{
    public static class EntityQueries
    {
        public static IQueryable<TEntity> WithCreatedByUser<TEntity>(this IQueryable<TEntity> queryable, string user) where TEntity : IEntity
        {
            if (string.IsNullOrEmpty(user))
                return queryable;

            return queryable.Where(entity => entity.CreatedByUser == user);
        }
    }
}
