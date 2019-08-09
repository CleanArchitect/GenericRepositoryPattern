using Examples.Domain;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Examples.Data.MongoDb
{
    internal sealed class MongoDbContext : IDataContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public MongoDbContext(string connectionString)
        {
            this.client = new MongoClient(connectionString);
            this.database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }

        async Task IUnitOfWork.SaveChangesAsync() => await Task.CompletedTask;

        IDataSet<TEntity> IDataContext.Set<TEntity>()
        {
            return new MongoDbSet<TEntity>(database.GetCollection<TEntity>(typeof(TEntity).Name));
        }
    }
}
