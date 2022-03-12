using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Client.Business.Interface.Shared
{
    public interface IHttpService
    {
        Task<T> SendRequest<T>(HttpMethod httpMethod, string uri, object value = null);
        Task RefreshAccessToken();
    }
}
