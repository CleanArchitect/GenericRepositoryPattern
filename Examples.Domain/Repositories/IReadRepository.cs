using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Domain
{
    public interface IReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindAsync(int key);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<IReadOnlyCollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
