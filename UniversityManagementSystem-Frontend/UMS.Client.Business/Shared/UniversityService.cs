using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Core;
using UMS.Client.Dtos.Shared;

namespace UMS.Client.Business.Shared
{
    public class UniversityService : IUniversityService
    {
        private IHttpService _httpService;

        public UniversityService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<Result<IEnumerable<UniversityDto>>> GetAll()
        {
            return  await _httpService.SendRequest< Result<IEnumerable<UniversityDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Shared.University.GetAll);
        }
    }
}
