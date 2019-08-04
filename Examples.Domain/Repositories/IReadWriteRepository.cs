using System.Threading.Tasks;

namespace Examples.Domain
{
    public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        
        Task RemoveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
    }
}
