using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.StudentService;
using UMS.Client.Core;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;

namespace UMS.Client.Business.Shared
{
    public class UniversitySocialClubService : IUniversitySocialClubService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public UniversitySocialClubService(IHttpService httpService, NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<UniversitySocialClubDto>>> GetAll()
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<UniversitySocialClubDto>>>(HttpMethod.Get,
                EndpointSettings.ServerRoutes.Student.SocialClub.GetAll);
            return response;
        }

        public async Task<Result<bool>> Join(StudentsUniversitySocialClubDto studentsUniversitySocialClubDto)
        {
            var response = await _httpService.SendRequest<Result<bool>>(HttpMethod.Post, EndpointSettings.ServerRoutes.Student.SocialClub.Join, studentsUniversitySocialClubDto);
            return response;
        }
    }
}
