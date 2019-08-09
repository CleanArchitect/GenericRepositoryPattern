using Examples.Domain;
using System;
using System.Threading.Tasks;

namespace Examples.Data
{
    internal sealed class ReadWriteRepository<TEntity> : ReadRepository<TEntity>, IReadWriteRepository<TEntity> where TEntity : BaseEntity
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
            entity.DateCreated = DateTime.Now;
            entity.CreatedBy = authService.Identity.Name;

            await context.Set<TEntity>().AddAsync(entity);
        }

        async Task IReadWriteRepository<TEntity>.RemoveAsync(TEntity entity)
        {
            await Task.Run(() => context.Set<TEntity>().Remove(entity));
        }

        async Task IReadWriteRepository<TEntity>.UpdateAsync(TEntity entity)
        {
            entity.DateModified = DateTime.Now;
            entity.ModifiedBy = authService.Identity.Name;

            await Task.Run(() => context.Set<TEntity>().Update(entity));
        }
    }
}
