using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class ReadWriteRepository<TEntity> : ReadRepository<TEntity>, IReadWriteRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataContext context;
        private readonly IAuthService authService;

        IUnitOfWork IReadWriteRepository<TEntity>.UnitOfWork => context;

        public ReadWriteRepository(
            IDataContext context, 
            IAuthService authService) : base (context)
        {
            this.context = context;
            this.authService = authService;
        }

        async Task IReadWriteRepository<TEntity>.AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        async Task IReadWriteRepository<TEntity>.RemoveAsync(TEntity entity)
        {
            await Task.Run(() => context.Set<TEntity>().Remove(entity));
        }

        async Task IReadWriteRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            await Task.Run(() => context.Set<TEntity>().Update(entity));
        }
    }
}
