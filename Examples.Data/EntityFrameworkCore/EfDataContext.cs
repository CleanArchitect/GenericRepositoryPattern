using Examples.Domain;
using Examples.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Examples.Data.EntityFrameworkCore
{
    internal sealed class EfDataContext : DbContext, IDataContext
    {
        internal DbSet<Example> Examples { get; set; }

        internal EfDataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        async Task IUnitOfWork.SaveChangesAsync()
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
