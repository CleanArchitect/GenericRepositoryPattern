﻿using Examples.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Data
{
    internal interface IDataSet<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindAsync(int id);

        Task<IReadOnlyCollection<TEntity>> GetAllAsync();

        Task<IReadOnlyCollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);
        
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
