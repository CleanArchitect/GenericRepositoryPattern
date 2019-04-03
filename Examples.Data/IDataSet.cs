using Examples.Data.Entities;
using System.Linq;

namespace Examples.Data
{
    public interface IDataSet<TEntity> : IQueryable<TEntity> where TEntity : IEntity
    {
        TEntity Find(int id);
        
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
