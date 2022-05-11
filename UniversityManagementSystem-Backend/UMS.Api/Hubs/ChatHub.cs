using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using UMS.Data.Entities;
using UMS.Dto;

namespace UMS.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public async Task ChatNotificationAsync(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveChatNotification", message);
        }
    }
}
