using Domain.Entities;
using Domain.Repositories;

namespace Data
{
    public interface IDataContext : IUnitOfWork
    {
        IDataSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
