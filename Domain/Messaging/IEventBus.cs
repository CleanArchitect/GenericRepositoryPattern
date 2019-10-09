using System.Threading.Tasks;

namespace Domain
{
    public interface IEventBus
    {
        Task RaiseEventAsync<TEvent>(TEvent raisedEvent) where TEvent : IEvent;
    }
}
