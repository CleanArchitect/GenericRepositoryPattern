using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Examples.Domain
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddUseCases();
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            var useCaseTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract)
                .Where(type => typeof(IUseCase).IsAssignableFrom(type));

            foreach (var useCaseType in useCaseTypes)
            {
                foreach (var useCaseInterface in useCaseType.GetInterfaces())
                {
                    services.AddTransient(useCaseInterface, useCaseType);
                }
            }

            return services;
        }
    }
}
