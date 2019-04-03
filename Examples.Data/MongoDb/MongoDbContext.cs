using Examples.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Examples.Data.MongoDb
{
    public class MongoDbContext : IDataContext
    {
        private readonly IMongoDatabase database;

        public MongoDbContext(IOptions<MongoDbOptions> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            this.database = client.GetDatabase(options.Value.Database);
        }

        public void SaveChanges()
        {
        }

        public IDataSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return new MongoDbSet<TEntity>(database.GetCollection<TEntity>(typeof(TEntity).Name));
        }

        public class MongoDbOptions
        {
            public string ConnectionString;
            public string Database;
        }
    }
}
