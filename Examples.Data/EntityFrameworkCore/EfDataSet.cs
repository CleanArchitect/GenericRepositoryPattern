using Examples.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Examples.Data.EntityFrameworkCore
{
    public class EfDataSet<TEntity> : IDataSet<TEntity> where TEntity : Entity
    {
        private readonly DbSet<TEntity> dbSet;

        public Type ElementType => ((IQueryable<TEntity>)dbSet).ElementType;

        public Expression Expression => ((IQueryable<TEntity>)dbSet).Expression;

        public IQueryProvider Provider => ((IQueryable<TEntity>)dbSet).Provider;

        public EfDataSet(DbSet<TEntity> dbSet)
        {
            this.dbSet = dbSet;
        }

        TEntity IDataSet<TEntity>.Find(int id)
        {
            return dbSet.Find(id);
        }

        void IDataSet<TEntity>.Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        void IDataSet<TEntity>.Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        void IDataSet<TEntity>.Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return ((IQueryable<TEntity>)dbSet).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)dbSet).GetEnumerator();
        }
    }
}
