using Domain;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace API.PizzaCompany
{
    public interface IBestellingenHub
    {
        Task SendClientBestelling(IEvent raisedEvent);
        Task SendClientStatusUpdate(IEvent raisedEvent);
    }

    public sealed class BestellingenHub : Hub<IBestellingenHub>
    {
    }
}
