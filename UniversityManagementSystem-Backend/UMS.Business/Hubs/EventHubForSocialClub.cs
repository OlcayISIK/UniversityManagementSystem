using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UMS.Core.Utils;
using UMS.Repository.Shared;

namespace UMS.Business.Hubs
{
    [ApiExplorerSettings(IgnoreApi = true)]
    // This route is defined from Startup.cs
    // [Route("api/user/[controller]")]
    public class EventHubForSocialClub : Hub<IEventHubForSocialClub>
    {
        public static readonly List<UniversityConnection> activeCompanies = new List<UniversityConnection>(); 
        private readonly IUnitOfWork _unitOfWork;

        public EventHubForSocialClub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //User calls this function from client-side to join a group which lets them listen events for their own university or socialclub
        public async Task JoinGroup()
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);
            var student = await _unitOfWork.Students.Get(claims.UserId).FirstOrDefaultAsync();
            var connection = activeCompanies.Where(x => x.SocialClubId == student.UniversitySocialClubId).FirstOrDefault();

            if (connection == null)
            {
                var userConnection = new UniversityConnection { SocialClubId = student.UniversitySocialClubId, EventsActive = false };
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
            var student = await _unitOfWork.Students.Get(claims.UserId).FirstOrDefaultAsync();
            var connection = activeCompanies.Where(x => x.SocialClubId == student.UniversitySocialClubId).FirstOrDefault();
            if (connection != null)
            {
                connection.EventsActive = toggle;
                await Clients.Group(claims.UniversityId.ToString()).EventActivationToggled(toggle);
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);
            var student =  _unitOfWork.Students.Get(claims.UserId).FirstOrDefault();
            var connection = activeCompanies.Where(x => x.SocialClubId == student.UniversitySocialClubId).FirstOrDefault();
            if (connection != null)
            {
                connection.ActiveConnectionIds.Remove(Context.ConnectionId);
            }

            return base.OnDisconnectedAsync(exception);
        }
    }
}
