using Examples.Data.Entities;
using System;
using System.Security.Principal;

namespace Examples.Data
{
    public class ReadWriteRepository<TEntity> : ReadRepository<TEntity>, IReadWriteRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataContext context;
        private readonly IIdentity identity;

        public ReadWriteRepository(IDataContext context, IIdentity identity) : base (context)
        {
            this.context = context;
            this.identity = identity;
        }

        public void Add(TEntity entity)
        {            
            entity.DateCreated = DateTime.Now;
            entity.DateLastModified = DateTime.Now;
            entity.CreatedByUser = identity.Name;

            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            entity.DateLastModified = DateTime.Now;
            entity.ModifiedByUser = identity.Name;

            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
