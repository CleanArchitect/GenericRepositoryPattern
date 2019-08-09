using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Examples.Presentation.API
{
    public class ToastModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }

    public interface IExampleHub
    {
        Task SendClientExamplesUpdate();
        Task SendClientToast(ToastModel toast);
    }

    public sealed class ExampleHub : Hub<IExampleHub>
    {
        public async Task BroadcastToast(ToastModel toast) => await Clients.All.SendClientToast(toast);
    }
}
