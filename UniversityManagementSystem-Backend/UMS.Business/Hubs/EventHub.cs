using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Core.Utils;

namespace UMS.Business.Hubs
{
    [ApiExplorerSettings(IgnoreApi = true)]
    // This route is defined from Startup.cs
    // [Route("api/user/[controller]")]
    public class EventHub : Hub<IEventHub>
    {
        public static readonly List<UniversityConnection> activeCompanies = new List<UniversityConnection>();

        //User calls this function from client-side to join a group which lets them listen events for their own university or socialclub
        public async Task JoinGroup()
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);

            var connection = activeCompanies.Where(x => x.UniversityId == claims.UniversityId).FirstOrDefault();
            if (connection == null)
            {
                var userConnection = new UniversityConnection { UniversityId = claims.UniversityId, EventsActive = false };
                userConnection.ActiveConnectionIds.Add(Context.ConnectionId);
                activeCompanies.Add(userConnection);
            }
            else
            {
                if (!connection.ActiveConnectionIds.Contains(Context.ConnectionId))
                    connection.ActiveConnectionIds.Add(Context.ConnectionId);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, claims.UniversityId.ToString());
        }

        public async Task ToggleOrders(bool toggle)
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);

            var connection = activeCompanies.Where(x => x.UniversityId == claims.UniversityId).FirstOrDefault();
            if (connection != null)
            {
                connection.EventsActive = toggle;
                await Clients.Group(claims.UniversityId.ToString()).EventActivationToggled(toggle);
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);

            var connection = activeCompanies.Where(x => x.UniversityId == claims.UniversityId).FirstOrDefault();
            if (connection != null)
            {
                connection.ActiveConnectionIds.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
