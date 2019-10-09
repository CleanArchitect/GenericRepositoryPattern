using System.Threading.Tasks;

namespace Domain
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {        
        Task HandleEventAsync(TEvent raisedEvent);
    }
}
