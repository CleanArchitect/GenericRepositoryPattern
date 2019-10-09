using Microsoft.Extensions.DependencyInjection;

namespace Domain.PizzaCompany
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddUseCases();
            services.AddMessaging();
        }
    }
}
