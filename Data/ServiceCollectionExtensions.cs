using Data.EntityFrameworkCore;
using Data.MongoDb;
using Data.Repositories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDataContext, MongoDbContext>(provider =>
                new MongoDbContext(connectionString)
            );

            return services;
        }

        public static IServiceCollection AddSqlServer<TDataContext>(
            this IServiceCollection services,
            IConfiguration configuration,
            bool lazyLoading = false) where TDataContext : BaseEfDbContext
        {
            var connectionString = configuration.GetConnectionString("SqlExpress");

            services.AddDbContext<IDataContext, TDataContext>(options =>
            {
                options.UseSqlServer(connectionString);

                if (lazyLoading)
                {
                    options.UseLazyLoadingProxies();
                }
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IReadWriteRepository<>), typeof(ReadWriteRepository<>));

            return services;
        }
    }
}
