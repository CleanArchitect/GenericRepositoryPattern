using Examples.Data.EntityFrameworkCore;
using Examples.Data.MongoDb;
using Examples.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Examples.Data
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddRepositories();
            services.AddMongoDb(connectionString);
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IReadWriteRepository<>), typeof(ReadWriteRepository<>));

            return services;
        }

        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDataContext, MongoDbContext>(provider =>
                new MongoDbContext(connectionString)
            );

            return services;
        }

        public static IServiceCollection AddSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IDataContext, EfDataContext>(options =>
                options.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}
