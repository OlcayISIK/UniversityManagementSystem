using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using UMS.Core.Enums;

namespace UMS.Business.Hubs
{
    public class PublicEventHub : Hub
    {
        public async Task InvokeHubMethodForEveryone(string message)
        {
            await Clients.All.SendAsync("SendMessageToEveryone", message);
        }
    }
}
