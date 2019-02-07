using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApi.Models;

namespace WebApi.Hubs
{
    public class MainHub : Hub, IMainHub
    {
        private readonly IHubContext<MainHub> hubContext;

        public MainHub(IHubContext<MainHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task NotifyAllClients()
        {
            await hubContext.Clients.All.SendAsync("ReceiveChanges");
        }
    }
}
