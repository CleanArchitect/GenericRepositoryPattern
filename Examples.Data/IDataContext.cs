using Examples.Data.Entities;

namespace Examples.Data
{
    public interface IDataContext
    {
        IDataSet<TEntity> Set<TEntity>() where TEntity : Entity;

        void SaveChanges();
    }
}
