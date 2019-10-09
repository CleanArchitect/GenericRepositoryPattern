using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.PizzaCompany
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddSqlServer<PizzaCompanyDataContext>(configuration, lazyLoading: true);
        }
    }
}
