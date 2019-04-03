using Examples.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Examples.Data.MongoDb
{
    public class MongoDbSet<TEntity> : IDataSet<TEntity> where TEntity : Entity
    {
        private readonly IMongoCollection<TEntity> mongoCollection;

        public Type ElementType => mongoCollection.AsQueryable().ToList().AsQueryable().ElementType;

        public Expression Expression => mongoCollection.AsQueryable().ToList().AsQueryable().Expression;

        public IQueryProvider Provider => mongoCollection.AsQueryable().ToList().AsQueryable().Provider;

        public MongoDbSet(IMongoCollection<TEntity> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        TEntity IDataSet<TEntity>.Find(int id)
        {
            return mongoCollection.Find(doc => doc.Id == id).SingleOrDefault();
        }

        void IDataSet<TEntity>.Add(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Exists("_id");

            entity.Id = mongoCollection.Find(filter).ToList().Max(x => x.Id) + 1;

            mongoCollection.InsertOne(entity);
        }

        void IDataSet<TEntity>.Update(TEntity entity)
        {
            mongoCollection.ReplaceOne(doc => doc.Id == entity.Id, entity);
        }

        void IDataSet<TEntity>.Remove(TEntity entity)
        {
            mongoCollection.DeleteOne(doc => doc.Id == entity.Id);
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return mongoCollection.AsQueryable().ToList().AsQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
