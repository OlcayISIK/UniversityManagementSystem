using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Core.Utils;

namespace UMS.Api.Helpers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize(AuthenticationSchemes = Constants.AuthenticationSchemes.Student)]
    // This route is defined from Startup.cs
    // [Route("api/user/[controller]")]
    public class RefreshHub : Hub
    {
        //User calls this function from client-side to join a group which lets them listen events for their own company
        public async Task JoinGroup()
        {
            var claims = ClaimUtils.GetClaims(Context.User.Claims);
            await Groups.AddToGroupAsync(Context.ConnectionId, claims.UniversityId.ToString());
        }
    }
}
