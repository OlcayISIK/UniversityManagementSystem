using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Interface.Teacher;
using UMS.Client.Core;
using UMS.Client.Dtos.Shared;
using UMS.Client.Dtos.Student;
using UMS.Client.Dtos.Teacher;

namespace UMS.Client.Business.Teacher
{
    internal class TeacherService : ITeacherService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public TeacherService(IHttpService httpService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task<Result<IEnumerable<CourseInstructorDto>>> GetAll()
        {
            var response = await _httpService.SendRequest<Result<IEnumerable<CourseInstructorDto>>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Teacher.TeacherService.GetAll);
            return response;
        }
        public async Task<Result<CourseInstructorDto>> Get(long userId)
        {
            var response = await _httpService.SendRequest<Result<CourseInstructorDto>>(HttpMethod.Get, EndpointSettings.ServerRoutes.Teacher.TeacherService.Get + $"/{userId}");
            return response;
        }
    }
}
