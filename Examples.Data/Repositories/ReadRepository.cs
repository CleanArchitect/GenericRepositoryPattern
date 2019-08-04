using Examples.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Data
{
    internal class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IDataSet<TEntity> dataset;

        public ReadRepository(IDataContext context)
        {
            this.dataset = context.Set<TEntity>();
        }

        async Task<TEntity> IReadRepository<TEntity>.FindAsync(int key)
        {
            return await dataset.FindAsync(key);
        }

        async Task<IReadOnlyCollection<TEntity>> IReadRepository<TEntity>.GetAllAsync()
        {
            return await dataset.GetAllAsync();
        }

        async Task<IReadOnlyCollection<TEntity>> IReadRepository<TEntity>.FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dataset.FindAllAsync(predicate);
        }
    }
}
