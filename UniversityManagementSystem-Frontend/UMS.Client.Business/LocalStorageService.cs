using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface;
using UMS.Client.Core.Enums;

namespace UMS.Client.Business
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string AccessTokenKey = "accessToken";
        private const string RefreshTokenKey = "refreshToken";
        private const string ApplicationType = "applicationType";
        private const string Culture = "culture";
        // These are for claim subjects
        private const string Username = "name";
        private const string UserId = "uid";
        private const string CompanyId = "cid";
        private const string UserType = "rid";

        private const string RefreshTokenTime = "refreshTokenTime";

        private readonly IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task<string> GetAccessToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", AccessTokenKey);
        }

        public async Task<string> GetRefreshToken()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorage.getItem", RefreshTokenKey);
        }

        public async Task<ApplicationType> GetApplicationType()
        {
            var value = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ApplicationType);
            var success = Enum.TryParse(typeof(ApplicationType), value, true, out var result);
            if (success)
                return (ApplicationType)result;
            return Core.Enums.ApplicationType.NotDefined;

        }
        public async Task SetAccessToken(string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", AccessTokenKey, value);
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(value);
            foreach (var key in tokenS.Claims)
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key.Type, key.Value);
            }
        }

        public async Task SetRefreshToken(string value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", RefreshTokenKey, value);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", RefreshTokenTime, DateTime.Now.ToUniversalTime());
        }
    }
}
