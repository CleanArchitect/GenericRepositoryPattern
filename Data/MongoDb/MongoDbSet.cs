using Domain.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.MongoDb
{
    internal sealed class MongoDbSet<TEntity> : IDataSet<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> mongoCollection;

        public MongoDbSet(IMongoCollection<TEntity> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        async Task<TEntity> IDataSet<TEntity>.FindAsync(int id)
        {
            return await mongoCollection.Find(doc => doc.Id == id).SingleOrDefaultAsync();
        }

        async Task IDataSet<TEntity>.AddAsync(TEntity entity)
        {
            var lastEntity = await mongoCollection
                .AsQueryable()
                .OrderByDescending(doc => doc.Id)
                .FirstOrDefaultAsync();

            entity.Id = lastEntity?.Id + 1 ?? 1;

            await mongoCollection.InsertOneAsync(entity);
        }

        void IDataSet<TEntity>.Update(TEntity entity)
        {
            mongoCollection.ReplaceOne(doc => doc.Id == entity.Id, entity);
        }

        void IDataSet<TEntity>.Remove(TEntity entity)
        {
            mongoCollection.DeleteOne(doc => doc.Id == entity.Id);
        }

        async Task<IReadOnlyCollection<TEntity>> IDataSet<TEntity>.GetAllAsync()
        {
            return await ((IQueryable<TEntity>)mongoCollection.AsQueryable())
                .ToAsyncEnumerable()
                .ToArray();
        }

        async Task<IReadOnlyCollection<TEntity>> IDataSet<TEntity>.FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ((IQueryable<TEntity>)mongoCollection.AsQueryable())
                .Where(predicate.Compile())
                .ToAsyncEnumerable()
                .ToArray();
        }
    }
}
