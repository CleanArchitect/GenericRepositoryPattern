using Domain.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddScoped<IEventBus, EventBus>();
            services.AddEventHandlers();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            var useCaseTypes = GetTypesThatImplementGenericInterface(typeof(IUseCase<,>));

            AddTypesToServiceCollection(services, useCaseTypes);

            return services;
        }

        private static IServiceCollection AddEventHandlers(this IServiceCollection services)
        {
            var eventHandlerTypes = GetTypesThatImplementGenericInterface(typeof(IEventHandler<>));

            AddTypesToServiceCollection(services, eventHandlerTypes);
            
            return services;
        }

        private static IEnumerable<Type> GetTypesThatImplementGenericInterface(Type genericTypeInterface)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes()
                    .Where(type => type.IsClass && !type.IsAbstract))
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition().Equals(genericTypeInterface)))
                .ToList();
        }

        private static void AddTypesToServiceCollection(IServiceCollection services, IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                foreach (var typeInterface in type.GetInterfaces())
                {
                    services.AddTransient(typeInterface, type);
                }
            }
        }
    }
}
