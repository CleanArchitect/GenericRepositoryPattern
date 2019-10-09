using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.EntityFrameworkCore
{
    public abstract class BaseEfDbContext : DbContext, IDataContext
    {
        protected BaseEfDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        async Task IUnitOfWork.SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        IDataSet<TEntity> IDataContext.Set<TEntity>()
        {
            var dbSet = Set<TEntity>();

            return new EfDataSet<TEntity>(dbSet);
        }
    }
}
