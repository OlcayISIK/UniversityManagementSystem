using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.Enums;

namespace UMS.Business.Hubs
{
    public static class HubHelper
    {

        public static async Task InvokeHubMethodForGroup(IHubContext<EventHubForSocialClub> _refreshHub, long socialClubId, SocketMessageType messageType)
        {
            await _refreshHub.Clients.Group(socialClubId.ToString()).SendAsync(messageType.ToString());
        }
        public static async Task InvokeHubMethodForUniversity(IHubContext<EventHub> _refreshHub, long universityId, SocketMessageType messageType)
        {
            await _refreshHub.Clients.Group(universityId.ToString()).SendAsync(messageType.ToString());
        }
    }
}
