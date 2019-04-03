using Examples.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examples.Data.EntityFrameworkCore
{
    public class EfDataContext : DbContext, IDataContext
    {
        public DbSet<Example> Examples { get; set; }

        public EfDataContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        void IDataContext.SaveChanges()
        {
            base.SaveChanges();
        }

        IDataSet<TEntity> IDataContext.Set<TEntity>()
        {
            var dbSet = base.Set<TEntity>();

            return new EfDataSet<TEntity>(dbSet);
        }
    }
}
