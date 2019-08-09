using Examples.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Data
{
    internal class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDataContext context;

        public ReadRepository(IDataContext context)
        {
            this.context = context;
        }

        async Task<TEntity> IReadRepository<TEntity>.FindAsync(int key)
        {
            return await context.Set<TEntity>().FindAsync(key);
        }

        async Task<IReadOnlyCollection<TEntity>> IReadRepository<TEntity>.GetAllAsync()
        {
            return await context.Set<TEntity>().GetAllAsync();
        }

        async Task<IReadOnlyCollection<TEntity>> IReadRepository<TEntity>.FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FindAllAsync(predicate);
        }
    }
}
