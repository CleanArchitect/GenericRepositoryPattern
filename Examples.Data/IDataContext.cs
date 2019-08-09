using Examples.Domain;

namespace Examples.Data
{
    internal interface IDataContext : IUnitOfWork
    {
        IDataSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}
