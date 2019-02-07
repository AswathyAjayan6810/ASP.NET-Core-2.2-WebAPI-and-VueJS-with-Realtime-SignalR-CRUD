using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using WebApi.Hubs;

namespace WebApi.Services
{
    public class NotifyAppClientService : INotifyAppClientService
    {
        private readonly IHubContext<MainHub> hubContext;

        public NotifyAppClientService(IHubContext<MainHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task Notify(string message)
        {
            return hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
