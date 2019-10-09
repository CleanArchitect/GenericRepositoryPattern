using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindAsync(int key);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<IReadOnlyCollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
