using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.EntityFrameworkCore
{
    internal sealed class EfDataSet<TEntity> : IDataSet<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> dbSet;

        public EfDataSet(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        async Task<TEntity> IDataSet<TEntity>.FindAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        async Task IDataSet<TEntity>.AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        void IDataSet<TEntity>.Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        void IDataSet<TEntity>.Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        async Task<IReadOnlyCollection<TEntity>> IDataSet<TEntity>.GetAllAsync()
        {
            return await dbSet.ToArrayAsync();
        }

        async Task<IReadOnlyCollection<TEntity>> IDataSet<TEntity>.FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToArrayAsync();
        }
    }
}
