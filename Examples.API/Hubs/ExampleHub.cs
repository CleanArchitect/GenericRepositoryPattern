using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Examples.Presentation.API
{
    public interface IExampleHub
    {
        Task SendClientExamplesUpdate();
    }

    public sealed class ExampleHub : Hub<IExampleHub>
    {
    }
}
