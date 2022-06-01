using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.Teacher;
using UMS.Client.Core;
using UMS.Client.Dtos;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Teacher;

namespace UMS.Client.Business.Teacher
{
    public class CourseService : ICourseService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public CourseService(IHttpService httpService, NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<CourseDto>>> GetAll(long courseInstructorId)
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<CourseDto>>>(HttpMethod.Get,
                EndpointSettings.ServerRoutes.Teacher.CourseService.GetAll + $"/{courseInstructorId}");
            return response;
        }
    }
}
