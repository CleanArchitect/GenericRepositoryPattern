using Examples.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Data
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataContext context;
        private readonly IDataSet<TEntity> dataset;

        public ReadRepository(IDataContext context)
        {
            this.context = context;
            this.dataset = context.Set<TEntity>();
        }

        public TEntity Find(int key)
        {
            return dataset.Find(key);
        }

        public IList<TEntity> GetAll()
        {
            return dataset.ToList();
        }

        public IQueryable<TEntity> Query()
        {
            return dataset;
        }
    }
}
