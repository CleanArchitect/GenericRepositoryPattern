using System.Threading.Tasks;
using Domain;
using Domain.PizzaCompany;
using Microsoft.AspNetCore.SignalR;

namespace API.PizzaCompany.EventHandlers
{
    public sealed class BestellingGeplaatstEventHandler : IEventHandler<BestellingGeplaatstEvent>
    {
        private readonly IHubContext<BestellingenHub, IBestellingenHub> hubContext;

        public BestellingGeplaatstEventHandler(IHubContext<BestellingenHub, IBestellingenHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        async Task IEventHandler<BestellingGeplaatstEvent>.HandleEventAsync(BestellingGeplaatstEvent raisedEvent)
        {
            await hubContext.Clients.All.SendClientBestelling(raisedEvent);
        }
    }
}
