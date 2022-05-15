using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using UMS.Business.Abstract;
using UMS.Business.Abstract.StudentTransactions;
using UMS.Business.Concrete.StudentTransactions;
using UMS.Data.Entities;
using UMS.Dto;

namespace UMS.Business.Hubs
{
    public interface IEventHub
    {
        public Task JoinGroup();
        public Task EventActivationToggled(bool ordersClosed);
        //public async Task JoinUniversityRoom(string universityId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, universityId);
        //}
        //public async Task JoinSocialClubRoom(string socialClubId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, socialClubId);
        //}
        //public async Task BroadcastToEveyone(string message)
        //{
        //    await Clients.All.SendAsync("RecieveEventMessageEveryone",message);
        //}
        //public async Task BroadcastToRoomAsync(string groupName, string message)
        //{
        //    await Clients.Group(groupName).SendAsync("RecieveEventMessageGroup", message);
        //}

    }
}