using System.Threading.Tasks;
using Domain;
using Domain.PizzaCompany;
using Microsoft.AspNetCore.SignalR;

namespace API.PizzaCompany.EventHandlers
{
    public sealed class StatusBestellingGewijzigdEventHandler : IEventHandler<StatusBestellingGewijzigdEvent>
    {
        private readonly IHubContext<BestellingenHub, IBestellingenHub> hubContext;

        public StatusBestellingGewijzigdEventHandler(IHubContext<BestellingenHub, IBestellingenHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        async Task IEventHandler<StatusBestellingGewijzigdEvent>.HandleEventAsync(StatusBestellingGewijzigdEvent raisedEvent)
        {
            await hubContext.Clients.All.SendClientStatusUpdate(raisedEvent);
        }
    }
}
