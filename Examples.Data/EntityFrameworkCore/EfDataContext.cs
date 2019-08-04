using Examples.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Examples.Data.EntityFrameworkCore
{
    internal sealed class EfDataContext : DbContext, IDataContext
    {
        public DbSet<Example> Examples { get; set; }

        public EfDataContext(DbContextOptions options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        async Task IDataContext.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        IDataSet<TEntity> IDataContext.Set<TEntity>()
        {
            var dbSet = base.Set<TEntity>();

            return new EfDataSet<TEntity>(dbSet);
        }
    }
}
