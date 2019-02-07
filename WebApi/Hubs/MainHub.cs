using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class MainHub : Hub
    {
        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
