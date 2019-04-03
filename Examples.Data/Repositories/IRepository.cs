using Examples.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Data
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        TEntity Find(int key);

        IList<TEntity> GetAll();

        IQueryable<TEntity> Query();
    }

    public interface IReadWriteRepository<TEntity> : IReadRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        
        void Remove(TEntity entity);

        void Update(TEntity entity);
    }
}
