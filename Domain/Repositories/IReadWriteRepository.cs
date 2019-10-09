using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}
