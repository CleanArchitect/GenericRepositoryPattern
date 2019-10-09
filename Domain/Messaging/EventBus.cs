using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    internal sealed class EventBus : IEventBus
    {
        private readonly IServiceProvider serviceProvider;

        public EventBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        async Task IEventBus.RaiseEventAsync<TEvent>(TEvent raisedEvent) 
        {
            var eventHandlers = serviceProvider.GetServices<IEventHandler<TEvent>>();

            var eventHandleTasks = eventHandlers.Select(handler => handler.HandleEventAsync(raisedEvent));

            await Task.WhenAll(eventHandleTasks);
        }
    }
}
