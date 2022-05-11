using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Business.Interface.Shared
{
    public interface ILocalStorageService
    {
        Task<string> GetAccessToken();
        Task SetAccessToken(string value);

        Task<string> GetRefreshToken();
        Task SetRefreshToken(string value);

        Task<ApplicationType> GetApplicationType();
        Task<DateTime> GetRefreshTokenTime();
        Task SetApplicationType(ApplicationType value);
        Task RemoveTokens();
        Task<string> GetUserId();
        Task SetUsername(string value);
        Task<string> GetUsername();

    }
}
